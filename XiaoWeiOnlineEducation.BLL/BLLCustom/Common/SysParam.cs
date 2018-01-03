using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoWeiOnlineEducation.BLL
{
    /// <summary>
    /// 系统参数
    /// </summary>
    public class SysParam
    {
        /// <summary>
        /// 默认日期字符串
        /// </summary>
        public static string DefaultDateTimeStr
        {
            get { return "1990-01-01"; }
        }

        /// <summary>
        /// 默认日期
        /// </summary>
        public static DateTime DefaultDateTime
        {
            get { return Convert.ToDateTime(DefaultDateTimeStr); }
        }

        /// <summary>
        /// 默认密码（已经加密）
        /// </summary>
        public static string DefaultPwd
        {
            get { return Brilliant.Utility.EncryptHelper.Md5("123456"); }
        }
    }
}
