using Brilliant.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using XiaoWeiOnlineEducation.BLL;
using XiaoWeiOnlineEducation.Entity;

namespace XiaoWeiOnlineEducation.Webs.site
{
    public partial class querylist : System.Web.UI.Page
    {
        /// <summary>
        /// 专业代码
        /// </summary>
        private string code
        {
            get { return Request.QueryString["code"]; }
        }

        /// <summary>
        /// 报考类别
        /// </summary>
        private string type
        {
            get { return Request.QueryString["type"]; }
        }

        /// <summary>
        /// 当前年份成绩是否可查
        /// </summary>
        protected bool CurrentEnable
        {
            get { return ViewState["CurrentEnable"] == null ? false : Convert.ToBoolean(ViewState["CurrentEnable"]); }
            set { ViewState["CurrentEnable"] = value; }
        }

        /// <summary>
        /// 当前年份
        /// </summary>
        protected int YearId
        {
            get { return ViewState["YearId"] == null ? 2017 : Convert.ToInt32(ViewState["YearId"]); }
            set { ViewState["YearId"] = value; }
        }

        /// <summary>
        /// 计划编码
        /// </summary>
        protected string PlanId
        {
            get { return ViewState["PlanId"].ToString(); }
            set { ViewState["PlanId"] = value; }
        }
        

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
            AspNetPager1.PageSize = 5;
        }

        /// <summary>
        /// 初始化视图状态
        /// </summary>
        private void InitViewState()
        {
            Mod_Online_YearPlanBiz planBiz = new Mod_Online_YearPlanBiz();
            Mod_Online_YearPlanEntity model = planBiz.GetFirstYearPlanModel();
          
            if (model == null)
            {
                Response.Redirect("~/Webs/404.aspx");
            }
            else
            {
                PlanId = model.PlanId;
                YearId = model.YearId;
                if (model.StateFlag == 1)
                {
                    CurrentEnable = true;
                }
            }
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
        /// 获取列表序号
        /// </summary>
        /// <param name="index">当前索引</param>
        /// <param name="pager">当前Pager对象</param>
        /// <returns>列表序号</returns>
        public int GetItemIndex(int index, AspNetPager pager)
        {
            return WebHelper.GetItemIndex(index, pager);
        }

        /// <summary>
        /// 获取以前年份的分数
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="castScore">分数线</param>
        /// <returns>以前年份的分数</returns>
        public string GetBeforeScore(int year, object castScore)
        {
            string temp = "";
            string format = "{0}年：&nbsp;{1}";
            if (castScore == null)
            {
                temp = "暂无";
            }
            else if (castScore == DBNull.Value)
            {
                temp = "暂无";
            }
            else
            {
                double score = castScore.ToDouble();
                if (score <= 0)
                {
                    temp = "暂无";
                }
                else
                {
                    temp = string.Format("{0}分", castScore);
                }
            }
            return string.Format(format, year, temp);


        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindrptList()
        {
            int recordCount = 0;
            string tempCode = code;
            if (!string.IsNullOrWhiteSpace(code))
            {
                if (code.Length > 4)
                {
                    tempCode = code.Substring(0, 4);
                }
            }
            //  rptList.DataSource = new Mod_Online_YearPlan_DetailBiz().GetQueryList(YearId, tempCode, type, "", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out recordCount);
            var list = new Mod_Online_YearPlan_DetailBiz().GetMajorSearchbySchool(PlanId, YearId, tempCode, type, "", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out recordCount);
            rptList.DataSource = list;
            rptList.DataBind();
            AspNetPager1.RecordCount = recordCount;
        }

        /// <summary>
        /// 获取空行
        /// </summary>
        /// <param name="rpt">Repeater 控件</param>
        /// <returns>空行</returns>
        public static string GetEmptyRow(Repeater rpt)
        {
            return rpt.Items.Count == 0 ? " <div class=\"am-panel am-panel-default\"><ul class=\"am-list am-list-static\"> <li>未找到对应的查询记录!</li></ul></div>" : "";
        }

        /// <summary>
        /// 页码发生改变
        /// </summary>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindrptList();//绑定计划列表
        }

    }
}