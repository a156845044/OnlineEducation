using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiaoWeiOnlineEducation.BLL;
using XiaoWeiOnlineEducation.Entity;

namespace XiaoWeiOnlineEducation.Handler
{
    /// <summary>
    /// User
    /// </summary>
    public class User : Controller
    {
        #region 2017-05
        /// <summary>
        /// 验证登录密码
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="pwd">密码</param>
        /// <returns>true:通过 false：失败</returns>
        /// <remarks>作者：dfq 时间：2017-05-07</remarks>
        public JsonResult CheckPwd(string userId, string pwd)
        {
            JsonEntity<bool> json = new JsonEntity<bool>();
            Base_UserBiz userBiz = new Base_UserBiz();
            pwd = Brilliant.Utility.EncryptHelper.Md5(pwd.Trim());
            json.data = userBiz.GetPwdCheck(userId.Trim(), pwd);
            if (json.data)
            {
                json.code = ReturnCode.Succ.ToInt();
                json.msg = "密码验证成功！";
            }
            else
            {
                json.code = ReturnCode.Error.ToInt();
                json.msg = "密码验证失败！";
            }
            return Json(json);
        }
        #endregion
    }
}