using Brilliant.ORM;
using Brilliant.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace XiaoWeiOnlineEducation.Handler
{
    /*
     * 实现IRequiresSessionState操作Session会影响性能
     * IReadOnlySessionState对Session只能读，不能写，不影响性能
     */
    /// <summary>
    /// 控制器基类
    /// </summary>
    public class Controller : IHttpHandler, IReadOnlySessionState
    {
        private HttpContext context;

        /// <summary>
        /// 上下文对象
        /// </summary>
        protected HttpContext Context
        {
            get { return context; }
        }

        /// <summary>
        /// 跳转视图
        /// </summary>
        /// <param name="url">链接</param>
        protected ActionResult View(string url)
        {
            context.Response.Redirect(url);
            return new ActionResult();
        }

        /// <summary>
        /// 返回Json数据
        /// </summary>
        /// <param name="data">需转化的对象</param>
        protected JsonResult Json(object data)
        {
            string json = JsonHelper.JSSerialize(data);
            context.Response.Write(json);
            return new JsonResult();
        }

        /// <summary>
        /// 返回字符串
        /// </summary>
        /// <param name="text">字符串文本</param>
        protected TextResult Text(string text)
        {
            context.Response.Write(text);
            return new TextResult();
        }

        /// <summary>
        /// 返回字符串
        /// </summary>
        /// <param name="text">字符串文本</param>
        /// <param name="args">格式化参数</param>
        protected TextResult Text(string text, params object[] args)
        {
            string str = String.Format(text, args);
            context.Response.Write(str);
            return new TextResult();
        }

        /// <summary>
        /// 通过实现 System.Web.IHttpHandler 接口的自定义 HttpHandler 启用 HTTP Web 请求的处理。
        /// </summary>
        /// <param name="context">上下文对象</param>
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string action = context.Request.QueryString["action"];
            if (!String.IsNullOrEmpty(action))
            {
                Type type = this.GetType();
                MethodInfo method = type.GetMethod(action);
                ParameterInfo[] parameters = method.GetParameters();
                List<object> list = new List<object>();
                if (parameters.Length > 0)
                {
                    Type paramType = null;
                    Type entityType = typeof(EntityBase);
                    string value = String.Empty;
                    foreach (var parameter in parameters)
                    {
                        paramType = parameter.ParameterType; //参数类型
                        value = context.Request[parameter.Name]; //参数值列表字符串
                        if (value == null)
                        {
                            context.Response.Write(String.Format("方法:{0} 参数:{1} 未找到对应的值。", action, parameter.Name));
                            continue;

                        }

                        //如果是实体类(暂时如此判定)
                        if (paramType.BaseType.Name == entityType.Name)
                        {
                            object obj = GetEntity(paramType, value);
                            list.Add(obj);
                        }
                        //判断是否为泛型集合
                        else if (paramType.IsGenericType)
                        {
                            object obj = GetEntities(paramType, value);
                            list.Add(obj);
                        }
                        //非实体类型
                        else
                        {
                            object obj = GetValue(paramType, value);
                            list.Add(obj);
                        }
                    }
                }
                try
                {
                    type.InvokeMember(action, BindingFlags.Default | BindingFlags.InvokeMethod, null, this, list.ToArray());
                }
                catch (Exception ex)
                {
                    context.Response.Write(String.Format("调用名为{0}的Action时引发异常，异常信息：", action));
                    context.Response.Write(ex.Message);
                }
            }
            else
            {
                List<HttpMethodInfo> list = GetHttpMethod();
                StringBuilder sb = new StringBuilder();
                sb.Append("<html><head><title></title><link href=\"../CSS/style.css\" rel=\"stylesheet\" type=\"text/css\" /></head>");
                sb.Append("<table class=\"flat_table\">");
                sb.Append("<tr><th>方法列表</th><th>方法说明</th></tr>");
                foreach (var item in list)
                {
                    sb.AppendFormat("<tr><td class=\"align_left\" style=\"width:50%;\">{0}</td><td class=\"align_left\" style=\"width:50%;\">{1}</td></tr>", item.FunName, item.FuncRemark);
                }
                sb.Append("</table>");
                sb.Append("</html>");
                context.Response.Write(sb.ToString());
            }
        }

        /// <summary>
        /// 获取一个值，该值指示其他请求是否可以使用 System.Web.IHttpHandler 实例。
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 获取所有Http方法
        /// </summary>
        /// <returns>方法名称列表</returns>
        private List<HttpMethodInfo> GetHttpMethod()
        {
            List<HttpMethodInfo> list = new List<HttpMethodInfo>();
            Type type = this.GetType();
            MethodInfo[] methods = type.GetMethods();
            StringBuilder sbParam = new StringBuilder();
            foreach (var method in methods)
            {
                if (!method.IsDefined(typeof(HttpMethodAttribute), false))
                {
                    continue;
                }
                HttpMethodInfo httpMethodInfo = new HttpMethodInfo();
                sbParam.Clear();
                object[] attributes = method.GetCustomAttributes(true);
                string remark = attributes.Length > 0 ? (attributes[0] as HttpMethodAttribute).Desc : String.Empty;
                ParameterInfo[] parameters = method.GetParameters();
                foreach (var parameter in parameters)
                {
                    string strParamType = parameter.ParameterType.Name;
                    Type paramType = parameter.ParameterType;
                    if (paramType.IsGenericType)
                    {
                        Type genericType = paramType.GetGenericArguments()[0];
                        //`1
                        strParamType = strParamType.Replace("`1", "");
                        strParamType = String.Format("{0}&lt;{1}&gt;", strParamType, genericType.Name);
                    }
                    sbParam.AppendFormat("{0} {1}, ", strParamType, parameter.Name);
                }
                string strParam = sbParam.ToString().TrimEnd(' ').TrimEnd(',');
                string str = String.Format("{0}({1})", method.Name, strParam);
                httpMethodInfo.FunName = str;
                httpMethodInfo.FuncRemark = remark;
                list.Add(httpMethodInfo);
            }
            return list;
        }

        /// <summary>
        /// 获取实体对象
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <param name="values">值列表</param>
        /// <returns>实体对象</returns>
        private object GetEntity(Type type, string value)
        {
            Dictionary<string, object> dic = JsonHelper.DeSerializeObject<Dictionary<string, object>>(value);
            return GetEntity(type, dic);
        }

        /// <summary>
        /// 获取实体对象
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <param name="dic">值列表</param>
        /// <returns>实体对象</returns>
        private object GetEntity(Type type, Dictionary<string, object> dic)
        {
            try
            {
                object obj = Activator.CreateInstance(type);
                EntityBase entity = obj as EntityBase;
                PropertyInfo[] properties = type.GetProperties();
                foreach (var property in properties)
                {
                    string key = property.Name;
                    if (dic.ContainsKey(key))
                    {
                        object propertyValue = dic[key];
                        entity.SetProperty(key, Convert.ChangeType(propertyValue, property.PropertyType));
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                context.Response.Write("创建实体对象时产生异常，异常信息:");
                context.Response.Write(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取实体对象列表
        /// </summary>
        /// <param name="type">实体对象列表类型</param>
        /// <param name="value">值列表</param>
        /// <returns>实体对象列表</returns>
        private object GetEntities(Type type, string value)
        {
            try
            {
                List<Dictionary<string, object>> dicList = JsonHelper.DeSerializeObject<List<Dictionary<string, object>>>(value);
                Type entityType = type.GetGenericArguments()[0];
                object entities = Activator.CreateInstance(type);
                foreach (var dic in dicList)
                {
                    object obj = GetEntity(entityType, dic);
                    type.InvokeMember("Add", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null, entities, new object[] { obj });
                }
                return entities;
            }
            catch (Exception ex)
            {
                context.Response.Write("创建实体对象列表时产生异常，异常信息:");
                context.Response.Write(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="value">值列表</param>
        /// <returns>参数值</returns>
        private object GetValue(Type type, string value)
        {
            try
            {
                return Convert.ChangeType(value, type);
            }
            catch (Exception ex)
            {
                context.Response.Write("转换参数对应值时产生异常，异常信息:");
                context.Response.Write(ex.Message);
                return null;
            }
        }
    }

    public class ActionResult
    {

    }

    public class JsonResult
    {

    }

    public class TextResult
    {

    }

    public class FileResult
    {

    }

    /// <summary>
    /// 方法信息
    /// </summary>
    public class HttpMethodInfo
    {
        /// <summary>
        /// 方法签名
        /// </summary>
        public string FunName { get; set; }

        /// <summary>
        /// 方法备注
        /// </summary>
        public string FuncRemark { get; set; }
    }

    /// <summary>
    /// 特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class HttpMethodAttribute : Attribute
    {
        private string _desc;

        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }

        public HttpMethodAttribute()
        {

        }

        public HttpMethodAttribute(string remark)
        {
            this._desc = remark;
        }
    }
}