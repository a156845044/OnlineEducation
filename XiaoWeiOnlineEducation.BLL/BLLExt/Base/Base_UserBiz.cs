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
    /// 用户表业务逻辑
    /// </summary>
    public class Base_UserBiz : Base_UserBizBase
    {
        #region 2017-05

        /// <summary>
        /// 创建默认系统账户（如果不存在则创建）
        /// </summary>
        /// <remarks>作者：dfq 时间：2017-05-07</remarks>
        public void CreateSysAdmin()
        {
            int adminFlag = UserFlag.SysAdmin.ToInt();
            SQL sql = SQL.Build("SELECT COUNT(UserId) FROM Base_User WHERE UserTypeId=?", adminFlag);
            int result = Convert.ToInt32(SqlMap.ParseSql(sql).First());
            if (result > 0)
            {
                return;
            }
            Base_UserEntity entity = new Base_UserEntity();
            entity.Account = "sysadmin";
            entity.Pwd = SysParam.DefaultPwd;
            entity.StateFlag = 0;
            entity.UserTypeId = adminFlag;
            entity.Sex = "";
            entity.CreateDeptId = "";
            entity.UserId = StringHelper.GetGuid();
            entity.UserName = entity.Account;
            this.Add(entity);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns>用户信息</returns>
        /// <remarks>作者：dfq 时间：2017-05-07</remarks>
        public LoginEntity Login(string account, string pwd)
        {
            //创建默认超级管理员
            CreateSysAdmin();
            SQL sql = SQL.Build("SELECT * FROM Base_User BU  WHERE Account=? AND Pwd=? AND BU.DeleteFlag=?", account, pwd, DeleteFlag.NotDel.ToInt());
            LoginEntity user = SqlMap<LoginEntity>.ParseSql(sql).ToObject();

            //验证用户是否正确
            if (user == null)
            {
                user = new LoginEntity();
                user.ErrorCode = LoginError.Error;
            }
            else
            {
                if (user.DeleteFlag == DeleteFlag.HadDel.ToInt())
                {
                    user.ErrorCode = LoginError.Inexistence;
                    return user;
                }

                //判断用户是否禁用
                if (user.StateFlag >= LoginState.PasswordError.ToInt())
                {
                    if (user.StateFlag == LoginState.PasswordError.ToInt())//密码次数过多
                    {
                        user.ErrorCode = LoginError.PasswordError;
                    }

                    if (user.StateFlag == LoginState.ForbiddenPC.ToInt())//禁止PC登录
                    {
                        user.ErrorCode = LoginError.ForbiddenPC;
                    }

                    if (user.StateFlag == LoginState.Forbidden.ToInt())//已禁用
                    {
                        user.ErrorCode = LoginError.Forbidden;
                    }

                    return user;
                }
                user.ErrorCode = LoginError.Normal;
            }
            return user;
        }

        /// <summary>
        /// 验证登录密码
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="pwd">密码</param>
        /// <returns>true:验证成功 false:验证失败</returns>
        /// <remarks>作者：dfq 时间：2017-05-07</remarks>
        public bool GetPwdCheck(string userId, string pwd)
        {
            SQL sql = SQL.Build("SELECT COUNT(UserId) FROM Base_User WHERE UserId=? AND Pwd=? ", userId, pwd);
            return Convert.ToInt32(SqlMap<Base_UserEntity>.ParseSql(sql).First()) > 0;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="pwd">密码</param>
        /// <returns>true:修改成功 false:修改失败</returns>
        /// <remarks>作者：dfq 时间：2017-05-07</remarks>
        public bool UpdatePwd(string userId, string pwd)
        {
            SQL sql = SQL.Build("UPDATE Base_User SET Pwd=? WHERE UserId=? ", pwd, userId);
            return SqlMap<Base_UserEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// 修改账号
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="account">账号</param>
        /// <returns>true:修改成功 false:修改失败</returns>
        /// <remarks>作者：dfq 时间：2017-05-07</remarks>
        public bool UpdateAccount(string userId, string account)
        {
            SQL sql = SQL.Build("UPDATE Base_User SET Account=? WHERE UserId=? ", account, userId);
            return SqlMap<Base_UserEntity>.ParseSql(sql).Execute() > 0;
        }
        #endregion
    }
}