using Brilliant.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XiaoWeiOnlineEducation.BLL;
using XiaoWeiOnlineEducation.Entity;

namespace XiaoWeiOnlineEducation.Webs.admin
{
    public partial class YearPlanMgr : Filter.LoginFilter
    {

        Mod_Online_YearPlanBiz planBiz = new Mod_Online_YearPlanBiz();

        #region 成员变量

        /// <summary>
        /// 关键字
        /// </summary>
        protected string Keyword
        {
            get { return txtKeyword.Text; }
            set { txtKeyword.Text = value; }
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
            rptList.DataSource = planBiz.GetList(Keyword, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out recordCount);
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

        /// <summary>
        /// 导入
        /// </summary>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string year = txtYear.Text;
            if (string.IsNullOrEmpty(year))
            {
                DialogHelper.ShowTipSuccessMsg("未获取到年度信息，请检查浏览器的JavaScript是否运行正常！", "", Page);
                return;
            }

            string path = hfldAttachData.Value;
            if (string.IsNullOrEmpty(path))
            {
                DialogHelper.ShowTipSuccessMsg("未获取到相关导入信息，请检查浏览器的JavaScript是否运行正常！", "", Page);
                return;
            }

            if (ddlType.SelectedValue.Trim() == "0")
            {
                if (planBiz.ExcelImport(year, path, LoginUser))
                {
                    DialogHelper.ShowTipSuccessMsg("导入计划成功！", "", Page);
                    BindrptList();//绑定计划列表
                }
                else
                {
                    DialogHelper.ShowDialogErrorMsg("操作计划失败！", "", Page);
                }
            }
            else//导入分数
            {
                if (planBiz.ExcelScoreImport(year, path))
                {
                    DialogHelper.ShowTipSuccessMsg("导入分数成功！", "", Page);
                    BindrptList();//绑定计划列表
                }
                else
                {
                    DialogHelper.ShowDialogErrorMsg("操作分数失败！", "", Page);
                }
            }


        }

        /// <summary>
        /// 行内事件
        /// </summary>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "lbtnOpen")
            {
                string[] info = e.CommandArgument.ToString().Split(',');
                if (info.Length > 1)
                {
                    string id = info[1];
                    int flag = info[0].ToInt();

                    int stateFlag = flag;
                    if (flag == 0)
                    {
                        stateFlag = 1;
                    }
                    else
                    {
                        stateFlag = 0;
                    }

                    if (planBiz.UpdateState(id, stateFlag))
                    {
                        DialogHelper.ShowTipSuccessMsg("操作成功！", "", Page);
                        BindrptList();//绑定计划列表
                    }
                    else
                    {
                        DialogHelper.ShowDialogErrorMsg("操作失败！", "", Page);
                    }
                }
            }
        }
    }
}