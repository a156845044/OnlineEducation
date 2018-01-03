using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Brilliant.ORM;

namespace XiaoWeiOnlineEducation.Entity
{
    /// <summary>
    /// 实体映射：年度招生计划
    /// </summary>
    [Serializable]
    public class Mod_Online_YearPlanEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Mod_Online_YearPlanEntity()
        {
 
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fkObject">外键实体对象</param>
        public Mod_Online_YearPlanEntity(EntityBase fkObject)
            : base(fkObject)
        {
        }

        /// <summary>
        /// 计划编号
        /// </summary>
        public string PlanId
        {
            get { return GetProperty<string>("PlanId"); }
			set { SetProperty("PlanId", value); }
        }

        /// <summary>
        /// 年度
        /// </summary>
        public int YearId
        {
            get { return GetProperty<int>("YearId"); }
			set { SetProperty("YearId", value); }
        }

        /// <summary>
        /// 计划名称
        /// </summary>
        public string PlanName
        {
            get { return GetProperty<string>("PlanName"); }
			set { SetProperty("PlanName", value); }
        }

        /// <summary>
        /// 状态标记
        /// </summary>
        public int StateFlag
        {
            get { return GetProperty<int>("StateFlag"); }
			set { SetProperty("StateFlag", value); }
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public int OrderIndex
        {
            get { return GetProperty<int>("OrderIndex"); }
			set { SetProperty("OrderIndex", value); }
        }

        /// <summary>
        /// 删除标记
        /// </summary>
        public int DeleteFlag
        {
            get { return GetProperty<int>("DeleteFlag"); }
			set { SetProperty("DeleteFlag", value); }
        }

        /// <summary>
        /// 扩展标记
        /// </summary>
        public int ExtFlag
        {
            get { return GetProperty<int>("ExtFlag"); }
			set { SetProperty("ExtFlag", value); }
        }

    }
}