using Brilliant.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XiaoWeiOnlineEducation.BLL;
using XiaoWeiOnlineEducation.Entity;

namespace XiaoWeiOnlineEducation.Webs.User
{
    public partial class PwdMgr : Filter.LoginFilter
    {

        /// <summary>
        /// 页面加载
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreInitControls();//预初始化控件
                InitViewState();//初始化视图状态
                InitPage();//初始化页面
                InitControl();//初始化控件
            }
        }

        /// <summary>
        /// 预初始化控件
        /// </summary>
        private void PreInitControls()
        {
        }

        /// <summary>
        /// 初始化视图状态
        /// </summary>
        private void InitViewState()
        {

        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        private void InitPage()
        {
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControl()
        {
            litAccount.Text = LoginUser.Account;
            hfldUserId.Value = LoginUser.UserId;
        }

        /// <summary>
        /// 保存密码修改
        /// </summary>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Base_UserBiz userBiz = new Base_UserBiz();//人员业务

            string userId = LoginUser.UserId;
            string pwd = EncryptHelper.Md5(txtNewPwd.Text.Trim());
            if (userBiz.UpdatePwd(userId, pwd))
            {
                SessionManager.ClearSession(SessionFlag.LoginUser.ToString()); //清除Session记录
                DialogHelper.ShowTipSuccessMsg("修改成功，请重新登录！", "", "logout", Page);
            }
            else
            {
                DialogHelper.ShowTipErrorMsg("修改失败，再试一试？", "", Page);
            }
        }
    }
}