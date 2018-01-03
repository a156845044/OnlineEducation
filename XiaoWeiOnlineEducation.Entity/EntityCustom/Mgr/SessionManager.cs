using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace XiaoWeiOnlineEducation.Entity
{
    /// <summary>
    /// Session管理器
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class SessionManager
    {
        /// <summary>
        /// 获取Session中对象
        /// </summary>
        public static T GetSession<T>(string key)
        {
            object obj = HttpContext.Current.Session[key];
            if (obj == null)
                return default(T);
            else
                return (T)obj;
        }

        /// <summary>
        /// 设置Session中的对象
        /// </summary>
        public static void SetSession<T>(string key, T obj)
        {
            HttpContext.Current.Session[key] = obj;
        }

        /// <summary>
        /// 清除Session对象
        /// </summary>
        public static void ClearSession(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        /// <summary>
        /// 清除所有Session对象
        /// </summary>
        public static void ClearAllSession()
        {
            HttpContext.Current.Session.Clear();
        }
    }

    /// <summary>
    /// Session数据
    /// </summary>
    public class SessionData
    {
        /// <summary>
        /// 登录用户
        /// </summary>
        public static LoginEntity LoginedUser
        {
            get { return SessionManager.GetSession<LoginEntity>(SessionFlag.LoginUser.ToString()); }
            set
            {
                if (value == null)
                {
                    SessionManager.ClearSession(SessionFlag.LoginUser.ToString());
                }
                else
                {
                    SessionManager.SetSession<LoginEntity>(SessionFlag.LoginUser.ToString(), value);
                }
            }
        }

        /// <summary>
        /// 是否登录
        /// </summary>
        public static bool IsLogined
        {
            get { return LoginedUser == null ? false : true; }
        }
    }
}
