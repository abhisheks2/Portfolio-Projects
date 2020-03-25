using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCMSDataAccessLayer;

namespace DCMS
{
    public partial class DCMSMasterPage : System.Web.UI.MasterPage
    {
        static string loggedIn = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (loggedIn == "") loggedIn = Session["User"].ToString();
            if (new UsersDAO().verifyAdmin(loggedIn))
            {
                doctorsLink.Visible = true;
                patientLink.Visible = true;
                addUserLink.Visible = true;
                doctorsLinkDisabled.Visible = false;
                patientLinkDisabled.Visible = false;
                addUserLinkDisabled.Visible = false;
            }
            else
            {
                doctorsLink.Visible = false;
                patientLink.Visible = false;
                addUserLink.Visible = false;
                doctorsLinkDisabled.Visible = true;
                patientLinkDisabled.Visible = true;
                addUserLinkDisabled.Visible = true;
            }
        }
        protected void signOut_Click(object sender, EventArgs e)
        {
            loggedIn = "";
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
        protected void PassChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("Password.aspx");
        }
        protected void homeImg_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void logoImg_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("http://abhishekshrivastava.co.uk/");
            Response.Redirect("Home.aspx");
        }
    }
}