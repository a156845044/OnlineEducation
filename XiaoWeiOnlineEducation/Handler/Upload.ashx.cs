using Brilliant.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using XiaoWeiOnlineEducation.Entity;

namespace XiaoWeiOnlineEducation.Handler
{
    /// <summary>
    /// 上传
    /// </summary>
    public class Upload : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //取得处事类型
            string action = context.Request["action"];

            switch (action)
            {
                case "onUpload":
                    SaveAsFile(context);//用户文件上传
                    break;
                case "onDownload"://流下载
                    Dowmload(context);
                    break;

            }
        }



        #region 文件上传=================================
        /// <summary>
        /// 用户上传文件
        /// </summary>
        /// <param name="context">上下文</param>
        private void SaveAsFile(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            try
            {
                HttpPostedFile postedFile = context.Request.Files["Filedata"];
                if (postedFile != null)
                {

                    string configPath = ConfigManager.UploadPath;//获取配置的文件保存虚拟路径
                    string fileExt = GetFileExt(postedFile.FileName); //文件扩展名，不含“.”
                    long fileSize = postedFile.ContentLength; //获得文件大小，以字节为单位
                    string fileName = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf(@"\") + 1); //取得原文件名
                    string randomFileName = String.Format("{0}.{1}", StringHelper.GetPrimaryKey(), fileExt);//获取文件新名称，随机数

                    AttachInfo attach = new AttachInfo();

                    //检查文件扩展名是否合法
                    if (!CheckFileExt(fileExt))
                    {
                        attach.code = ReturnCode.Error.ToInt();
                        attach.msg = "文件格式不合法！";
                        context.Response.Write(JsonHelper.JSSerialize(attach));
                        return;
                    }
                    string virPath = GetUpLoadPath(configPath);//相对路径
                    string phyPath = GetMapPath(string.Format("~{0}", virPath));//绝对路径

                    //检查上传的物理路径是否存在，不存在则创建
                    if (!Directory.Exists(phyPath))
                    {
                        Directory.CreateDirectory(phyPath);
                    }

                    //检查是否为图片
                    if (CheckImage(fileExt))
                    {
                        //如果当前文件大小大于1M,则进行文件压缩
                        if (fileSize >= (Math.Pow(1024, 2)))
                        {
                            byte[] imges = Thumbnail.CompressionImage(postedFile.InputStream, 16L);
                            File.WriteAllBytes(Path.Combine(phyPath, randomFileName), imges);
                        }
                        else
                        {
                            postedFile.SaveAs(string.Format("{0}{1}", phyPath, randomFileName));//保存文件
                        }
                    }
                    else
                    {
                        postedFile.SaveAs(string.Format("{0}{1}", phyPath, randomFileName));//保存文件
                    }
                    string attachPath = string.Format("{0}{1}", virPath, randomFileName);

                    attach.code = ReturnCode.Succ.ToInt();
                    attach.msg = "上传成功！";
                    attach.path = attachPath;
                    attach.name = fileName;
                    attach.size = fileSize;
                    attach.extension = fileExt;

                    context.Response.Write(JsonHelper.SerializeObject(attach));
                }
                else
                {
                    context.Response.Write("0");
                }
            }
            catch (Exception ex)
            {
                AttachInfo attach = new AttachInfo();
                attach.code = ReturnCode.Error.ToInt();
                attach.msg = ex.Message;
                attach.path = "";
                attach.name = "";
                attach.size = 0;
                attach.extension = "";
                context.Response.Write(JsonHelper.SerializeObject(attach));
            }
        }
        #endregion

        /// <summary>
        /// 流下载
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <remarks>作者：dfq 时间：2016-05-18</remarks>
        private void Dowmload(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string path = context.Request["FilePath"];
            string name = context.Request["FileName"];
            DownloadHelper.DownloadFile(path, name);
        }

        #region ====私有方法====

        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        ///  <remarks>作者：dfq 时间：2014.04.02</remarks>
        private string GetMapPath(string strPath)
        {
            if (strPath.ToLower().StartsWith("http://"))
            {
                return strPath;
            }
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }

        /// <summary>
        /// 返回上传目录相对路径
        /// </summary>
        /// <param name="fileName">上传文件名</param>
        private string GetUpLoadPath(string uploadPath)
        {
            string path = uploadPath; //上传文件目录
            //按年月日每天一个文件夹
            path += DateTime.Now.ToString("yyyyMMdd");
            return path + "/";
        }

        /// <summary>
        /// 检查是否为合法的上传文件
        /// </summary>
        private bool CheckFileExt(string _fileExt)
        {
            //检查危险文件
            string[] excExt = { "asp", "aspx", "php", "jsp", "htm", "html" };
            for (int i = 0; i < excExt.Length; i++)
            {
                if (excExt[i].ToLower() == _fileExt.ToLower())
                {
                    return false;
                }
            }
            //检查合法文件
            string[] allowExt = ConfigManager.AllowExt.Split(',');
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i].ToLower() == _fileExt.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 返回文件扩展名，不含“.”
        /// </summary>
        /// <param name="_filepath">文件全名称</param>
        /// <returns>string</returns>
        public string GetFileExt(string _filepath)
        {
            if (string.IsNullOrEmpty(_filepath))
            {
                return "";
            }
            if (_filepath.LastIndexOf(".") > 0)
            {
                return _filepath.Substring(_filepath.LastIndexOf(".") + 1).ToLower(); //文件扩展名，不含“.”
            }
            return "";
        }

        /// <summary>
        /// 生成日期随机码
        /// </summary>
        /// <returns></returns>
        public string GetRamCode()
        {
            #region
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");
            #endregion
        }

        /// <summary>
        /// 检查是否为图片
        /// </summary>
        private bool CheckImage(string _fileExt)
        {
            string ext = "png,jpg,gif,jpeg,bmp";
            //检查危险文件
            string[] excExt = { "asp", "aspx", "php", "jsp", "htm", "html" };
            for (int i = 0; i < excExt.Length; i++)
            {
                if (excExt[i].ToLower() == _fileExt.ToLower())
                {
                    return false;
                }
            }
            //检查合法文件
            string[] allowExt = ext.Split(',');
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i].ToLower() == _fileExt.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 上传附件实体
    /// </summary>
    public class AttachInfo
    {
        /// <summary>
        /// 返回自定义代码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 原始文件路径
        /// </summary>
        public string path { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public long size { get; set; }

        /// <summary>
        /// 扩展名
        /// </summary>
        public string extension { get; set; }

    }
}