﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoWeiOnlineEducation.Entity
{
    public class Mod_Online_YearPlan_DetailEntityExt : Mod_Online_YearPlan_DetailEntity
    {
        /// <summary>
        /// 行号
        /// </summary>
        public int RowNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 去年投档分数
        /// </summary>
        public double LastYearScore
        {
            get { return GetProperty<double>("LastYearScore"); }
            set { SetProperty("LastYearScore", value); }
        }

        /// <summary>
        /// 两年前投档分数
        /// </summary>
        public double TwoYearsAgoScore
        {
            get { return GetProperty<double>("TwoYearsAgoScore"); }
            set { SetProperty("TwoYearsAgoScore", value); }
        }

        /// <summary>
        /// 三年前投档分数
        /// </summary>
        public double ThreeYearsAgoScore
        {
            get { return GetProperty<double>("ThreeYearsAgoScore"); }
            set { SetProperty("ThreeYearsAgoScore", value); }
        }


    }
}
