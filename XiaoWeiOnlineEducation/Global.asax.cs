using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace XiaoWeiOnlineEducation
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Brilliant.ORM.Log.Enable = true;//开启或者关闭SQL日志
        }
    }
}