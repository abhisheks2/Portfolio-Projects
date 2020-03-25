using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCMSDataAccessLayer;
using System.Data;

namespace DCMS
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblDoctor.Visible = false;
                ddlDoctor.Visible = false;
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
        protected void Confirm_Click(object sender, EventArgs e)
        {
            string user = Name.Text;
            string pass = Pass.Text;
            string role = ddlRole.SelectedValue;
            int DoctorID = 0;
            if (role == "doctor")
            {
                DoctorID = Convert.ToInt32(ddlDoctor.SelectedValue);
            }
            
            if (pass.Equals(CPass.Text))
            {
                if (new UsersDAO().addUser(new UsersDTO(user, pass, role, DoctorID)))
                {
                    lblMessage.Text = "User added";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "User not added";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMessage.Text = "Passwords don't match";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRole.SelectedValue == "doctor")
            {
                ddlDoctor.Visible = true;
                lblDoctor.Visible = true;
                ddlDoctor.DataSource = new DoctorDAO().getDocIDs();
                ddlDoctor.DataTextField = "DocID";
                ddlDoctor.DataValueField = "DocID";
                ddlDoctor.DataBind();
                ddlDoctor.Items.Insert(0, "Please select a doctor");
            }
            else
            {
                lblDoctor.Visible = false;
                ddlDoctor.Visible = false;
            }
        }

        protected void ddlDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDoctor.SelectedValue != "Please select a doctor")
            {
                DataSet ds = new DoctorDAO().getInfoID(Convert.ToInt32(ddlDoctor.SelectedValue));
                Name.Text = ds.Tables[0].Rows[0]["name"].ToString();
                Name.Enabled = false;
            }
        }
    }
}