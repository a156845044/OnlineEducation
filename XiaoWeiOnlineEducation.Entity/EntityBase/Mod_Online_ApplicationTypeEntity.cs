using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Brilliant.ORM;

namespace XiaoWeiOnlineEducation.Entity
{
    /// <summary>
    /// 实体映射：报考类型
    /// </summary>
    [Serializable]
    public class Mod_Online_ApplicationTypeEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Mod_Online_ApplicationTypeEntity()
        {
 
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fkObject">外键实体对象</param>
        public Mod_Online_ApplicationTypeEntity(EntityBase fkObject)
            : base(fkObject)
        {
        }

        /// <summary>
        /// 类型编号
        /// </summary>
        public string AppTypeId
        {
            get { return GetProperty<string>("AppTypeId"); }
			set { SetProperty("AppTypeId", value); }
        }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string AppTypeName
        {
            get { return GetProperty<string>("AppTypeName"); }
			set { SetProperty("AppTypeName", value); }
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