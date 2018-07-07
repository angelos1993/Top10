using System;
using System.Collections.Generic;
using System.Web;

namespace Top10
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["LoggedInUsers"] = new List<int>();
        }
    }
}