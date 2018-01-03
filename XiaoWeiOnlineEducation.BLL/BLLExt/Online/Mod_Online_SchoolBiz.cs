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
    /// 报考学院业务逻辑
    /// </summary>
    public class Mod_Online_SchoolBiz : Mod_Online_SchoolBizBase
    {
        /// <summary>
        /// 获取学校列表
        /// </summary>
        /// <param name="shcoolNameStr">学校名称列表</param>
        /// <returns>学校列表</returns>
        public List<Mod_Online_SchoolEntity> GetSchoolList(string shcoolNameStr)
        {
            SQL sql = SQL.Format("SELECT * FROM Mod_Online_School WHERE SchoolName IN({0})", shcoolNameStr);
            return SqlMap<Mod_Online_SchoolEntity>.ParseSql(sql).ToList();
        }
    }
}