using System;
using System.IO;
using System.Globalization;


namespace DCMS
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            string errorText = System.DateTime.Now.ToString() + "\r\n" + ex.InnerException + "\r\n" +
            "----------------------------------------------------------------------------------------------------------------------------------" + "\r\n";
            Server.ClearError();
            File.AppendAllText(Server.MapPath("~/ErrorLog.txt"), errorText);
            Session["User"] = null;
            Session["PatientID"] = null;
            Response.Redirect("ErrorPage.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}