using Brilliant.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoWeiOnlineEducation.Entity
{
    /// <summary>
    /// 下拉框实体
    /// </summary>
    [Serializable]
    public class DropdownListItem : EntityBase
    {
        // <summary>
        /// 显示的文本
        /// </summary>
        public string DataTextField
        {
            get { return GetProperty<string>("DataTextField"); }
            set { SetProperty("DataTextField", value); }
        }

        /// <summary>
        /// 显示文本对应的值
        /// </summary>
        public string DataValueField
        {
            get { return GetProperty<string>("DataValueField"); }
            set { SetProperty("DataValueField", value); }
        }
    }

    /// <summary>
    /// 根据值本列表内去重
    /// </summary>
    /// <remarks>作者：dfq 时间：2016-08-26</remarks>
    public class DistinctBy_DataValueField : IEqualityComparer<DropdownListItem>
    {
        public bool Equals(DropdownListItem x, DropdownListItem y)
        {
            if (x.DataValueField == y.DataValueField)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(DropdownListItem obj)
        {
            return 0;
        }
    }
}
