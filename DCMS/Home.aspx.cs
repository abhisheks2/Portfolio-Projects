using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DCMS
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Session["User"] = "admin";
            Response.Redirect("Menu.aspx");
            //Response.Redirect("Login.aspx");
        }
        protected void btnAdmin1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnDentist_Click(object sender, EventArgs e)
        {
            Session["User"] = "Doc1";
            Response.Redirect("Menu.aspx");
        }
        protected void btnDentist1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnDefaultPatient_Click(object sender, EventArgs e)
        {
            Session["PatientID"] = 3;
            Response.Redirect("PatientHome.aspx");
        }
        protected void btnPatientAccess_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientLogin.aspx");
        }

        protected void btnNewPatient_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientRegistration.aspx");
        }

        protected void logoImg_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("http://abhishekshrivastava.co.uk/");
            Response.Redirect("Home.aspx");
        }
    }
}