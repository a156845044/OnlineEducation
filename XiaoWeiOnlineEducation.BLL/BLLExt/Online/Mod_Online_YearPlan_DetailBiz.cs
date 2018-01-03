using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Brilliant.ORM;
using XiaoWeiOnlineEducation.Entity;
using Brilliant.Utility;

namespace XiaoWeiOnlineEducation.BLL
{
    /// <summary>
    /// 年度招生计划详细业务逻辑
    /// </summary>
    public class Mod_Online_YearPlan_DetailBiz : Mod_Online_YearPlan_DetailBizBase
    {
        /// <summary>
        /// 根据年度编号获取计划详细列表
        /// </summary>
        /// <param name="planId">计划详细列表</param>
        /// <returns>计划详细列表</returns>
        public List<Mod_Online_YearPlan_DetailEntity> GetYearPlanList(string planId)
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_YearPlan_Detail WHERE PlanId=? ", planId);
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sql).ToList();
        }

        /// <summary>
        /// 更新详细
        /// </summary>
        /// <param name="list">待更新的列表</param>
        /// <param name="dp">数据库访问对象接口</param>
        /// <returns>执行结果</returns>
        public bool UpdateDetail(List<Mod_Online_YearPlan_DetailEntity> list, IDataProvider dp)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_YearPlan_DetailEntity entity in list)
            {
                sqlList.Add(SQL.Build("UPDATE Mod_Online_YearPlan_Detail SET AppTypeId=?,AppTypeName=?,SchoolId=?,SchoolName=?,SchoolType=?,SchoolMajorId=?,SchoolMajorName=?,PlanNumber=?,MajorRequire=?,Remarks=?,CastScore=? WHERE DetailId=?", entity.AppTypeId, entity.AppTypeName, entity.SchoolId, entity.SchoolName, entity.SchoolType, entity.SchoolMajorId, entity.SchoolMajorName, entity.PlanNumber, entity.MajorRequire, entity.Remarks, entity.CastScore, entity.DetailId));
            }
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sqlList).Execute(dp) > 0;
        }

        /// <summary>
        /// 删除详细的专业代码（按照年度编号）
        /// </summary>
        /// <param name="yearId">年度编号</param>
        /// <param name="dp">数据库访问对象接口</param>
        /// <returns>执行结果</returns>
        public bool DelDetail(string yearId, IDataProvider dp)
        {
            SQL sql = SQL.Build(" DELETE FROM Mod_Online_YearPlan_Detail WHERE YearId=?  ", yearId);
            return SqlMap<Mod_Online_YearPlan_Detail_MajorCodeEntity>.ParseSql(sql).Execute(dp) > 0;
        }

        /// <summary>
        /// 获取详细列表
        /// </summary>
        /// <param name="planId">计划编号</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageNum">当前页码</param>
        /// <param name="recordCount">总记录条数</param>
        /// <returns>详细列表</returns>
        public List<Mod_Online_YearPlan_DetailEntity> GetList(string planId, string keyword, int pageSize, int pageNum, out int recordCount)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append(" SELECT * FROM Mod_Online_YearPlan_Detail  ");
            strSQL.Append(" WHERE  PlanId=? ");
            if (!string.IsNullOrEmpty(keyword))
            {
                if (ValidateHelper.IsSafeSqlString(keyword))
                {
                    string keyValue = string.Format("'%{0}%'", keyword);
                    strSQL.Append(" AND (  ");
                    strSQL.AppendFormat(" AppTypeName LIKE ({0}) ", keyValue);
                    strSQL.AppendFormat(" OR SchoolName LIKE ({0}) ", keyValue);
                    strSQL.AppendFormat(" OR SchoolMajorName LIKE ({0}) ", keyValue);
                    strSQL.AppendFormat(" OR PlanNumber LIKE ({0}) ", keyValue);
                    strSQL.AppendFormat(" OR CandidateRequire LIKE ({0}) ", keyValue);
                    strSQL.Append("  ) ");
                }
            }
            strSQL.Append(" ORDER BY SchoolId  ");
            SQL sql = SQL.Build(strSQL.ToString(), planId).Limit(pageSize, pageNum);
            recordCount = sql.RecordCount;
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sql).ToList();
        }

        /// <summary>
        /// 获取详细信息查询列表
        /// </summary>
        /// <param name="yearId">年度</param>
        /// <param name="code">专业代码</param>
        /// <param name="typeId">报考类型</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageNum">当前页码</param>
        /// <param name="recordCount">总记录条数</param>
        /// <returns>信息查询列表</returns>
        public List<Mod_Online_YearPlan_DetailEntityExt> GetQueryList(int yearId, string code, string typeId, string keyword, int pageSize, int pageNum, out int recordCount)
        {
            string tempCommon = "(SELECT TOP 1 CastScore FROM Mod_Online_YearPlan_Detail WHERE Mod_Online_YearPlan_Detail.YearId={0}  AND Mod_Online_YearPlan_Detail.SchoolId =MOYD.SchoolId AND Mod_Online_YearPlan_Detail.SchoolMajorId =MOYD.SchoolMajorId  AND Mod_Online_YearPlan_Detail.AppTypeId =MOYD.AppTypeId ) ";

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append(" SELECT MOYD.*,  ");
            strSQL.AppendFormat(tempCommon, yearId - 1);
            strSQL.Append(" AS LastYearScore, ");
            strSQL.AppendFormat(tempCommon, yearId - 2);
            strSQL.Append(" AS TwoYearsAgoScore, ");
            strSQL.AppendFormat(tempCommon, yearId - 3);
            strSQL.Append(" AS ThreeYearsAgoScore ");
            strSQL.Append(" FROM Mod_Online_YearPlan_Detail MOYD ");
            strSQL.Append(" WHERE  MOYD.YearId=? ");
            strSQL.Append(" AND MOYD.AppTypeId=? ");
            strSQL.Append(" AND MOYD.DetailId IN (SELECT MOYPDMC.DetailId FROM Mod_Online_YearPlan_Detail_MajorCode MOYPDMC WHERE MOYPDMC.PlanId = MOYD.PlanId AND ");
            strSQL.AppendFormat(" MOYPDMC.CodeId LIKE ('{0}%') ) ", code);
            if (!string.IsNullOrEmpty(keyword))
            {
                if (ValidateHelper.IsSafeSqlString(keyword))
                {
                    string keyValue = string.Format("'%{0}%'", keyword);
                    strSQL.Append(" AND (  ");
                    strSQL.AppendFormat(" MOYD.AppTypeName LIKE ({0}) ", keyValue);
                    strSQL.AppendFormat(" OR MOYD.SchoolName LIKE ({0}) ", keyValue);
                    strSQL.AppendFormat(" OR MOYD.SchoolMajorName LIKE ({0}) ", keyValue);
                    strSQL.AppendFormat(" OR MOYD.PlanNumber LIKE ({0}) ", keyValue);
                    strSQL.AppendFormat(" OR MOYD.CandidateRequire LIKE ({0}) ", keyValue);
                    strSQL.Append("  ) ");
                }
            }
            strSQL.Append(" ORDER BY MOYD.SchoolId  ");
            SQL sql = SQL.Build(strSQL.ToString(), yearId, typeId).Limit(pageSize, pageNum);
            recordCount = sql.RecordCount;
            return SqlMap<Mod_Online_YearPlan_DetailEntityExt>.ParseSql(sql).ToList();
        }

        /// <summary>
        /// 获取分数详细信息查询列表
        /// </summary>
        /// <param name="yearId">年度</param>
        /// <param name="code">专业代码</param>
        /// <param name="typeId">报考类型</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageNum">当前页码</param>
        /// <param name="recordCount">总记录条数</param>
        /// <returns>信息查询列表</returns>
        public List<Mod_Online_YearPlan_DetailEntityExt> GetScoreQueryList(int yearId, string code, string typeId, string keyword, int pageSize, int pageNum, out int recordCount)
        {
            string tempCommon = "(SELECT TOP 1 CastScore FROM Mod_Online_YearPlan_Detail WHERE Mod_Online_YearPlan_Detail.YearId={0}  AND Mod_Online_YearPlan_Detail.SchoolId =MOYD.SchoolId AND Mod_Online_YearPlan_Detail.SchoolMajorId =MOYD.SchoolMajorId  AND Mod_Online_YearPlan_Detail.AppTypeId =MOYD.AppTypeId ) ";

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append(" SELECT MOYD.*,  ");
            strSQL.AppendFormat(tempCommon, yearId - 1);
            strSQL.Append(" AS LastYearScore, ");
            strSQL.AppendFormat(tempCommon, yearId - 2);
            strSQL.Append(" AS TwoYearsAgoScore, ");
            strSQL.AppendFormat(tempCommon, yearId - 3);
            strSQL.Append(" AS ThreeYearsAgoScore ");
            strSQL.Append(" FROM Mod_Online_YearPlan_Detail MOYD ");
            strSQL.Append(" WHERE  MOYD.YearId=? ");
            strSQL.Append(" AND MOYD.AppTypeId=? ");
            strSQL.Append(" AND MOYD.CastScore >0 ");
            strSQL.Append(" AND MOYD.DetailId IN (SELECT MOYPDMC.DetailId FROM Mod_Online_YearPlan_Detail_MajorCode MOYPDMC WHERE MOYPDMC.PlanId = MOYD.PlanId AND ");
            strSQL.AppendFormat(" MOYPDMC.CodeId LIKE ('{0}%') ) ", code);
            if (!string.IsNullOrEmpty(keyword))
            {
                if (ValidateHelper.IsSafeSqlString(keyword))
                {
                    string keyValue = string.Format("'%{0}%'", keyword);
                    strSQL.Append(" AND (  ");
                    strSQL.AppendFormat(" MOYD.AppTypeName LIKE ({0}) ", keyValue);
                    strSQL.AppendFormat(" OR MOYD.SchoolName LIKE ({0}) ", keyValue);
                    strSQL.AppendFormat(" OR MOYD.SchoolMajorName LIKE ({0}) ", keyValue);
                    strSQL.AppendFormat(" OR MOYD.PlanNumber LIKE ({0}) ", keyValue);
                    strSQL.AppendFormat(" OR MOYD.CandidateRequire LIKE ({0}) ", keyValue);
                    strSQL.Append("  ) ");
                }
            }
            strSQL.Append(" ORDER BY MOYD.SchoolId  ");
            SQL sql = SQL.Build(strSQL.ToString(), yearId, typeId).Limit(pageSize, pageNum);
            recordCount = sql.RecordCount;
            return SqlMap<Mod_Online_YearPlan_DetailEntityExt>.ParseSql(sql).ToList();
        }
    }
}