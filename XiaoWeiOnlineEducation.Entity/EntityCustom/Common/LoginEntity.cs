using Brilliant.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoWeiOnlineEducation.Entity
{
    public class LoginEntity: EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public LoginEntity()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fkObject">外键实体对象</param>
        public LoginEntity(EntityBase fkObject)
            : base(fkObject)
        {
        }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId
        {
            get { return GetProperty<string>("UserId"); }
            set { SetProperty("UserId", value); }
        }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName
        {
            get { return GetProperty<string>("UserName"); }
            set { SetProperty("UserName", value); }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get { return GetProperty<string>("Sex"); }
            set { SetProperty("Sex", value); }
        }

        /// <summary>
        /// 账户
        /// </summary>
        public string Account
        {
            get { return GetProperty<string>("Account"); }
            set { SetProperty("Account", value); }
        }

        /// <summary>
        /// 用户类型（0:普通用户 1:管理员 2:超级管理员） 单页登陆
        /// </summary>
        public int UserTypeId
        {
            get { return GetProperty<int>("UserTypeId"); }
            set { SetProperty("UserTypeId", value); }
        }

        /// <summary>
        /// 账户状态（0：启用 1：禁用）
        /// </summary>
        public int StateFlag
        {
            get { return GetProperty<int>("StateFlag"); }
            set { SetProperty("StateFlag", value); }
        }

        /// <summary>
        /// 删除标记（0、正常 1、已删除）
        /// </summary>
        public int DeleteFlag
        {
            get { return GetProperty<int>("DeleteFlag"); }
            set { SetProperty("DeleteFlag", value); }
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public int OrderIndex
        {
            get { return GetProperty<int>("OrderIndex"); }
            set { SetProperty("OrderIndex", value); }
        }

        /// <summary>
        /// 扩展标记
        /// </summary>
        public int ExtFlag
        {
            get { return GetProperty<int>("ExtFlag"); }
            set { SetProperty("ExtFlag", value); }
        }

        /// <summary>
        /// 错误代码
        /// </summary>
        public LoginError ErrorCode
        {
            get;
            set;
        }

        /// <summary>
        /// 登录IP
        /// </summary>
        public string IP
        {
            get { return GetProperty<string>("IP"); }
            set { SetProperty("IP", value); }
        }

        /// <summary>
        /// 角色列表拼接字符如‘001’，‘002’，‘003’
        /// </summary>
        public string RoleIdStr
        {
            get;
            set;
        }

      
    }
}
