using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoWeiOnlineEducation.Entity
{
    public class RemoveExistingRecordEntity
    {
        /// <summary>
        /// 执行结果
        /// </summary>
        public bool flag
        {
            get;
            set;
        }


        /// <summary>
        /// 添加个数
        /// </summary>
        public int AddCount
        {
            get;
            set;
        }


        /// <summary>
        /// 重复个数
        /// </summary>
        public int SuccCount
        {
            get;
            set;
        }

        /// <summary>
        /// 失败个数
        /// </summary>
        public int ErrorCount
        {
            get;
            set;
        }

        /// <summary>
        /// 重复记录
        /// </summary>
        public string Existstr
        {
            get;
            set;
        }
    }
}
