using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCMSDataAccessLayer;

namespace DCMS
{
    public partial class AddDoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Confirm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (new DoctorDAO().add(new DoctorDTO(0, tbName.Text, Convert.ToInt32(tbSalary.Text), true)))
                {
                    Response.Redirect("Doctors.aspx");
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbSalary.Text = "";
            Response.Redirect("Doctors.aspx");
        }
    }
}