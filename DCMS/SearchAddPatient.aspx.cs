using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCMSDataAccessLayer;

namespace DCMS
{
    public partial class SearchAddPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbEmail.Text != "")
            {
                if (new PatientDAO().verifyPatientEmail(tbEmail.Text))
                {
                    Session["searchEmail"] = tbEmail.Text;
                    Response.Redirect("ShowPatientDetails.aspx");
                }
                else
                {
                    lblMessage.Text = "Patient with email: " + tbEmail.Text + " not found";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMessage.Text = "Please enter a valid email to search";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void add_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewPatient.aspx");
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
        protected void list_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowPatients.aspx");
        }

    }
}