using Brilliant.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoWeiOnlineEducation.Entity
{
    [Serializable]
    public class AutocompleteEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AutocompleteEntity()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fkObject">外键实体对象</param>
        public AutocompleteEntity(EntityBase fkObject)
            : base(fkObject)
        {
        }

        /// <summary>
        /// 类型编号
        /// </summary>
        public string label
        {
            get { return GetProperty<string>("label"); }
            set { SetProperty("label", value); }
        }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string value
        {
            get { return GetProperty<string>("value"); }
            set { SetProperty("value", value); }
        }
    }
}
