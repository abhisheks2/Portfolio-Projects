using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DCMS
{
    public partial class PatientMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("PatientLogin.aspx");
        }
    }
}