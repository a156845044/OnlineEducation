﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Brilliant.ORM;
using XiaoWeiOnlineEducation.Entity;

namespace XiaoWeiOnlineEducation.BLL
{
    /// <summary>
    /// 年度招生计划详细业务逻辑
    /// </summary>
    public abstract class Mod_Online_YearPlan_DetailBizBase
    {
        /// <summary>
        /// 根据主键判断该记录是否存在
        /// </summary>
        /// <param name="detailId">计划详细编号</param>
        /// <returns>true：存在，false：不存在</returns>
        public virtual bool Exists(string detailId)
        {
            SQL sql = SQL.Build("SELECT COUNT(*) FROM Mod_Online_YearPlan_Detail WHERE DetailId=?", detailId);
            return Convert.ToInt32(SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sql).First()) > 0;
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity">待添加的实体对象</param>
        /// <returns>true:添加成功 false:添加失败</returns>
        public virtual bool Add(Mod_Online_YearPlan_DetailEntity entity)
        {
            SQL sql = SQL.Build("INSERT INTO Mod_Online_YearPlan_Detail(DetailId,PlanId,YearId,AppTypeId,AppTypeName,SchoolId,SchoolName,SchoolType,SchoolMajorId,SchoolMajorName,PlanNumber,CandidateRequire,MajorRequire,Remarks,CastScore,StateFlag,OrderIndex,DeleteFlag,ExtFlag) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)",  entity.DetailId, entity.PlanId, entity.YearId, entity.AppTypeId, entity.AppTypeName, entity.SchoolId, entity.SchoolName, entity.SchoolType, entity.SchoolMajorId, entity.SchoolMajorName, entity.PlanNumber, entity.CandidateRequire, entity.MajorRequire, entity.Remarks, entity.CastScore, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag);
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity">待添加的实体对象</param>
        /// <returns>true:添加成功 false:添加失败</returns>
        public bool Add(Mod_Online_YearPlan_DetailEntity entity, IDataProvider provider)
        {
            SQL sql = SQL.Build("INSERT INTO Mod_Online_YearPlan_Detail(DetailId,PlanId,YearId,AppTypeId,AppTypeName,SchoolId,SchoolName,SchoolType,SchoolMajorId,SchoolMajorName,PlanNumber,CandidateRequire,MajorRequire,Remarks,CastScore,StateFlag,OrderIndex,DeleteFlag,ExtFlag) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)",  entity.DetailId, entity.PlanId, entity.YearId, entity.AppTypeId, entity.AppTypeName, entity.SchoolId, entity.SchoolName, entity.SchoolType, entity.SchoolMajorId, entity.SchoolMajorName, entity.PlanNumber, entity.CandidateRequire, entity.MajorRequire, entity.Remarks, entity.CastScore, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag);
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sql).Execute(provider) > 0;
        }

        /// <summary>
        /// 批量添加记录
        /// </summary>
        /// <param name="list">待添加的实体对象列表</param>
        /// <returns>true:添加成功 false:添加失败</returns>
        public virtual bool Add(List<Mod_Online_YearPlan_DetailEntity> list)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_YearPlan_DetailEntity entity in list)
            {
                SQL sql = SQL.Build("INSERT INTO Mod_Online_YearPlan_Detail(DetailId,PlanId,YearId,AppTypeId,AppTypeName,SchoolId,SchoolName,SchoolType,SchoolMajorId,SchoolMajorName,PlanNumber,CandidateRequire,MajorRequire,Remarks,CastScore,StateFlag,OrderIndex,DeleteFlag,ExtFlag) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)",  entity.DetailId, entity.PlanId, entity.YearId, entity.AppTypeId, entity.AppTypeName, entity.SchoolId, entity.SchoolName, entity.SchoolType, entity.SchoolMajorId, entity.SchoolMajorName, entity.PlanNumber, entity.CandidateRequire, entity.MajorRequire, entity.Remarks, entity.CastScore, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sqlList).Execute() > 0;
        }

