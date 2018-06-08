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
    public class Mod_Online_ApplicationTypeBiz : Mod_Online_ApplicationTypeBizBase
    {
        #region 2017-05
        /// <summary>
        /// 去除已存在的记录
        /// </summary>
        /// <param name="list">待筛选记录列表</param>
        /// <remarks>作者：dfq 时间：2017-05-07</remarks>
        public void RemoveExistingRecord(List<Mod_Online_ApplicationTypeEntity> list)
        {
            List<Mod_Online_ApplicationTypeEntity> existList = GetList();
            foreach (Mod_Online_ApplicationTypeEntity entity in existList)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Mod_Online_ApplicationTypeEntity item = list[i];
                    if (item.AppTypeName.Trim() == entity.AppTypeName.Trim())
                    {
                        list.RemoveAt(i);
                    }
                }
            }
        }
        #endregion

        #region 2018-06
        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <returns>对象列表</returns>
        public List<Mod_Online_ApplicationTypeEntity> GetList(PlanRegisterType type = PlanRegisterType.Triennium)
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_ApplicationType where [ExtFlag]=? ", type.ToInt());
            return SqlMap<Mod_Online_ApplicationTypeEntity>.ParseSql(sql).ToList();
        }
        #endregion
    }
}