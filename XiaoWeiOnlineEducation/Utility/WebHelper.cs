using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace XiaoWeiOnlineEducation
{
    public class WebHelper
    {
        private static Encoding _encoding = System.Text.Encoding.GetEncoding("GB2312");

        /// <summary>
        /// 获取列表序号
        /// </summary>
        /// <param name="index">当前索引</param>
        /// <param name="pager">当前Pager对象</param>
        /// <returns>列表序号</returns>
        /// <remarks>作者：dfq 时间：2017-03-18</remarks>
        public static int GetItemIndex(int index, AspNetPager pager)
        {
            return (index + 1) + ((pager.CurrentPageIndex - 1) * pager.PageSize);
        }

        /// <summary>
        /// 获取分页控件总记录条数
        /// </summary>
        /// <param name="pager">当前Pager对象</param>
        /// <returns>总记录条数</returns>
        /// <remarks>作者：dfq 时间：2017-03-18</remarks>
        public static string GetPagerTotalCount(AspNetPager pager)
        {
            return string.Format("当前{0}/{1}页，共 {2} 条记录", pager.CurrentPageIndex, pager.PageCount, pager.RecordCount);
        }

        /// <summary>
        /// 获取空行
        /// </summary>
        /// <param name="rpt">Repeater 控件</param>
        /// <param name="colspan">合并列数</param>
        /// <returns>空行</returns>
        /// <remarks>作者：dfq 时间：2017-03-18</remarks>
        public static string GetEmptyRow(Repeater rpt, int colspan)
        {
            return rpt.Items.Count == 0 ? String.Format("<tr><td colspan=\"{0}\">未找到对应的记录!</td></tr>", colspan) : "";
        }

        /// <summary>
        /// 获取截取字段后的文字
        /// </summary>
        /// <param name="len">长度</param>
        /// <param name="obj">要截取的对象</param>
        /// <returns>截取字段后的文字</returns>
        /// <remarks>作者：dfq 时间：2017-03-18</remarks>
        public static string GetSubstringStr(int len, object obj)
        {

            string str = "";
            Byte[] bytes = Encoding.Default.GetBytes(obj.ToString());
            len = len * 2;
            if (bytes.Length > len)
            {
                str = string.Format("<span title=\"{0}\">{1}...<span>", obj, _encoding.GetString(bytes, 0, len));
            }
            else
            {
                str = obj.ToString();
            }
            return str;
        }

        /// <summary>
        /// 判断字段是否为空
        /// </summary>
        /// <param name="obj">字段</param>
        /// <param name="msg">为空时显示</param>
        /// <returns>字段的值</returns>
        /// <remarks>作者：dfq 时间：2017-03-18</remarks>
        public static object GetNULLStr(object obj, string msg = "暂无")
        {
            object desc = "";
            if (obj == null)
            {
                desc = msg;
            }
            else
            {
                if (string.IsNullOrEmpty(obj.ToString()))
                {
                    desc = msg;
                }
                else
                {
                    desc = obj;
                }

            }
            return desc;
        }
    }
}