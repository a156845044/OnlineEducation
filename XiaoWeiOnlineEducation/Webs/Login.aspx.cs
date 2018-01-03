using Brilliant.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XiaoWeiOnlineEducation.BLL;
using XiaoWeiOnlineEducation.Entity;

namespace XiaoWeiOnlineEducation.Webs
{
    public partial class Login : System.Web.UI.Page
    {
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
        }

        /// <summary>
        /// 登录
        /// </summary>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string account = txtAccount.Text.Trim();
            string pwd = Brilliant.Utility.EncryptHelper.Md5(txtPwd.Text.Trim());
            LoginEntity loginUser = new Base_UserBiz().Login(account, pwd);

            if (loginUser.ErrorCode != LoginError.ForbiddenPC)
            {
                if (loginUser.ErrorCode == LoginError.Normal)
                {
                    SessionData.LoginedUser = loginUser;
                    Response.Redirect("~/Webs/admin/Index.aspx");
                }
                else
                {
                    string msg = Enum<LoginError>.GetDesc(loginUser.ErrorCode);
                    DialogHelper.ShowDialogErrorMsg(msg, "", this.Page);
                }
            }
            else
            {
                string msg = Enum<LoginError>.GetDesc(loginUser.ErrorCode);
                DialogHelper.ShowDialogErrorMsg(msg, "", this.Page);
            }
        }
    }
}