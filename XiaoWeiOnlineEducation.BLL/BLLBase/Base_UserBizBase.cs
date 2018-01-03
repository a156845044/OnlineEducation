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
    /// 用户表业务逻辑
    /// </summary>
    public abstract class Base_UserBizBase
    {
        /// <summary>
        /// 根据主键判断该记录是否存在
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>true：存在，false：不存在</returns>
        public virtual bool Exists(string userId)
        {
            SQL sql = SQL.Build("SELECT COUNT(*) FROM Base_User WHERE UserId=?", userId);
            return Convert.ToInt32(SqlMap<Base_UserEntity>.ParseSql(sql).First()) > 0;
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity">待添加的实体对象</param>
        /// <returns>true:添加成功 false:添加失败</returns>
        public virtual bool Add(Base_UserEntity entity)
        {
            SQL sql = SQL.Build("INSERT INTO Base_User(UserId,UserName,Sex,Account,Pwd,UserTypeId,CreateDeptId,StateFlag,DeleteFlag,OrderIndex,ExtFlag) VALUES(?,?,?,?,?,?,?,?,?,?,?)",  entity.UserId, entity.UserName, entity.Sex, entity.Account, entity.Pwd, entity.UserTypeId, entity.CreateDeptId, entity.StateFlag, entity.DeleteFlag, entity.OrderIndex, entity.ExtFlag);
            return SqlMap<Base_UserEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity">待添加的实体对象</param>
        /// <returns>true:添加成功 false:添加失败</returns>
        public bool Add(Base_UserEntity entity, IDataProvider provider)
        {
            SQL sql = SQL.Build("INSERT INTO Base_User(UserId,UserName,Sex,Account,Pwd,UserTypeId,CreateDeptId,StateFlag,DeleteFlag,OrderIndex,ExtFlag) VALUES(?,?,?,?,?,?,?,?,?,?,?)",  entity.UserId, entity.UserName, entity.Sex, entity.Account, entity.Pwd, entity.UserTypeId, entity.CreateDeptId, entity.StateFlag, entity.DeleteFlag, entity.OrderIndex, entity.ExtFlag);
            return SqlMap<Base_UserEntity>.ParseSql(sql).Execute(provider) > 0;
        }

        /// <summary>
        /// 批量添加记录
        /// </summary>
        /// <param name="list">待添加的实体对象列表</param>
        /// <returns>true:添加成功 false:添加失败</returns>
        public virtual bool Add(List<Base_UserEntity> list)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Base_UserEntity entity in list)
            {
                SQL sql = SQL.Build("INSERT INTO Base_User(UserId,UserName,Sex,Account,Pwd,UserTypeId,CreateDeptId,StateFlag,DeleteFlag,OrderIndex,ExtFlag) VALUES(?,?,?,?,?,?,?,?,?,?,?)",  entity.UserId, entity.UserName, entity.Sex, entity.Account, entity.Pwd, entity.UserTypeId, entity.CreateDeptId, entity.StateFlag, entity.DeleteFlag, entity.OrderIndex, entity.ExtFlag);
                sqlList.Add(sql);
            }
            return SqlMap<Base_UserEntity>.ParseSql(sqlList).Execute() > 0;
        }

        /// <summary>
        /// 批量添加记录
        /// </summary>
        /// <param name="list">待添加的实体对象列表</param>
        /// <returns>true:添加成功 false:添加失败</returns>
        public bool Add(List<Base_UserEntity> list, IDataProvider provider)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Base_UserEntity entity in list)
            {
                SQL sql = SQL.Build("INSERT INTO Base_User(UserId,UserName,Sex,Account,Pwd,UserTypeId,CreateDeptId,StateFlag,DeleteFlag,OrderIndex,ExtFlag) VALUES(?,?,?,?,?,?,?,?,?,?,?)",  entity.UserId, entity.UserName, entity.Sex, entity.Account, entity.Pwd, entity.UserTypeId, entity.CreateDeptId, entity.StateFlag, entity.DeleteFlag, entity.OrderIndex, entity.ExtFlag);
                sqlList.Add(sql);
            }
            return SqlMap<Base_UserEntity>.ParseSql(sqlList).Execute(provider) > 0;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="entity">待更新的实体对象</param>
        /// <returns>true:更新成功 false:更新失败</returns>
        public virtual bool Update(Base_UserEntity entity)
        {
            SQL sql = SQL.Build("UPDATE Base_User SET UserName=?,Sex=?,Account=?,Pwd=?,UserTypeId=?,CreateDeptId=?,StateFlag=?,DeleteFlag=?,OrderIndex=?,ExtFlag=? WHERE UserId=?",  entity.UserName, entity.Sex, entity.Account, entity.Pwd, entity.UserTypeId, entity.CreateDeptId, entity.StateFlag, entity.DeleteFlag, entity.OrderIndex, entity.ExtFlag, entity.UserId);
            return SqlMap<Base_UserEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="entity">待更新的实体对象</param>
        /// <returns>true:更新成功 false:更新失败</returns>
        public bool Update(Base_UserEntity entity, IDataProvider provider)
        {
            SQL sql = SQL.Build("UPDATE Base_User SET UserName=?,Sex=?,Account=?,Pwd=?,UserTypeId=?,CreateDeptId=?,StateFlag=?,DeleteFlag=?,OrderIndex=?,ExtFlag=? WHERE UserId=?",  entity.UserName, entity.Sex, entity.Account, entity.Pwd, entity.UserTypeId, entity.CreateDeptId, entity.StateFlag, entity.DeleteFlag, entity.OrderIndex, entity.ExtFlag, entity.UserId);
            return SqlMap<Base_UserEntity>.ParseSql(sql).Execute(provider) > 0;
        }

        /// <summary>
        /// 批量更新记录
        /// </summary>
        /// <param name="list">待更新的实体对象列表</param>
        /// <returns>true:更新成功 false:更新失败</returns>
        public virtual bool Update(List<Base_UserEntity> list)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Base_UserEntity entity in list)
            {
                SQL sql = SQL.Build("UPDATE Base_User SET UserName=?,Sex=?,Account=?,Pwd=?,UserTypeId=?,CreateDeptId=?,StateFlag=?,DeleteFlag=?,OrderIndex=?,ExtFlag=? WHERE UserId=?",  entity.UserName, entity.Sex, entity.Account, entity.Pwd, entity.UserTypeId, entity.CreateDeptId, entity.StateFlag, entity.DeleteFlag, entity.OrderIndex, entity.ExtFlag, entity.UserId);
                sqlList.Add(sql);
            }
            return SqlMap<Base_UserEntity>.ParseSql(sqlList).Execute() > 0;
        }

        /// <summary>
        /// 批量更新记录
        /// </summary>
        /// <param name="list">待更新的实体对象列表</param>
        /// <returns>true:更新成功 false:更新失败</returns>
        public bool Update(List<Base_UserEntity> list, IDataProvider provider)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Base_UserEntity entity in list)
            {
                SQL sql = SQL.Build("UPDATE Base_User SET UserName=?,Sex=?,Account=?,Pwd=?,UserTypeId=?,CreateDeptId=?,StateFlag=?,DeleteFlag=?,OrderIndex=?,ExtFlag=? WHERE UserId=?",  entity.UserName, entity.Sex, entity.Account, entity.Pwd, entity.UserTypeId, entity.CreateDeptId, entity.StateFlag, entity.DeleteFlag, entity.OrderIndex, entity.ExtFlag, entity.UserId);
                sqlList.Add(sql);
            }
            return SqlMap<Base_UserEntity>.ParseSql(sqlList).Execute(provider) > 0;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public virtual bool Delete(string userId)
        {
            SQL sql = SQL.Build("DELETE FROM Base_User WHERE UserId=?", userId);
            return SqlMap<Base_UserEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public bool Delete(string userId, IDataProvider provider)
        {
            SQL sql = SQL.Build("DELETE FROM Base_User WHERE UserId=?", userId);
            return SqlMap<Base_UserEntity>.ParseSql(sql).Execute(provider) > 0;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="entity">待删除的实体对象</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public virtual bool Delete(Base_UserEntity entity)
        {
            SQL sql = SQL.Build("DELETE FROM Base_User WHERE UserId=?", entity.UserId);
            return SqlMap<Base_UserEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 批量删除记录
        /// </summary>
        /// <param name="list">待删除的实体对象列表</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public virtual bool Delete(List<Base_UserEntity> list)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Base_UserEntity entity in list)
            {
                SQL sql = SQL.Build("DELETE FROM Base_User WHERE UserId=?", entity.UserId);
                sqlList.Add(sql);
            }
            return SqlMap<Base_UserEntity>.ParseSql(sqlList).Execute() > 0;
        }

        /// <summary>
        /// 批量删除记录
        /// </summary>
        /// <param name="list">待删除的实体对象列表</param>
        /// <returns>true:删除成功 false:删除失败</returns>
        public bool Delete(List<Base_UserEntity> list, IDataProvider provider)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Base_UserEntity entity in list)
            {
                SQL sql = SQL.Build("DELETE FROM Base_User WHERE UserId=?", entity.UserId);
                sqlList.Add(sql);
            }
            return SqlMap<Base_UserEntity>.ParseSql(sqlList).Execute(provider) > 0;
        }

        /// <summary>
        /// 根据主键获取实体对象
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>实体对象</returns>
        public virtual Base_UserEntity GetModel(string userId)
        {
            SQL sql = SQL.Build("SELECT * FROM Base_User WHERE UserId=?", userId);
            return SqlMap<Base_UserEntity>.ParseSql(sql).ToObject();
        }
  
        /// <summary>
        /// 根据主键获取Json对象
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>Json对象</returns>
        public virtual string GetJsonModel(string userId)
        {
            SQL sql = SQL.Build("SELECT * FROM Base_User WHERE UserId=?", userId);
            return SqlMap<Base_UserEntity>.ParseSql(sql).ToJsonObject();
        }

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <returns>对象列表</returns>
        public virtual List<Base_UserEntity> GetList()
        {
            SQL sql = SQL.Build("SELECT * FROM Base_User");
            return SqlMap<Base_UserEntity>.ParseSql(sql).ToList();
        }
        
        /// <summary>
        /// 获取Json对象列表
        /// </summary>
        /// <returns>Json对象列表</returns>
        public virtual string GetJsonList()
        {
            SQL sql = SQL.Build("SELECT * FROM Base_User");
            return SqlMap<Base_UserEntity>.ParseSql(sql).ToJsonList();
        }

        /// <summary>
        /// 获取分页后对象列表
        /// </summary>
        /// <param name="pageSize">每页显示的记录条数</param>
        /// <param name="pageNumber">当前页索引</param>
        /// <param name="recordCount">总记录条数</param>
        /// <returns>分页后对象列表</returns>
        public virtual List<Base_UserEntity> GetList(int pageSize, int pageNumber, out int recordCount)
        {
            SQL sql = SQL.Build("SELECT * FROM Base_User").Limit(pageSize, pageNumber);
            recordCount = sql.RecordCount;
            return SqlMap<Base_UserEntity>.ParseSql(sql).ToList();
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
            SQL sql = SQL.Build("SELECT * FROM Base_User").Limit(pageSize, pageNumber);
            recordCount = sql.RecordCount;
            return SqlMap<Base_UserEntity>.ParseSql(sql).ToJsonList();
        }
    }
}