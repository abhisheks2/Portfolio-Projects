using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCMSDataAccessLayer;

namespace DCMS
{
    public partial class PatientLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Log_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text;
            int id = Convert.ToInt32(tbID.Text);
            if (new PatientDAO().verifyPatient(email, id))
            {
                Session["PatientID"] = id;
                Response.Redirect("PatientHome.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Email & ID does not match!');</script>");
            }
        }
    }
}