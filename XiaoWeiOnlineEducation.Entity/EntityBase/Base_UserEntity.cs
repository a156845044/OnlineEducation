using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Brilliant.ORM;

namespace XiaoWeiOnlineEducation.Entity
{
    /// <summary>
    /// 实体映射：用户表
    /// </summary>
    [Serializable]
    public class Base_UserEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Base_UserEntity()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fkObject">外键实体对象</param>
        public Base_UserEntity(EntityBase fkObject)
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
        /// 密码
        /// </summary>
        public string Pwd
        {
            get { return GetProperty<string>("Pwd"); }
            set { SetProperty("Pwd", value); }
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
        /// 创建单位（分单位管理员用）
        /// </summary>
        public string CreateDeptId
        {
            get { return GetProperty<string>("CreateDeptId"); }
            set { SetProperty("CreateDeptId", value); }
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

    }
}