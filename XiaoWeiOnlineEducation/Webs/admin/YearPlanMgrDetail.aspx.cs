using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XiaoWeiOnlineEducation.BLL;

namespace XiaoWeiOnlineEducation.Webs.admin
{
    public partial class YearPlanMgrDetail : Filter.LoginFilter
    {
        Mod_Online_YearPlan_DetailBiz detailBiz = new Mod_Online_YearPlan_DetailBiz();

        #region 成员变量

        /// <summary>
        /// 关键字
        /// </summary>
        protected string Keyword
        {
            get { return txtKeyword.Text; }
            set { txtKeyword.Text = value; }
        }

        /// <summary>
        /// 计划编号
        /// </summary>
        private string PlanId
        {
            get { return Request.QueryString["PlanId"]; }
        }


        #endregion

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
            BindrptList();//绑定计划列表
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControl()
        {
        }

        /// <summary>
        /// 绑定计划列表
        /// </summary>
        private void BindrptList()
        {
            int recordCount = 0;
            rptList.DataSource = detailBiz.GetList(PlanId, Keyword, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out recordCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = recordCount;
        }

        /// <summary>
        /// 页码发生改变
        /// </summary>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindrptList();//绑定计划列表
        }

        /// <summary>
        /// 搜索
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            BindrptList();//绑定计划列表
        }
    }
}