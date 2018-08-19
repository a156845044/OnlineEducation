using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Brilliant.ORM;
using XiaoWeiOnlineEducation.Entity;
using Brilliant.Utility;
using System.Data.OleDb;

namespace XiaoWeiOnlineEducation.BLL
{
    /// <summary>
    /// 专业代码业务逻辑
    /// </summary>
    public class Mod_Online_MajorCodeBiz : Mod_Online_MajorCodeBizBase
    {
        #region 2017-05
        /// <summary>
        /// 获取专业代码列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageNum">当前页码</param>
        /// <param name="recordCount">总记录条数</param>
        /// <returns>专业代码列表</returns>
        public List<Mod_Online_MajorCodeInfo> GetCodeList(string keyword, int pageSize, int pageNum, out int recordCount)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT *,(SELECT CodeName FROM Mod_Online_MajorCode temp WHERE temp.Id =Mod_Online_MajorCode.ParentId ) AS  ParentName ");
            strSQL.Append(" FROM Mod_Online_MajorCode  ");
            // strSQL.Append(" FROM Mod_Online_MajorCode  WHERE ParentId!='' ");
            if (!string.IsNullOrEmpty(keyword))
            {
                if (ValidateHelper.IsSafeSqlString(keyword))
                {
                    //   strSQL.Append(" AND ( ");
                    strSQL.Append(" WHERE ");
                    strSQL.AppendFormat(" CodeId LIKE ('{0}%') ", keyword);
                    strSQL.AppendFormat(" OR CodeName LIKE ('%{0}%') ", keyword);
                   // strSQL.Append(" ) ");
                }
            }
            SQL sql = SQL.Build(strSQL.ToString()).Limit(pageSize, pageNum);
            recordCount = sql.RecordCount;
            return SqlMap<Mod_Online_MajorCodeInfo>.ParseSql(sql).ToList();
        }

        /// <summary>
        /// 获取专业代码列表
        /// </summary>
        /// <param name="codeIdStr">专业代码编号列表</param>
        /// <returns>专业代码列表</returns>
        public List<Mod_Online_MajorCodeEntity> GetCodeList(string codeIdStr)
        {
            SQL sql = SQL.Format("SELECT * FROM Mod_Online_MajorCode WHERE CodeId IN({0})", codeIdStr);
            return SqlMap<Mod_Online_MajorCodeEntity>.ParseSql(sql).ToList();
        }

        /// <summary>
        /// 更新专业代码
        /// </summary>
        /// <param name="codeList">待更新的列表</param>
        /// <param name="dp">数据库访问对象接口</param>
        /// <returns>执行结果</returns>
        public bool UpdateMajorCode(List<Mod_Online_MajorCodeEntity> codeList, IDataProvider dp)
        {
            List<SQL> sqlList = new List<SQL>();
            foreach (Mod_Online_MajorCodeEntity entity in codeList)
            {
                sqlList.Add(SQL.Build("UPDATE Mod_Online_MajorCode SET CodeId=?,CodeName=? WHERE Id=?", entity.CodeId, entity.CodeName, entity.Id));
            }
            if (dp != null)
            {
                return SqlMap<Mod_Online_MajorCodeEntity>.ParseSql(sqlList).Execute(dp) > 0;
            }
            else
            {
                return SqlMap<Mod_Online_MajorCodeEntity>.ParseSql(sqlList).Execute() > 0;
            }
        }

