using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiaoWeiOnlineEducation.BLL;
using XiaoWeiOnlineEducation.Entity;

namespace XiaoWeiOnlineEducation.Handler
{
    /// <summary>
    /// Query 的摘要说明
    /// </summary>
    public class Query : Controller
    {
        /// <summary>
        /// 获取自动完成列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMajorCodeQueryList()
        {
            string key = Context.Request["term"];
            return Json(new Mod_Online_MajorCodeBiz().GetCodeQueryList(key));
        }

        /// <summary>
        /// 获取年度计划分数是否可以查询
        /// </summary>
        /// <returns></returns>
        public JsonResult GetNewYearPlanEnable()
        {
            bool flag = false;
            int year = DateTime.Now.Year;
            Mod_Online_YearPlanEntity model = new Mod_Online_YearPlanBiz().GetYearPlanModel(year.ToString());
            if (model == null)
            {
                flag = false;
            }
            else
            {
                if (model.StateFlag >= YearPlanSearchEnable.Open.ToInt())
                {
                    flag = true;
                }
            }
            return Json(flag);
        }

    }
}