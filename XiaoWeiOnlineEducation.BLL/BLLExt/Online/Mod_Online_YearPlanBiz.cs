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
    /// 年度招生计划业务逻辑
    /// </summary>
    public class Mod_Online_YearPlanBiz : Mod_Online_YearPlanBizBase
    {
        #region 2017-05

        /// <summary>
        /// 根据年度编号获取实体
        /// </summary>
        /// <param name="yearId">年度编号</param>
        /// <returns>实体</returns>
        public Mod_Online_YearPlanEntity GetYearPlanModel(string yearId)
        {
            SQL sql = SQL.Build("SELECT * FROM Mod_Online_YearPlan WHERE YearId=? ", yearId);
            return SqlMap<Mod_Online_YearPlanEntity>.ParseSql(sql).ToObject();
        }

        /// <summary>
        /// 获取分页后对象列表
        /// </summary>
        /// <param name="yearId">年度</param>
        /// <param name="pageSize">每页显示的记录条数</param>
        /// <param name="pageNumber">当前页索引</param>
        /// <param name="recordCount">总记录条数</param>
        /// <returns>分页后对象列表</returns>
        public List<Mod_Online_YearPlanEntity> GetList(string yearId, int pageSize, int pageNumber, out int recordCount)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append(" SELECT * FROM Mod_Online_YearPlan  ");
            if (!string.IsNullOrEmpty(yearId))
            {
                if (ValidateHelper.IsSafeSqlString(yearId))
                {
                    strSQL.Append(" WHERE  ");
                    strSQL.AppendFormat(" YearId ={0} ", yearId);
                }
            }
            strSQL.Append(" ORDER BY  YearId DESC ");
            SQL sql = SQL.Build(strSQL.ToString()).Limit(pageSize, pageNumber);
            recordCount = sql.RecordCount;
            return SqlMap<Mod_Online_YearPlanEntity>.ParseSql(sql).ToList();
        }


        /// <summary>
        /// Excel数据导入
        /// </summary>
        /// <param name="yearId">年度</param>
        /// <param name="path">相对路径</param>
        /// <param name="user">当前登录人员</param>
        /// <returns>执行结果</returns>
        public bool ExcelImport(string yearId, string path, LoginEntity user)
        {
            bool isAdd = false;

            List<Mod_Online_YearPlan_DetailEntity> addList = new List<Mod_Online_YearPlan_DetailEntity>();//待添加的列表
            List<Mod_Online_YearPlan_Detail_MajorCodeEntity> detailMajorCodeAddList = new List<Mod_Online_YearPlan_Detail_MajorCodeEntity>();//待添加的计划详细-代码详细
            //2017年江苏省普通高校“专转本”专业计划表
            Mod_Online_YearPlanEntity yearPlanModel = GetYearPlanModel(yearId);//获取年度计划实体
            if (yearPlanModel == null)//添加
            {
                isAdd = true;
                yearPlanModel = new Mod_Online_YearPlanEntity();
                yearPlanModel.PlanId = StringHelper.GetGuid();
                yearPlanModel.YearId = yearId.ToInt();
                yearPlanModel.PlanName = string.Format("{0}年江苏省普通高校“专转本”专业计划表", yearId);
            }

            List<Mod_Online_ApplicationTypeEntity> applicationTypeAddList = new List<Mod_Online_ApplicationTypeEntity>();//待添加的类型
            List<Mod_Online_SchoolEntity> shcoolAddList = new List<Mod_Online_SchoolEntity>();//待添加的学校列表
            List<Mod_Online_School_MajorEntity> schoolMajorAddList = new List<Mod_Online_School_MajorEntity>();//学校专业待添加列表

            Mod_Online_ApplicationTypeBiz applicationTypeBiz = new Mod_Online_ApplicationTypeBiz();
            Mod_Online_SchoolBiz schoolBiz = new Mod_Online_SchoolBiz();//学校编号业务
            Mod_Online_YearPlan_DetailBiz detailBiz = new Mod_Online_YearPlan_DetailBiz();//详细业务
            Mod_Online_School_MajorBiz schoolMajorBiz = new Mod_Online_School_MajorBiz();//学校专业业务
            Mod_Online_YearPlan_Detail_MajorCodeBiz detailMajorCodeBiz = new Mod_Online_YearPlan_Detail_MajorCodeBiz();//专业要求业务

            int publicSchool = 0;//公办
            int privateSchool = 1;//私办

            StringBuilder strShcoolName = new StringBuilder();//学校名称
            StringBuilder strSchoolMajorName = new StringBuilder();//学校对应专业名称
            StringBuilder strCodeId = new StringBuilder();//专业课程要求代码

            // string cmdText = @"SELECT [报考类别],[院校名称],[院校类型],[专业名称],[计划数],[投档分数],[对报考者专科阶段所学专业等要求],[专业课程要求],[备注] FROM [Sheet1$];";
            string cmdText = @"SELECT [报考类别],[院校名称],[院校类型],[专业名称],[计划数],[对报考者专科阶段所学专业等要求],[专业课程要求],[备注] FROM [Sheet1$];";

            List<Mod_Online_ApplicationTypeEntity> applicationTypeList = applicationTypeBiz.GetList();//获取类型列表

            //更新的情况
            List<Mod_Online_YearPlan_DetailEntity> planDetailList = null;
            if (!isAdd)
            {
                planDetailList = detailBiz.GetYearPlanList(yearPlanModel.PlanId);//获取类型列表
            }

            using (OleDbDataReader dr = ExcelHelper.ReadExcel(FileHelper.GetMapPath(string.Format("~{0}", path)), cmdText))
            {
                while (dr.Read())
                {
                    Mod_Online_YearPlan_DetailEntity model = new Mod_Online_YearPlan_DetailEntity();
                    model.DetailId = StringHelper.GetGuid();
                    model.PlanId = yearPlanModel.PlanId;
                    model.YearId = yearPlanModel.YearId;

                    #region 报考类型
                    model.AppTypeName = StringHelper.TrimString(dr["报考类别"].ToString()).Trim();
                    Mod_Online_ApplicationTypeEntity tempApplicationType = applicationTypeList.Find(x => x.AppTypeName.Trim() == model.AppTypeName);
                    if (tempApplicationType != null)
                    {
                        model.AppTypeId = tempApplicationType.AppTypeId;
                    }
                    else
                    {

                        tempApplicationType = applicationTypeAddList.Find(x => x.AppTypeName.Trim() == model.AppTypeName);//查询已添加的类型中是否存在该类型
                        if (tempApplicationType != null)
                        {
                            model.AppTypeId = tempApplicationType.AppTypeId;
                        }
                        else
                        {
                            Mod_Online_ApplicationTypeEntity applicationType = new Mod_Online_ApplicationTypeEntity();
                            applicationType.AppTypeId = StringHelper.GetGuid();
                            applicationType.AppTypeName = model.AppTypeName;
                            applicationTypeAddList.Add(applicationType);
                            model.AppTypeId = applicationType.AppTypeId;

                        }
                    }
                    #endregion

                    //学校
                    model.SchoolName = StringHelper.TrimString(dr["院校名称"].ToString()).Trim();
                    model.SchoolType = StringHelper.TrimString(dr["院校类型"].ToString()).Trim() == "公办" ? publicSchool : privateSchool;
                    strShcoolName.AppendFormat("'{0}',", model.SchoolName);

                    //专业
                    model.SchoolMajorName = StringHelper.TrimString(dr["专业名称"].ToString()).Trim();
                    strSchoolMajorName.AppendFormat("'{0}',", model.SchoolMajorName);

                    string numbers = StringHelper.TrimString(dr["计划数"].ToString()).Trim();
                    //计划数
                    model.PlanNumber = string.IsNullOrEmpty(numbers) ? 0 : numbers.ToInt();

                    //投档分数
                    //string castScore = StringHelper.TrimString(dr["投档分数"].ToString()).Trim();
                    //model.CastScore = string.IsNullOrEmpty(castScore) ? 0 : castScore.ToDouble();
                    model.CastScore = 0;
                    string require = StringHelper.TrimString(dr["对报考者专科阶段所学专业等要求"].ToString()).Trim();
                    model.CandidateRequire = require;
                    string[] requires = require.Split('、');
                    foreach (string item in requires)
                    {
                        Mod_Online_YearPlan_Detail_MajorCodeEntity detailMajorCode = new Mod_Online_YearPlan_Detail_MajorCodeEntity();
                        detailMajorCode.Id = StringHelper.GetGuid();
                        if (item.Split('H').Length > 1)//防止出现中外合作办学情况
                        {
                            string[] codes = item.Split('H');
                            detailMajorCode.CodeId = string.Format("{0}H", codes[0]);
                            detailMajorCode.CodeName = codes[1];
                        }
                        else
                        {
                            detailMajorCode.CodeId = StringHelper.RemoveNotNumber(item);
                            detailMajorCode.CodeName = StringHelper.RemoveNumber(item);
                        }
                        detailMajorCode.DetailId = model.DetailId;
                        detailMajorCode.PlanId = model.PlanId;
                        detailMajorCode.YearId = model.YearId;
                        detailMajorCodeAddList.Add(detailMajorCode);
                        strCodeId.AppendFormat("'{0}',", detailMajorCode.CodeId);
                    }

                    model.MajorRequire = StringHelper.TrimString(dr["专业课程要求"].ToString()).Trim();
                    model.Remarks = StringHelper.TrimString(dr["备注"].ToString()).Trim();

                    addList.Add(model);
                }
            }

            List<Mod_Online_SchoolEntity> tempShcoolList = schoolBiz.GetSchoolList(strShcoolName.ToString().Trim().TrimEnd(','));
            List<Mod_Online_School_MajorEntity> tempShcoolMajorList = schoolMajorBiz.GetSchoolMajorList(strSchoolMajorName.ToString().Trim().TrimEnd(','));

            foreach (Mod_Online_YearPlan_DetailEntity import in addList)
            {
                Mod_Online_SchoolEntity tempschool = tempShcoolList.Find(x => x.SchoolName == import.SchoolName);
                if (tempschool == null)
                {
                    tempschool = shcoolAddList.Find(x => x.SchoolName == import.SchoolName);//从已添加的中查询，防止重复
                    if (tempschool == null)
                    {
                        tempschool = new Mod_Online_SchoolEntity();
                        tempschool.SchoolId = StringHelper.GetGuid();
                        tempschool.SchoolName = import.SchoolName;
                        tempschool.SchoolType = import.SchoolType;
                        shcoolAddList.Add(tempschool);
                    }
                }
                import.SchoolType = tempschool.SchoolType;
                import.SchoolId = tempschool.SchoolId;

                Mod_Online_School_MajorEntity tempschoolMajor = tempShcoolMajorList.Find(x => x.SchoolName == import.SchoolName && x.SchoolMajorName == import.SchoolMajorName);
                if (tempschoolMajor == null)
                {
                    //防止重复
                    tempschoolMajor = schoolMajorAddList.Find(x => x.SchoolName == import.SchoolName && x.SchoolMajorName == import.SchoolMajorName);
                    if (tempschoolMajor == null)
                    {
                        tempschoolMajor = new Mod_Online_School_MajorEntity();
                        tempschoolMajor.SchoolMajorId = StringHelper.GetGuid();
                        tempschoolMajor.SchoolMajorName = import.SchoolMajorName;
                        tempschoolMajor.SchoolId = import.SchoolId;
                        tempschoolMajor.SchoolName = import.SchoolName;
                        schoolMajorAddList.Add(tempschoolMajor);
                    }
                }
                import.SchoolMajorId = tempschoolMajor.SchoolMajorId;
            }

            return DBHelper.Transaction((dp, ex) =>
            {
                if (applicationTypeAddList.Count > 0)
                {
                    applicationTypeBiz.Add(applicationTypeAddList, dp);
                }

                if (shcoolAddList.Count > 0)
                {
                    schoolBiz.Add(shcoolAddList, dp);
                }

                if (schoolMajorAddList.Count > 0)
                {
                    schoolMajorBiz.Add(schoolMajorAddList, dp);
                }

                if (isAdd)
                {
                    this.Add(yearPlanModel, dp);
                    detailBiz.Add(addList, dp);
                    detailMajorCodeBiz.Add(detailMajorCodeAddList, dp);
                }
                else
                {
                    if (detailBiz.DelDetail(yearId, dp))
                    {
                        detailBiz.Add(addList, dp);
                    }
                    if (detailMajorCodeBiz.DelDetailMajorCode(yearId, dp))
                    {
                        detailMajorCodeBiz.Add(detailMajorCodeAddList, dp);
                    }
                }

            }) > 0;
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="planId">计划编号</param>
        /// <param name="stateFlag">状态</param>
        /// <returns>执行结果</returns>
        public bool UpdateState(string planId, int stateFlag)
        {
            SQL sql = SQL.Build("UPDATE Mod_Online_YearPlan SET StateFlag=? WHERE PlanId=? ", stateFlag, planId);
            return SqlMap<Mod_Online_YearPlanEntity>.ParseSql(sql).Execute() > 0;
        }

        /// <summary>
        /// Excel数据导入分数
        /// </summary>
        /// <param name="yearId">年度</param>
        /// <param name="path">相对路径</param>
        /// <returns>执行结果</returns>
        public bool ExcelScoreImport(string yearId, string path)
        {
            string cmdText = @"SELECT [科类名称],[学院名称],[专业名称],[投档分数] FROM [Sheet1$];";
            List<SQL> sqlList = new List<SQL>();
            double score = 0;
            using (OleDbDataReader dr = ExcelHelper.ReadExcel(FileHelper.GetMapPath(string.Format("~{0}", path)), cmdText))
            {
                while (dr.Read())
                {
                    score = StringHelper.TrimString(dr["投档分数"].ToString()).Trim().ToDouble();
                    sqlList.Add(SQL.Build("UPDATE Mod_Online_YearPlan_Detail SET CastScore=? WHERE AppTypeName=? AND SchoolName=? AND SchoolMajorName=? AND YearId=? ", score, StringHelper.TrimString(dr["科类名称"].ToString()).Trim(), StringHelper.TrimString(dr["学院名称"].ToString()).Trim(), StringHelper.TrimString(dr["专业名称"].ToString()).Trim(), yearId));
                }
            }
            if (sqlList.Count > 0)
            {
                return SqlMap<Mod_Online_YearPlan_DetailEntity>.ParseSql(sqlList).Execute() > 0;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 2018-06

        /// <summary>
        /// 删除计划
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public bool DeletePlan(string planId)
        {
            return DBHelper.Transaction((dp, ex) =>
            {
                this.Delete(planId, dp);
                SQL sql = SQL.Build("DELETE FROM [dbo].[Mod_Online_YearPlan_Detail] WHERE PlanId=?", planId);
                SqlMap<Mod_Online_YearPlanEntity>.ParseSql(sql).Execute(dp);
                SQL sql2 = SQL.Build("DELETE FROM [dbo].[Mod_Online_YearPlan_Detail_MajorCode] WHERE PlanId=?", planId);
                SqlMap<Mod_Online_YearPlanEntity>.ParseSql(sql2).Execute(dp);

            }) > 0;
        }


        /// <summary>
        /// 获取最新一条计划
        /// </summary>
        /// <returns>实体</returns>
        /// <remarks>2018.06.10</remarks>
        public Mod_Online_YearPlanEntity GetFirstYearPlanModel()
        {
            SQL sql = SQL.Build("SELECT top 1 * FROM Mod_Online_YearPlan order by [YearId] desc ");
            return SqlMap<Mod_Online_YearPlanEntity>.ParseSql(sql).ToObject();
        }
        #endregion
    }

}