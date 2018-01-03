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
    /// 年度招生计划详细专业要求业务逻辑
    /// </summary>
    public class Mod_Online_YearPlan_Detail_MajorCodeBiz : Mod_Online_YearPlan_Detail_MajorCodeBizBase
    {
        /// <summary>
        /// 删除详细的专业代码（按照年度编号）
        /// </summary>
        /// <param name="yearId">年度编号</param>
        /// <param name="dp">数据库访问对象接口</param>
        /// <returns>执行结果</returns>
        public bool DelDetailMajorCode(string yearId, IDataProvider dp)
        {
            SQL sql = SQL.Build(" DELETE FROM Mod_Online_YearPlan_Detail_MajorCode WHERE YearId=?  ", yearId);
            return SqlMap<Mod_Online_YearPlan_Detail_MajorCodeEntity>.ParseSql(sql).Execute(dp) > 0;
        }
    }
}