using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Brilliant.ORM;

namespace XiaoWeiOnlineEducation.Entity
{
    /// <summary>
    /// 实体映射：报考学院
    /// </summary>
    [Serializable]
    public class Mod_Online_SchoolEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Mod_Online_SchoolEntity()
        {
 
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fkObject">外键实体对象</param>
        public Mod_Online_SchoolEntity(EntityBase fkObject)
            : base(fkObject)
        {
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