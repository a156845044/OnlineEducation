using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XiaoWeiOnlineEducation.Entity;

namespace XiaoWeiOnlineEducation.Webs.inc
{
    public partial class Site : System.Web.UI.MasterPage
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
            if (SessionData.IsLogined)
            {
                if (LoginUser != null)
                {
                    litUserName.Text = LoginUser.UserName;

                }
            }
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
        /// 登出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnLogOut_Click(object sender, EventArgs e)
        {
            SessionManager.ClearSession(SessionFlag.LoginUser.ToString()); //清除Session记录
            Response.Write(ConfigManager.ExitCode);
        }
    }
}