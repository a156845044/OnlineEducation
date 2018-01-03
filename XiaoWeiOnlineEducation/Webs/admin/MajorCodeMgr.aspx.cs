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
    public partial class MajorCodeMgr : Filter.LoginFilter
    {

        Mod_Online_MajorCodeBiz codeBiz = new Mod_Online_MajorCodeBiz();

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
            BindrptMajorCodeList();//绑定专业代码列表
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControl()
        {
        }

        /// <summary>
        /// 绑定专业代码列表
        /// </summary>
        private void BindrptMajorCodeList()
        {
            int recordCount = 0;
            rptMajorCodeList.DataSource = codeBiz.GetCodeList(Keyword, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out recordCount);
            rptMajorCodeList.DataBind();
            AspNetPager1.RecordCount = recordCount;
        }

        /// <summary>
        /// 页码发生改变
        /// </summary>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindrptMajorCodeList();//绑定专业代码列表
        }

        /// <summary>
        /// 搜索
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            BindrptMajorCodeList();//绑定专业代码列表
        }

        /// <summary>
        /// 导入
        /// </summary>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string path = hfldAttachData.Value;
            if (string.IsNullOrEmpty(path))
            {
                DialogHelper.ShowTipSuccessMsg("未获取到相关导入信息，请检查浏览器的JavaScript是否运行正常！", "", Page);
                return;
            }

            RemoveExistingRecordEntity record = codeBiz.ExcelImport(path, LoginUser);
            if (record.flag)
            {
                if (record.AddCount != record.SuccCount)
                {
                    DialogHelper.ShowDialogSuccessMsg(string.Format("操作成功！导入{0}条,成功{1}条，失败{2}条,<br/>失败行数：第{3}等！", record.AddCount, record.SuccCount, record.ErrorCount, record.Existstr), "", Page);
                }
                else
                {
                    DialogHelper.ShowTipSuccessMsg("导入成功！", "", Page);
                }

                BindrptMajorCodeList();//绑定专业代码列表
            }
            else
            {
                DialogHelper.ShowDialogErrorMsg(string.Format("操作失败！导入{0}条,失败{1}条,<br/>失败行数：第{2}等！", record.AddCount, record.ErrorCount, record.Existstr), "", Page);
            }
        }
    }
}