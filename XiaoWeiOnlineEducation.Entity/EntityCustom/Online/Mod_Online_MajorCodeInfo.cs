using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoWeiOnlineEducation.Entity
{
    public class Mod_Online_MajorCodeInfo : Mod_Online_MajorCodeEntity
    {
        /// <summary>
        /// 父类名称
        /// </summary>
        public string ParentName
        {
            get { return GetProperty<string>("ParentName"); }
            set { SetProperty("ParentName", value); }
        }

        /// <summary>
        /// 行号
        /// </summary>
        public int RowNumber
        {
            get;
            set;
        }
    }
}
