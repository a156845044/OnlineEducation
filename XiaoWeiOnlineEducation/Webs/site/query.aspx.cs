using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XiaoWeiOnlineEducation.BLL;

namespace XiaoWeiOnlineEducation.Webs.site
{
    public partial class query : System.Web.UI.Page
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
            BindddlCategory();//绑定报考类型
        }

        /// <summary>
        /// 绑定报考类型
        /// </summary>
        private void BindddlCategory()
        {
            ddlCategory.DataSource = new Mod_Online_ApplicationTypeBiz().GetList();
            ddlCategory.DataTextField = "AppTypeName";
            ddlCategory.DataValueField = "AppTypeId";
            ddlCategory.DataBind();
        }

        /// <summary>
        /// 查询
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string apptypeId = ddlCategory.SelectedValue;
            string codeId = txtCodeId.Text;
            Response.Redirect(string.Format("~/Webs/site/querylist.aspx?type={0}&code={1}", apptypeId, codeId));
        }
    }
}