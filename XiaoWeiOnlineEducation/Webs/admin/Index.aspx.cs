using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XiaoWeiOnlineEducation.Webs.admin
{
    public partial class Index : Filter.LoginFilter
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
        }
    }
}