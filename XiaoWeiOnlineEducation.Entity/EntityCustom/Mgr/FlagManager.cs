using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoWeiOnlineEducation.Entity
{
    #region Enum
    /// <summary>
    /// 登录错误代码
    /// </summary>
    public enum LoginError
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("验证成功")]
        Normal,
        /// <summary>
        /// 用户名密码错误
        /// </summary>
        [Description("用户名或密码错误,请重新输入。")]
        Error,
        /// <summary>
        /// 密码错误次数过多，帐号已禁用
        /// </summary>
        [Description("您的密码错误次数过多，帐号已停用，请联系管理员。")]
        PasswordError,
        /// <summary>
        /// 登录设备不符，禁止访问
        /// </summary>
        [Description("登录设备不符，禁止访问")]
        Illegal,
        /// <summary>
        /// PC端已被禁用，请联系管理员
        /// </summary>
        [Description("您的账号已禁止在PC端访问，请联系管理员")]
        ForbiddenPC,
        /// <summary>
        /// 移动端已被禁用，请联系管理员
        /// </summary>
        [Description("您的账号已禁止在移动端访问，请联系管理员")]
        ForbiddenMobile,
        /// <summary>
        /// 设备未启用（移动端手机未认证）
        /// </summary>
        [Description("登录设备不符，禁止访问")]
        ForbiddenDevice,
        /// <summary>
        /// 该用户已停用,请联系管理员
        /// </summary>
        [Description("您的账号已停用,请联系管理员")]
        Forbidden,
        /// <summary>
        /// 用户不存在
        /// </summary>
        [Description("用户不存在")]
        Inexistence
    }

    /// <summary>
    /// 数据控件类型
    /// </summary>
    public enum DataControlType
    {
        GridView,
        Repeater
    }


    /// <summary>
    /// Session标记
    /// </summary>
    public enum SessionFlag
    {
        LoginUser
    }

    /// <summary>
    /// 用户类型
    /// </summary>
    public enum UserFlag
    {
        /// <summary>
        /// 普通用户
        /// </summary>
        User = 0,
        /// <summary>
        /// 超级管理员
        /// </summary>
        SysAdmin = 1,
        /// <summary>
        /// 管理员
        /// </summary>
        Admin = 2
    }

    /// <summary>
    /// 登录状态
    /// </summary>
    public enum LoginState
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常", ColorFormat.Green)]
        Normal = 0,
        /// <summary>
        /// 禁用移动端
        /// </summary>
        [Description("移动端已禁用", ColorFormat.Red)]
        ForbiddenMobile,
        /// <summary>
        /// 密码输入错误次数过多
        /// </summary>
        [Description("密码输入错误次数过多", ColorFormat.Red)]
        PasswordError,
        ///// <summary>
        ///// 登录设备不符，禁止访问
        ///// </summary>
        //[Description("登录设备不符，禁止访问", ColorFormat.Red)]
        //Illegal,
        /// <summary>
        /// 禁用PC
        /// </summary>
        [Description("PC端已禁用", ColorFormat.Red)]
        ForbiddenPC,
        /// <summary>
        /// 已禁用
        /// </summary>
        [Description("已禁用", ColorFormat.Red)]
        Forbidden
    }


    /// <summary>
    /// 删除标记
    /// </summary>
    public enum DeleteFlag
    {
        [Description("已删除")]
        NotDel = 0,
        [Description("未删除")]
        HadDel
    }

    /// <summary>
    /// 返回状态
    /// </summary>
    public enum ReturnCode
    {
        /// <summary>
        /// 失败
        /// </summary>
        Error = 0,
        /// <summary>
        /// 成功
        /// </summary>
        Succ
    }

    /// <summary>
    /// 递归类型
    /// </summary>
    public enum RecursionType
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default,
        /// <summary>
        /// 单位
        /// </summary>
        Dept,
        /// <summary>
        /// 角色权限
        /// </summary>
        RoleLevel,
        /// <summary>
        /// 角色
        /// </summary>
        Role
    }

    /// <summary>
    /// 颜色格式
    /// </summary>
    public enum ColorFormat
    {
        [Description("<span >{0}</span>")]
        Normal,
        [Description("<span  style='color:red'>{0}</span>")]
        Red,
        [Description("<span  style='color:green'>{0}</span>")]
        Green,
        [Description("<span  style='color:gray'>{0}</span>")]
        Gray,
        [Description("<span  style='color:#ff9900'>{0}</span>")]
        Orange

    }

    /// <summary>
    /// 年度计划是否开放分数查询
    /// </summary>
    public enum YearPlanSearchEnable
    {
        /// 正常
        /// </summary>
        [Description("未开放")]
        Normal,
        /// <summary>
        /// 已开放
        /// </summary>
        [Description("已开放")]
        Open,
    }

    /// <summary>
    /// 报考年制类型
    ///  3年
    ///  5年一贯
    /// </summary>
    public enum PlanRegisterType
    {
        /// <summary>
        /// 3年制
        /// </summary>
        Triennium=0,
        /// <summary>
        /// 5年一贯制
        /// </summary>
        Lustrum=1

    }
    #endregion

    #region FlagManager

    public class FlagManager
    {
    }
    #endregion
}
