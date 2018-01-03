using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using XiaoWeiOnlineEducation.Entity;

namespace XiaoWeiOnlineEducation.Filter
{
    public class LoginFilter : Filter.FilterBase
    {
        /// <summary>
        /// 当前页面功能编号
        /// </summary>
        public string FuncId
        {
            get { return Request.QueryString["funcid"]; }
        }

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public LoginEntity LoginUser
        {
            get
            {
                return SessionData.LoginedUser;
            }
        }

        /// <summary>
        /// 上一个页面路径
        /// </summary>
        public string PrevUrl
        {
            get { return Convert.ToString(ViewState["PrevUrl"]); }
            set { ViewState["PrevUrl"] = value; }
        }

        /// <summary>
        /// 返回
        /// </summary>
        public void Back()
        {
            Response.Redirect(PrevUrl);
        }

        /// <summary>
        /// 预初始化
        /// </summary>
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            Session.Timeout = 1440;
            if (!SessionData.IsLogined)
            {
                HttpContext.Current.Response.Write(ConfigManager.ExitCode);
                HttpContext.Current.Response.End();
            }
        }

        /// <summary>
        /// 加载
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    PrevUrl = Request.UrlReferrer.ToString();
                }
            }
            base.OnLoad(e);
        }

        /// <summary>
        /// 获取空行
        /// </summary>
        /// <param name="rpt">Repeater 控件</param>
        /// <param name="colspan">合并列数</param>
        /// <returns>空行</returns>
        public string GetEmptyRow(Repeater rpt, int colspan)
        {
            return WebHelper.GetEmptyRow(rpt, colspan);
        }

        /// <summary>
        /// 获取截取字段后的文字
        /// </summary>
        /// <param name="len">长度</param>
        /// <param name="obj">要截取的对象</param>
        /// <returns>截取字段后的文字</returns>
        public string GetSubstringStr(int len, object obj)
        {
            return WebHelper.GetSubstringStr(len, obj);
        }

        /// <summary>
        /// 判断字段是否为空
        /// </summary>
        /// <param name="obj">字段</param>
        /// <param name="msg">为空时显示</param>
        /// <returns>字段的值</returns>
        public object GetNULLStr(object obj, string msg = "暂无")
        {
            return WebHelper.GetNULLStr(obj, msg);
        }

        /// <summary>
        /// 获取列表序号
        /// </summary>
        /// <param name="index">当前索引</param>
        /// <param name="pager">当前Pager对象</param>
        /// <returns>列表序号</returns>
        public int GetItemIndex(int index, AspNetPager pager)
        {
            return WebHelper.GetItemIndex(index, pager);
        }

        /// <summary>
        /// 获取分页控件总记录条数
        /// </summary>
        /// <param name="pager">当前Pager对象</param>
        /// <returns>总记录条数</returns>
        public string GetPagerTotalCount(AspNetPager pager)
        {
            return WebHelper.GetPagerTotalCount(pager);
        }
    }
}