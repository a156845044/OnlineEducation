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
    public abstract class Mod_Online_School_MajorBizBase
    {
        /// <summary>
        /// 根据主键判断该记录是否存在
        /// </summary>
        /// <param name="schoolMajorId">学校专业编号</param>
        /// <returns>true：存在，false：不存在</returns>
        public virtual bool Exists(string schoolMajorId)
        {
            SQL sql = SQL.Build("SELECT COUNT(*) FROM Mod_Online_School_Major WHERE SchoolMajorId=?", schoolMajorId);
            return Convert.ToInt32(SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sql).First()) > 0;
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity">待添加的实体对象</param>
        /// <returns>true:添加成功 false:添加失败</returns>
        public virtual bool Add(Mod_Online_School_MajorEntity entity)
        {
            SQL sql = SQL.Build("INSERT INTO Mod_Online_School_Major(SchoolMajorId,SchoolMajorName,SchoolId,SchoolName,StateFlag,OrderIndex,DeleteFlag,ExtFlag) VALUES(?,?,?,?,?,?,?,?)",  entity.SchoolMajorId, entity.SchoolMajorName, entity.SchoolId, entity.SchoolName, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag);
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity">待添加的实体对象</param>
        /// <returns>true:添加成功 false:添加失败</returns>
        public bool Add(Mod_Online_School_MajorEntity entity, IDataProvider provider)
        {
            SQL sql = SQL.Build("INSERT INTO Mod_Online_School_Major(SchoolMajorId,SchoolMajorName,SchoolId,SchoolName,StateFlag,OrderIndex,DeleteFlag,ExtFlag) VALUES(?,?,?,?,?,?,?,?)",  entity.SchoolMajorId, entity.SchoolMajorName, entity.SchoolId, entity.SchoolName, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag);
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sql).Execute(provider) > 0;
        }

        /// <summary>
        /// 批量添加记录
        /// </summary>
        /// <param name="list">待添加的实体对象列表</param>
        /// <returns>true:添加成功 false:添加失败</returns>
        public virtual bool Add(List<Mod_Online_School_MajorEntity> list)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_School_MajorEntity entity in list)
            {
                SQL sql = SQL.Build("INSERT INTO Mod_Online_School_Major(SchoolMajorId,SchoolMajorName,SchoolId,SchoolName,StateFlag,OrderIndex,DeleteFlag,ExtFlag) VALUES(?,?,?,?,?,?,?,?)",  entity.SchoolMajorId, entity.SchoolMajorName, entity.SchoolId, entity.SchoolName, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sqlList).Execute() > 0;
        }

        /// <summary>
        /// 批量添加记录
        /// </summary>
        /// <param name="list">待添加的实体对象列表</param>
        /// <returns>true:添加成功 false:添加失败</returns>
        public bool Add(List<Mod_Online_School_MajorEntity> list, IDataProvider provider)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_School_MajorEntity entity in list)
            {
                SQL sql = SQL.Build("INSERT INTO Mod_Online_School_Major(SchoolMajorId,SchoolMajorName,SchoolId,SchoolName,StateFlag,OrderIndex,DeleteFlag,ExtFlag) VALUES(?,?,?,?,?,?,?,?)",  entity.SchoolMajorId, entity.SchoolMajorName, entity.SchoolId, entity.SchoolName, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sqlList).Execute(provider) > 0;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="entity">待更新的实体对象</param>
        /// <returns>true:更新成功 false:更新失败</returns>
        public virtual bool Update(Mod_Online_School_MajorEntity entity)
        {
            SQL sql = SQL.Build("UPDATE Mod_Online_School_Major SET SchoolMajorName=?,SchoolId=?,SchoolName=?,StateFlag=?,OrderIndex=?,DeleteFlag=?,ExtFlag=? WHERE SchoolMajorId=?",  entity.SchoolMajorName, entity.SchoolId, entity.SchoolName, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag, entity.SchoolMajorId);
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="entity">待更新的实体对象</param>
        /// <returns>true:更新成功 false:更新失败</returns>
        public bool Update(Mod_Online_School_MajorEntity entity, IDataProvider provider)
        {
            SQL sql = SQL.Build("UPDATE Mod_Online_School_Major SET SchoolMajorName=?,SchoolId=?,SchoolName=?,StateFlag=?,OrderIndex=?,DeleteFlag=?,ExtFlag=? WHERE SchoolMajorId=?",  entity.SchoolMajorName, entity.SchoolId, entity.SchoolName, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag, entity.SchoolMajorId);
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sql).Execute(provider) > 0;
        }

        /// <summary>
        /// 批量更新记录
        /// </summary>
        /// <param name="list">待更新的实体对象列表</param>
        /// <returns>true:更新成功 false:更新失败</returns>
        public virtual bool Update(List<Mod_Online_School_MajorEntity> list)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_School_MajorEntity entity in list)
            {
                SQL sql = SQL.Build("UPDATE Mod_Online_School_Major SET SchoolMajorName=?,SchoolId=?,SchoolName=?,StateFlag=?,OrderIndex=?,DeleteFlag=?,ExtFlag=? WHERE SchoolMajorId=?",  entity.SchoolMajorName, entity.SchoolId, entity.SchoolName, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag, entity.SchoolMajorId);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sqlList).Execute() > 0;
        }

        /// <summary>
        /// 批量更新记录
        /// </summary>
        /// <param name="list">待更新的实体对象列表</param>
        /// <returns>true:更新成功 false:更新失败</returns>
        public bool Update(List<Mod_Online_School_MajorEntity> list, IDataProvider provider)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_School_MajorEntity entity in list)
            {
                SQL sql = SQL.Build("UPDATE Mod_Online_School_Major SET SchoolMajorName=?,SchoolId=?,SchoolName=?,StateFlag=?,OrderIndex=?,DeleteFlag=?,ExtFlag=? WHERE SchoolMajorId=?",  entity.SchoolMajorName, entity.SchoolId, entity.SchoolName, entity.StateFlag, entity.OrderIndex, entity.DeleteFlag, entity.ExtFlag, entity.SchoolMajorId);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sqlList).Execute(provider) > 0;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="schoolMajorId">学校专业编号</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public virtual bool Delete(string schoolMajorId)
        {
            SQL sql = SQL.Build("DELETE FROM Mod_Online_School_Major WHERE SchoolMajorId=?", schoolMajorId);
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="schoolMajorId">学校专业编号</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public bool Delete(string schoolMajorId, IDataProvider provider)
        {
            SQL sql = SQL.Build("DELETE FROM Mod_Online_School_Major WHERE SchoolMajorId=?", schoolMajorId);
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sql).Execute(provider) > 0;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="entity">待删除的实体对象</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public virtual bool Delete(Mod_Online_School_MajorEntity entity)
        {
            SQL sql = SQL.Build("DELETE FROM Mod_Online_School_Major WHERE SchoolMajorId=?", entity.SchoolMajorId);
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 批量删除记录
        /// </summary>
        /// <param name="list">待删除的实体对象列表</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public virtual bool Delete(List<Mod_Online_School_MajorEntity> list)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_School_MajorEntity entity in list)
            {
                SQL sql = SQL.Build("DELETE FROM Mod_Online_School_Major WHERE SchoolMajorId=?", entity.SchoolMajorId);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sqlList).Execute() > 0;
        }

        /// <summary>
        /// 批量删除记录
        /// </summary>
        /// <param name="list">待删除的实体对象列表</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public bool Delete(List<Mod_Online_School_MajorEntity> list, IDataProvider provider)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_School_MajorEntity entity in list)
            {
                SQL sql = SQL.Build("DELETE FROM Mod_Online_School_Major WHERE SchoolMajorId=?", entity.SchoolMajorId);
                sqlList.Add(sql);
            }
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sqlList).Execute(provider) > 0;
        }

        /// <summary>
        /// 根据主键获取实体对象
        /// </summary>
        /// <param name="schoolMajorId">学校专业编号</param>
        /// <returns>实体对象</returns>
        public virtual Mod_Online_School_MajorEntity GetModel(string schoolMajorId)
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_School_Major WHERE SchoolMajorId=?", schoolMajorId);
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sql).ToObject();
        }
  
        /// <summary>
        /// 根据主键获取Json对象
        /// </summary>
        /// <param name="schoolMajorId">学校专业编号</param>
        /// <returns>Json对象</returns>
        public virtual string GetJsonModel(string schoolMajorId)
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_School_Major WHERE SchoolMajorId=?", schoolMajorId);
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sql).ToJsonObject();
        }

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <returns>对象列表</returns>
        public virtual List<Mod_Online_School_MajorEntity> GetList()
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_School_Major");
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sql).ToList();
        }
        
        /// <summary>
        /// 获取Json对象列表
        /// </summary>
        /// <returns>Json对象列表</returns>
        public virtual string GetJsonList()
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_School_Major");
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sql).ToJsonList();
        }

        /// <summary>
        /// 获取分页后对象列表
        /// </summary>
        /// <param name="pageSize">每页显示的记录条数</param>
        /// <param name="pageNumber">当前页索引</param>
        /// <param name="recordCount">总记录条数</param>
        /// <returns>分页后对象列表</returns>
        public virtual List<Mod_Online_School_MajorEntity> GetList(int pageSize, int pageNumber, out int recordCount)
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_School_Major").Limit(pageSize, pageNumber);
            recordCount = sql.RecordCount;
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sql).ToList();
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
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_School_Major").Limit(pageSize, pageNumber);
            recordCount = sql.RecordCount;
            return SqlMap<Mod_Online_School_MajorEntity>.ParseSql(sql).ToJsonList();
        }
    }
}