using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Brilliant.ORM;
using XiaoWeiOnlineEducation.Entity;

namespace XiaoWeiOnlineEducation.BLL
{
    /// <summary>
    /// 学校专业业务逻辑
    /// </summary>
    public class Mod_Online_School_MajorBiz : Mod_Online_School_MajorBizBase
    {
        /// <summary>
        /// 获取学校专业列表
        /// </summary>
        /// <param name="shcoolNameStr">学校专业名称列表</param>
        /// <returns>获取学校专业列表</returns>
        public List<Mod_Online_School_MajorEntity> GetSchoolMajorList(string schoolMajorNameStr)
        {
            SQL sql = SQL.Format("SELECT * FROM Mod_Online_School_Major WHERE SchoolMajorName IN({0})", schoolMajorNameStr);
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sql).ToList();
        }
    }
}