        /// <summary>
        /// Excel数据导入
        /// </summary>
        /// <param name="path">相对路径</param>
        /// <param name="user">当前登录人员</param>
        /// <returns>导出结果</returns>
        public RemoveExistingRecordEntity ExcelImport(string path, LoginEntity user)
        {
            string cmdText = @"SELECT [专业代码],[专业名称] FROM [Sheet1$];";

            List<Mod_Online_MajorCodeInfo> importList = new List<Mod_Online_MajorCodeInfo>();
            int addCount = 0;
            int succCount = 0;
            int errorCount = 0;

            int rowNumber = 1;
            StringBuilder strCodeId = new StringBuilder();//获取当前专业代码
            using (OleDbDataReader dr = ExcelHelper.ReadExcel(FileHelper.GetMapPath(string.Format("~{0}", path)), cmdText))
            {
                while (dr.Read())
                {
                    Mod_Online_MajorCodeInfo model = new Mod_Online_MajorCodeInfo();
                    model.CodeId = StringHelper.TrimString(dr["专业代码"].ToString());
                    model.CodeName = StringHelper.TrimString(dr["专业名称"].ToString());

                    rowNumber++;
                    model.RowNumber = rowNumber;
                    importList.Add(model);
                    strCodeId.AppendFormat("'{0}',", model.CodeId);
                }
            }
            addCount = importList.Count;

            List<Mod_Online_MajorCodeInfo> tempAddList = new List<Mod_Online_MajorCodeInfo>();//待添加的列表(临时)

            List<Mod_Online_MajorCodeEntity> addList = new List<Mod_Online_MajorCodeEntity>();//待添加的列表
            List<Mod_Online_MajorCodeEntity> updateList = new List<Mod_Online_MajorCodeEntity>();//待更新的列表

            string codeIdStr = strCodeId.ToString().Trim().TrimEnd(',');

            List<Mod_Online_MajorCodeEntity> existList = GetList();

            StringBuilder strAddUserStr = new StringBuilder();
            bool isUpdate = false;
            foreach (Mod_Online_MajorCodeInfo import in importList)
            {
                isUpdate = false;
                Mod_Online_MajorCodeEntity exist = existList.Find(x => x.CodeId.Trim() == import.CodeId.Trim());
                if (exist != null)
                {
                    isUpdate = true;
                    Mod_Online_MajorCodeEntity model = new Mod_Online_MajorCodeEntity();
                    model.Id = exist.Id;
                    model.CodeId = import.CodeId;
                    model.CodeName = import.CodeName;
                    model.ParentId = exist.ParentId;
                    updateList.Add(model);
                }

                if (!isUpdate)
                {
                    Mod_Online_MajorCodeInfo model = new Mod_Online_MajorCodeInfo();
                    model.CodeId = import.CodeId;
                    model.CodeName = import.CodeName;
                    model.RowNumber = import.RowNumber;
                    model.ParentId = "";
                    tempAddList.Add(model);
                }
                else
                {
                    succCount++;
                }

            }
            RemoveExistingRecordEntity returnData = new RemoveExistingRecordEntity();

            StringBuilder strReturn = new StringBuilder();

            if (tempAddList.Count > 0)
            {

                List<Mod_Online_MajorCodeInfo> childList = tempAddList.FindAll(x => x.CodeId.Length > 4).ToList();
                List<Mod_Online_MajorCodeInfo> parentList = tempAddList.FindAll(x => x.CodeId.Length <= 4).ToList();

                foreach (Mod_Online_MajorCodeEntity parent in parentList)
                {
                    Mod_Online_MajorCodeEntity model = new Mod_Online_MajorCodeEntity();
                    model.Id = StringHelper.GetGuid();
                    parent.Id = model.Id;
                    model.CodeId = parent.CodeId;
                    model.CreateTime = DateTime.Now;
                    model.CodeName = parent.CodeName;
                    model.ParentId = "";
                    addList.Add(model);
                    succCount++;
                }

                foreach (Mod_Online_MajorCodeInfo child in childList)
                {
                    Mod_Online_MajorCodeEntity model = new Mod_Online_MajorCodeEntity();
                    model.Id = StringHelper.GetGuid();
                    model.CreateTime = DateTime.Now;
                    model.CodeId = child.CodeId;
                    model.CodeName = child.CodeName;

                    Mod_Online_MajorCodeEntity temp = parentList.Find(x => x.CodeId.Trim() == model.CodeId.Substring(0, 4));
                    if (temp != null)
                    {
                        model.ParentId = temp.Id;
                        addList.Add(model);
                        succCount++;
                    }
                    else
                    {
                        temp = existList.Find(x => x.CodeId.Trim() == model.CodeId.Substring(0, 4));
                        if (temp != null)
                        {
                            model.ParentId = temp.Id;
                            addList.Add(model);
                            succCount++;
                        }
                        else
                        {

                            Mod_Online_MajorCodeEntity parent = new Mod_Online_MajorCodeEntity();
                            parent.Id = StringHelper.GetGuid();
                            parent.CreateTime = DateTime.Now;
                            parent.CodeId = model.CodeId.Substring(0, 4);
                            parent.CodeName = "";
                            succCount++;
                            model.ParentId = parent.Id;
                            addList.Add(parent);
                            addList.Add(model);
                        }
                    }
                }
            }

            bool flag = DBHelper.Transaction((dp, ex) =>
            {
                UpdateMajorCode(updateList, dp);
                Add(addList, dp);
            }) > 0;

            returnData.flag = flag;
            returnData.AddCount = addCount;
            returnData.SuccCount = succCount;
            returnData.ErrorCount = errorCount;
            returnData.Existstr = strReturn.ToString().Trim().TrimEnd('、');
            return returnData;
        }

        /// <summary>
        /// 获取专业代码列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        public List<AutocompleteEntity> GetCodeQueryList(string keyword)
        {
            bool flag = false;
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT (CodeId+CodeName) AS label, CodeId as value  ");
            strSQL.Append(" FROM Mod_Online_MajorCode ");
            if (!string.IsNullOrEmpty(keyword))
            {
                if (ValidateHelper.IsSafeSqlString(keyword))
                {
                    flag = true;
                    strSQL.Append(" WHERE  ");
                    strSQL.AppendFormat(" CodeId LIKE ('{0}%') ", keyword);
                    strSQL.AppendFormat(" OR CodeName LIKE ('%{0}%') ", keyword);
                    strSQL.Append("  ");
                }
            }
            if (flag)
            {
                strSQL.Append(" ORDER BY CodeId ");
                SQL sql = SQL.Build(strSQL.ToString());
                return SqlMap<AutocompleteEntity>.ParseSql(sql).ToList();
            }
            else
            {
                return new List<AutocompleteEntity>();
            }
        }
        #endregion
    }
}