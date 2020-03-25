using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.IO;

namespace JobPortal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            HttpContext ctx = HttpContext.Current;
            
            Exception ex = ctx.Server.GetLastError();
            string errorText = System.DateTime.Now.ToString() + "\r\n" + ex + "\r\n" +
            "----------------------------------------------------------------------------------------------------------------------------------" + "\r\n";
            File.AppendAllText(Server.MapPath("~/ErrorLog.txt"), errorText);
            
            ctx.Server.ClearError();
            ctx.ClearError();
            ctx.Request.Cookies.Clear();
            ctx.Response.Cookies.Clear();
            ctx.Response.Clear();

            ctx.Response.Redirect("/Error/ErrorPage");
        }
    }
}
