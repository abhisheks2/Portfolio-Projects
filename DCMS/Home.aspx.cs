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
            Response.Redirect("Login.aspx");
        }
        protected void btnPatientAccess_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientLogin.aspx");
        }

        protected void logoImg_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("http://abhishekshrivastava.co.uk/");
            Response.Redirect("Home.aspx");
        }

        protected void btnNewPatient_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientRegistration.aspx");
        }
    }
}