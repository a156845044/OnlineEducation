using Brilliant.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoWeiOnlineEducation.Entity.EntityCustom.Online
{
    public class PlanDetailSearchEntity : EntityBase
    {
        /// <summary>
        /// 学校编号
        /// </summary>
        public string SchoolId
        {
            get { return GetProperty<string>("SchoolId"); }
            set { SetProperty("SchoolId", value); }
        }

        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchoolName
        {
            get { return GetProperty<string>("SchoolName"); }
            set { SetProperty("SchoolName", value); }
        }

        /// <summary>
        /// 学校类型（0：公办 1：私办）
        /// </summary>
        public int SchoolType
        {
            get { return GetProperty<int>("SchoolType"); }
            set { SetProperty("SchoolType", value); }
        }

        /// <summary>
        /// 专业列表
        /// </summary>
        public List<Mod_Online_YearPlan_DetailEntityExt> ChildList { get; set; }
    }
}