        /// <summary>
        /// 批量添加记录
        /// </summary>
        /// <param name="list">待添加的实体对象列表</param>
        /// <returns>true:添加成功 false:添加失败</returns>
        public bool Add(List<Mod_Online_YearPlan_DetailEntity> list, IDataProvider provider)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_YearPlan_DetailEntity entity in list)
            {
                SQL sql = SQL.Build("INSERT INTO Mod_Online_YearPlan_Detail(DetailId,PlanId,YearId,AppTypeId,AppTypeName,SchoolId,SchoolName,SchoolType,SchoolMajorId,SchoolMajorName,PlanNumber,CandidateRequire,MajorRequire,Remarks,CastScore,StateFlag,OrderIndex,DeleteFlag,ExtFlag) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)",  entity.DetailId, entity.PlanId, entity.YearId, entity.AppTypeId, entity.AppTypeName, entity.SchoolId, entity.SchoolName, entity.SchoolType, entity.SchoolMajorId, entity.SchoolMajorName, entity.PlanNumber, entity.CandidateRequire, entity.MajorRequire, entity.Remarks, entity.CastScore, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sqlList).Execute(provider) > 0;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="entity">待更新的实体对象</param>
        /// <returns>true:更新成功 false:更新失败</returns>
        public virtual bool Update(Mod_Online_YearPlan_DetailEntity entity)
        {
            SQL sql = SQL.Build("UPDATE Mod_Online_YearPlan_Detail SET PlanId=?,YearId=?,AppTypeId=?,AppTypeName=?,SchoolId=?,SchoolName=?,SchoolType=?,SchoolMajorId=?,SchoolMajorName=?,PlanNumber=?,CandidateRequire=?,MajorRequire=?,Remarks=?,CastScore=?,StateFlag=?,OrderIndex=?,DeleteFlag=?,ExtFlag=? WHERE DetailId=?",  entity.PlanId, entity.YearId, entity.AppTypeId, entity.AppTypeName, entity.SchoolId, entity.SchoolName, entity.SchoolType, entity.SchoolMajorId, entity.SchoolMajorName, entity.PlanNumber, entity.CandidateRequire, entity.MajorRequire, entity.Remarks, entity.CastScore, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag, entity.DetailId);
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="entity">待更新的实体对象</param>
        /// <returns>true:更新成功 false:更新失败</returns>
        public bool Update(Mod_Online_YearPlan_DetailEntity entity, IDataProvider provider)
        {
            SQL sql = SQL.Build("UPDATE Mod_Online_YearPlan_Detail SET PlanId=?,YearId=?,AppTypeId=?,AppTypeName=?,SchoolId=?,SchoolName=?,SchoolType=?,SchoolMajorId=?,SchoolMajorName=?,PlanNumber=?,CandidateRequire=?,MajorRequire=?,Remarks=?,CastScore=?,StateFlag=?,OrderIndex=?,DeleteFlag=?,ExtFlag=? WHERE DetailId=?",  entity.PlanId, entity.YearId, entity.AppTypeId, entity.AppTypeName, entity.SchoolId, entity.SchoolName, entity.SchoolType, entity.SchoolMajorId, entity.SchoolMajorName, entity.PlanNumber, entity.CandidateRequire, entity.MajorRequire, entity.Remarks, entity.CastScore, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag, entity.DetailId);
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sql).Execute(provider) > 0;
        }

        /// <summary>
        /// 批量更新记录
        /// </summary>
        /// <param name="list">待更新的实体对象列表</param>
        /// <returns>true:更新成功 false:更新失败</returns>
        public virtual bool Update(List<Mod_Online_YearPlan_DetailEntity> list)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_YearPlan_DetailEntity entity in list)
            {
                SQL sql = SQL.Build("UPDATE Mod_Online_YearPlan_Detail SET PlanId=?,YearId=?,AppTypeId=?,AppTypeName=?,SchoolId=?,SchoolName=?,SchoolType=?,SchoolMajorId=?,SchoolMajorName=?,PlanNumber=?,CandidateRequire=?,MajorRequire=?,Remarks=?,CastScore=?,StateFlag=?,OrderIndex=?,DeleteFlag=?,ExtFlag=? WHERE DetailId=?",  entity.PlanId, entity.YearId, entity.AppTypeId, entity.AppTypeName, entity.SchoolId, entity.SchoolName, entity.SchoolType, entity.SchoolMajorId, entity.SchoolMajorName, entity.PlanNumber, entity.CandidateRequire, entity.MajorRequire, entity.Remarks, entity.CastScore, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag, entity.DetailId);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sqlList).Execute() > 0;
        }

        /// <summary>
        /// 批量更新记录
        /// </summary>
        /// <param name="list">待更新的实体对象列表</param>
        /// <returns>true:更新成功 false:更新失败</returns>
        public bool Update(List<Mod_Online_YearPlan_DetailEntity> list, IDataProvider provider)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_YearPlan_DetailEntity entity in list)
            {
                SQL sql = SQL.Build("UPDATE Mod_Online_YearPlan_Detail SET PlanId=?,YearId=?,AppTypeId=?,AppTypeName=?,SchoolId=?,SchoolName=?,SchoolType=?,SchoolMajorId=?,SchoolMajorName=?,PlanNumber=?,CandidateRequire=?,MajorRequire=?,Remarks=?,CastScore=?,StateFlag=?,OrderIndex=?,DeleteFlag=?,ExtFlag=? WHERE DetailId=?",  entity.PlanId, entity.YearId, entity.AppTypeId, entity.AppTypeName, entity.SchoolId, entity.SchoolName, entity.SchoolType, entity.SchoolMajorId, entity.SchoolMajorName, entity.PlanNumber, entity.CandidateRequire, entity.MajorRequire, entity.Remarks, entity.CastScore, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag, entity.DetailId);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sqlList).Execute(provider) > 0;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="detailId">计划详细编号</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public virtual bool Delete(string detailId)
        {
            SQL sql = SQL.Build("DELETE FROM Mod_Online_YearPlan_Detail WHERE DetailId=?", detailId);
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="detailId">计划详细编号</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public bool Delete(string detailId, IDataProvider provider)
        {
            SQL sql = SQL.Build("DELETE FROM Mod_Online_YearPlan_Detail WHERE DetailId=?", detailId);
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sql).Execute(provider) > 0;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="entity">待删除的实体对象</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public virtual bool Delete(Mod_Online_YearPlan_DetailEntity entity)
        {
            SQL sql = SQL.Build("DELETE FROM Mod_Online_YearPlan_Detail WHERE DetailId=?", entity.DetailId);
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 批量删除记录
        /// </summary>
        /// <param name="list">待删除的实体对象列表</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public virtual bool Delete(List<Mod_Online_YearPlan_DetailEntity> list)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_YearPlan_DetailEntity entity in list)
            {
                SQL sql = SQL.Build("DELETE FROM Mod_Online_YearPlan_Detail WHERE DetailId=?", entity.DetailId);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sqlList).Execute() > 0;
        }

        /// <summary>
        /// 批量删除记录
        /// </summary>
        /// <param name="list">待删除的实体对象列表</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public bool Delete(List<Mod_Online_YearPlan_DetailEntity> list, IDataProvider provider)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_YearPlan_DetailEntity entity in list)
            {
                SQL sql = SQL.Build("DELETE FROM Mod_Online_YearPlan_Detail WHERE DetailId=?", entity.DetailId);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sqlList).Execute(provider) > 0;
        }

        /// <summary>
        /// 根据主键获取实体对象
        /// </summary>
        /// <param name="detailId">计划详细编号</param>
        /// <returns>实体对象</returns>
        public virtual Mod_Online_YearPlan_DetailEntity GetModel(string detailId)
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_YearPlan_Detail WHERE DetailId=?", detailId);
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sql).ToObject();
        }
  
        /// <summary>
        /// 根据主键获取Json对象
        /// </summary>
        /// <param name="detailId">计划详细编号</param>
        /// <returns>Json对象</returns>
        public virtual string GetJsonModel(string detailId)
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_YearPlan_Detail WHERE DetailId=?", detailId);
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sql).ToJsonObject();
        }

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <returns>对象列表</returns>
        public virtual List<Mod_Online_YearPlan_DetailEntity> GetList()
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_YearPlan_Detail");
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sql).ToList();
        }
        
        /// <summary>
        /// 获取Json对象列表
        /// </summary>
        /// <returns>Json对象列表</returns>
        public virtual string GetJsonList()
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_YearPlan_Detail");
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sql).ToJsonList();
        }

        /// <summary>
        /// 获取分页后对象列表
        /// </summary>
        /// <param name="pageSize">每页显示的记录条数</param>
        /// <param name="pageNumber">当前页索引</param>
        /// <param name="recordCount">总记录条数</param>
        /// <returns>分页后对象列表</returns>
        public virtual List<Mod_Online_YearPlan_DetailEntity> GetList(int pageSize, int pageNumber, out int recordCount)
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_YearPlan_Detail").Limit(pageSize, pageNumber);
            recordCount = sql.RecordCount;
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sql).ToList();
        }

        /// <summary>
        /// 获取分页后Json对象列表
        /// </summary>
        /// <param name="pageSize">每页显示的记录条数</param>
        /// <param name="pageNumber">当前页索引</param>
        /// <param name="recordCount">总记录条数</param>
        /// <returns>页后Json对象列表</returns>
        public virtual string GetJsonList(int pageSize, int pageNumber, out int recordCount)
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_YearPlan_Detail").Limit(pageSize, pageNumber);
            recordCount = sql.RecordCount;
            return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sql).ToJsonList();
        }
    }
}