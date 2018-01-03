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
    /// 报考类型业务逻辑
    /// </summary>
    public abstract class Mod_Online_ApplicationTypeBizBase
    {
        /// <summary>
        /// 根据主键判断该记录是否存在
        /// </summary>
        /// <param name="appTypeId">类型编号</param>
        /// <returns>true：存在，false：不存在</returns>
        public virtual bool Exists(string appTypeId)
        {
            SQL sql = SQL.Build("SELECT COUNT(*) FROM Mod_Online_ApplicationType WHERE AppTypeId=?", appTypeId);
            return Convert.ToInt32(SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sql).First()) > 0;
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity">待添加的实体对象</param>
        /// <returns>true:添加成功 false:添加失败</returns>
        public virtual bool Add(Mod_Online_ApplicationTypeEntity entity)
        {
            SQL sql = SQL.Build("INSERT INTO Mod_Online_ApplicationType(AppTypeId,AppTypeName,StateFlag,OrderIndex,DeleteFlag,ExtFlag) VALUES(?,?,?,?,?,?)",  entity.AppTypeId, entity.AppTypeName, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag);
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity">待添加的实体对象</param>
        /// <returns>true:添加成功 false:添加失败</returns>
        public bool Add(Mod_Online_ApplicationTypeEntity entity, IDataProvider provider)
        {
            SQL sql = SQL.Build("INSERT INTO Mod_Online_ApplicationType(AppTypeId,AppTypeName,StateFlag,OrderIndex,DeleteFlag,ExtFlag) VALUES(?,?,?,?,?,?)",  entity.AppTypeId, entity.AppTypeName, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag);
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sql).Execute(provider) > 0;
        }

        /// <summary>
        /// 批量添加记录
        /// </summary>
        /// <param name="list">待添加的实体对象列表</param>
        /// <returns>true:添加成功 false:添加失败</returns>
        public virtual bool Add(List<Mod_Online_ApplicationTypeEntity> list)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_ApplicationTypeEntity entity in list)
            {
                SQL sql = SQL.Build("INSERT INTO Mod_Online_ApplicationType(AppTypeId,AppTypeName,StateFlag,OrderIndex,DeleteFlag,ExtFlag) VALUES(?,?,?,?,?,?)",  entity.AppTypeId, entity.AppTypeName, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sqlList).Execute() > 0;
        }

        /// <summary>
        /// 批量添加记录
        /// </summary>
        /// <param name="list">待添加的实体对象列表</param>
        /// <returns>true:添加成功 false:添加失败</returns>
        public bool Add(List<Mod_Online_ApplicationTypeEntity> list, IDataProvider provider)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_ApplicationTypeEntity entity in list)
            {
                SQL sql = SQL.Build("INSERT INTO Mod_Online_ApplicationType(AppTypeId,AppTypeName,StateFlag,OrderIndex,DeleteFlag,ExtFlag) VALUES(?,?,?,?,?,?)",  entity.AppTypeId, entity.AppTypeName, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sqlList).Execute(provider) > 0;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="entity">待更新的实体对象</param>
        /// <returns>true:更新成功 false:更新失败</returns>
        public virtual bool Update(Mod_Online_ApplicationTypeEntity entity)
        {
            SQL sql = SQL.Build("UPDATE Mod_Online_ApplicationType SET AppTypeName=?,StateFlag=?,OrderIndex=?,DeleteFlag=?,ExtFlag=? WHERE AppTypeId=?",  entity.AppTypeName, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag, entity.AppTypeId);
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="entity">待更新的实体对象</param>
        /// <returns>true:更新成功 false:更新失败</returns>
        public bool Update(Mod_Online_ApplicationTypeEntity entity, IDataProvider provider)
        {
            SQL sql = SQL.Build("UPDATE Mod_Online_ApplicationType SET AppTypeName=?,StateFlag=?,OrderIndex=?,DeleteFlag=?,ExtFlag=? WHERE AppTypeId=?",  entity.AppTypeName, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag, entity.AppTypeId);
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sql).Execute(provider) > 0;
        }

        /// <summary>
        /// 批量更新记录
        /// </summary>
        /// <param name="list">待更新的实体对象列表</param>
        /// <returns>true:更新成功 false:更新失败</returns>
        public virtual bool Update(List<Mod_Online_ApplicationTypeEntity> list)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_ApplicationTypeEntity entity in list)
            {
                SQL sql = SQL.Build("UPDATE Mod_Online_ApplicationType SET AppTypeName=?,StateFlag=?,OrderIndex=?,DeleteFlag=?,ExtFlag=? WHERE AppTypeId=?",  entity.AppTypeName, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag, entity.AppTypeId);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sqlList).Execute() > 0;
        }

        /// <summary>
        /// 批量更新记录
        /// </summary>
        /// <param name="list">待更新的实体对象列表</param>
        /// <returns>true:更新成功 false:更新失败</returns>
        public bool Update(List<Mod_Online_ApplicationTypeEntity> list, IDataProvider provider)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_ApplicationTypeEntity entity in list)
            {
                SQL sql = SQL.Build("UPDATE Mod_Online_ApplicationType SET AppTypeName=?,StateFlag=?,OrderIndex=?,DeleteFlag=?,ExtFlag=? WHERE AppTypeId=?",  entity.AppTypeName, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag, entity.AppTypeId);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sqlList).Execute(provider) > 0;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="appTypeId">类型编号</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public virtual bool Delete(string appTypeId)
        {
            SQL sql = SQL.Build("DELETE FROM Mod_Online_ApplicationType WHERE AppTypeId=?", appTypeId);
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="appTypeId">类型编号</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public bool Delete(string appTypeId, IDataProvider provider)
        {
            SQL sql = SQL.Build("DELETE FROM Mod_Online_ApplicationType WHERE AppTypeId=?", appTypeId);
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sql).Execute(provider) > 0;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="entity">待删除的实体对象</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public virtual bool Delete(Mod_Online_ApplicationTypeEntity entity)
        {
            SQL sql = SQL.Build("DELETE FROM Mod_Online_ApplicationType WHERE AppTypeId=?", entity.AppTypeId);
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 批量删除记录
        /// </summary>
        /// <param name="list">待删除的实体对象列表</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public virtual bool Delete(List<Mod_Online_ApplicationTypeEntity> list)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_ApplicationTypeEntity entity in list)
            {
                SQL sql = SQL.Build("DELETE FROM Mod_Online_ApplicationType WHERE AppTypeId=?", entity.AppTypeId);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sqlList).Execute() > 0;
        }

        /// <summary>
        /// 批量删除记录
        /// </summary>
        /// <param name="list">待删除的实体对象列表</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public bool Delete(List<Mod_Online_ApplicationTypeEntity> list, IDataProvider provider)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_ApplicationTypeEntity entity in list)
            {
                SQL sql = SQL.Build("DELETE FROM Mod_Online_ApplicationType WHERE AppTypeId=?", entity.AppTypeId);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sqlList).Execute(provider) > 0;
        }

        /// <summary>
        /// 根据主键获取实体对象
        /// </summary>
        /// <param name="appTypeId">类型编号</param>
        /// <returns>实体对象</returns>
        public virtual Mod_Online_ApplicationTypeEntity GetModel(string appTypeId)
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_ApplicationType WHERE AppTypeId=?", appTypeId);
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sql).ToObject();
        }
  
        /// <summary>
        /// 根据主键获取Json对象
        /// </summary>
        /// <param name="appTypeId">类型编号</param>
        /// <returns>Json对象</returns>
        public virtual string GetJsonModel(string appTypeId)
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_ApplicationType WHERE AppTypeId=?", appTypeId);
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sql).ToJsonObject();
        }

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <returns>对象列表</returns>
        public virtual List<Mod_Online_ApplicationTypeEntity> GetList()
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_ApplicationType");
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sql).ToList();
        }
        
        /// <summary>
        /// 获取Json对象列表
        /// </summary>
        /// <returns>Json对象列表</returns>
        public virtual string GetJsonList()
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_ApplicationType");
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sql).ToJsonList();
        }

        /// <summary>
        /// 获取分页后对象列表
        /// </summary>
        /// <param name="pageSize">每页显示的记录条数</param>
        /// <param name="pageNumber">当前页索引</param>
        /// <param name="recordCount">总记录条数</param>
        /// <returns>分页后对象列表</returns>
        public virtual List<Mod_Online_ApplicationTypeEntity> GetList(int pageSize, int pageNumber, out int recordCount)
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_ApplicationType").Limit(pageSize, pageNumber);
            recordCount = sql.RecordCount;
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sql).ToList();
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
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_ApplicationType").Limit(pageSize, pageNumber);
            recordCount = sql.RecordCount;
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sql).ToJsonList();
        }
    }
}