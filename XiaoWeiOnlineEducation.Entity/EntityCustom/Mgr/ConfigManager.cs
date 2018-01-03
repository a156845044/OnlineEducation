using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace XiaoWeiOnlineEducation.Entity
{

    /// <summary>
    /// 配置管理器
    /// </summary>
    public class ConfigManager
    {
        /// <summary>
        /// 退出代码
        /// </summary>
        public static string ExitCode
        {
            get
            {
                return HttpContext.Current.Server.HtmlDecode(ConfigurationManager.AppSettings["ExitCode"]);
            }
        }


        /// <summary>
        /// 获取用户上传文件的默认路径
        /// </summary>
        public static string UploadPath
        {
            get { return ConfigurationManager.AppSettings["UploadPath"].ToString(); }
        }

        /// <summary>
        /// 更新文件存放目录
        /// </summary>
        public static string UpgradePath
        {
            get { return ConfigurationManager.AppSettings["UpgradePath"]; }
        }

        /// <summary>
        /// 合法的文件格式
        /// </summary>
        public static string AllowExt
        {
            get { return ConfigurationManager.AppSettings["AllowExt"]; }
        }
        
    }
}
