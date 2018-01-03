using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoWeiOnlineEducation.Entity
{
    /// <summary>
    /// JSON
    /// </summary>
    /// <typeparam name="T">类</typeparam>
    public class JsonEntity<T>
    {
        /// <summary>
        /// 返回自定义代码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public T data { get; set; }
    }
}
