using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Brilliant.ORM;

namespace XiaoWeiOnlineEducation.Entity
{
    /// <summary>
    /// 实体映射：学校专业
    /// </summary>
    [Serializable]
    public class Mod_Online_School_MajorEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Mod_Online_School_MajorEntity()
        {
 
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fkObject">外键实体对象</param>
        public Mod_Online_School_MajorEntity(EntityBase fkObject)
            : base(fkObject)
        {
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