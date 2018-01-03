using Brilliant.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XiaoWeiOnlineEducation.BLL;
using XiaoWeiOnlineEducation.Entity;

namespace XiaoWeiOnlineEducation.Webs.config
{
    public partial class CreateDataMgr : Filter.LoginFilter
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
        /// 创建报考类型
        /// </summary>
        protected void btnCreateApplicationType_Click(object sender, EventArgs e)
        {
            List<Mod_Online_ApplicationTypeEntity> list = new List<Mod_Online_ApplicationTypeEntity>();
            string[] types = new string[] { "文科类", "理工科类", "英语类", "日语类", "艺术类", "体育类" };
            foreach (string item in types)
            {
                Mod_Online_ApplicationTypeEntity model = new Mod_Online_ApplicationTypeEntity();
                model.AppTypeId = StringHelper.GetGuid();
                model.AppTypeName = item;
                list.Add(model);
            }
            Mod_Online_ApplicationTypeBiz typeBiz = new Mod_Online_ApplicationTypeBiz();
            typeBiz.RemoveExistingRecord(list);
            if (typeBiz.Add(list))
            {
                DialogHelper.ShowTipSuccessMsg("添加报考类型成功！", "", Page);
            }
            else
            {
                DialogHelper.ShowTipErrorMsg("添加报考类型失败！", "", Page);
            }
        }
    }
}