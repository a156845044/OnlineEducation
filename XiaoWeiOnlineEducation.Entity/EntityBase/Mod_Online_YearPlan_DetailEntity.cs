using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Brilliant.ORM;

namespace XiaoWeiOnlineEducation.Entity
{
    /// <summary>
    /// 实体映射：年度招生计划详细
    /// </summary>
    [Serializable]
    public class Mod_Online_YearPlan_DetailEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Mod_Online_YearPlan_DetailEntity()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fkObject">外键实体对象</param>
        public Mod_Online_YearPlan_DetailEntity(EntityBase fkObject)
            : base(fkObject)
        {
        }

        /// <summary>
        /// 计划详细编号
        /// </summary>
        public string DetailId
        {
            get { return GetProperty<string>("DetailId"); }
            set { SetProperty("DetailId", value); }
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
        /// 报考类别编号
        /// </summary>
        public string AppTypeId
        {
            get { return GetProperty<string>("AppTypeId"); }
            set { SetProperty("AppTypeId", value); }
        }

        /// <summary>
        /// 报考类别名称
        /// </summary>
        public string AppTypeName
        {
            get { return GetProperty<string>("AppTypeName"); }
            set { SetProperty("AppTypeName", value); }
        }

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
        /// 学校专业编号
        /// </summary>
        public string SchoolMajorId
        {
            get { return GetProperty<string>("SchoolMajorId"); }
            set { SetProperty("SchoolMajorId", value); }
        }

        /// <summary>
        /// 学校专业名称
        /// </summary>
        public string SchoolMajorName
        {
            get { return GetProperty<string>("SchoolMajorName"); }
            set { SetProperty("SchoolMajorName", value); }
        }

        /// <summary>
        /// 计划数
        /// </summary>
        public int PlanNumber
        {
            get { return GetProperty<int>("PlanNumber"); }
            set { SetProperty("PlanNumber", value); }
        }

        /// <summary>
        /// 对报考者专科阶段所学专业等要求
        /// </summary>
        public string CandidateRequire
        {
            get { return GetProperty<string>("CandidateRequire"); }
            set { SetProperty("CandidateRequire", value); }
        }

        /// <summary>
        /// 专业课程要求
        /// </summary>
        public string MajorRequire
        {
            get { return GetProperty<string>("MajorRequire"); }
            set { SetProperty("MajorRequire", value); }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks
        {
            get { return GetProperty<string>("Remarks"); }
            set { SetProperty("Remarks", value); }
        }

        /// <summary>
        /// 投档分数
        /// </summary>
        public string CastScore
        {
            get { return GetProperty<string>("CastScore"); }
            set { SetProperty("CastScore", value); }
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