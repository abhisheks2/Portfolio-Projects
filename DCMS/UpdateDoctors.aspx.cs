using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCMSDataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace DCMS
{
    public partial class UpdateDoctors : System.Web.UI.Page
    {
        DoctorDAO doctorObj = new DoctorDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlDocID.DataSource = doctorObj.getDocIDs();
                ddlDocID.DataBind();
            }
        }
        
        protected void Fetch_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int id = Convert.ToInt32(ddlDocID.SelectedValue);
            DataSet ds = new DataSet();
            if (txtName.Text == "")
            {
                ds = doctorObj.getInfoID(id);
            }
            else
            {
                ds = doctorObj.getInfoNameID(id, name);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
                tbSalary.Text = ds.Tables[0].Rows[0]["Salary"].ToString();
                cbxAvailable.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Available"]);
            }
            else
            {
                lblMessage.Text = "No match found";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                tbSalary.Text = "";
            }
        }
        protected void Confirm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                if (!string.IsNullOrEmpty(tbSalary.Text))
                {
                    string name = txtName.Text;
                    int salary = Convert.ToInt32(tbSalary.Text);
                    int id = Convert.ToInt32(ddlDocID.SelectedValue);
                    if (doctorObj.update(new DoctorDTO(id, name, salary, cbxAvailable.Checked)))
                    {
                        Response.Redirect("Doctors.aspx");
                    }
                }
                else
                {
                    lblMessage.Text = "Please enter value for Name and Salary";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            tbSalary.Text = "";
            txtName.Text = "";
            ddlDocID.Items.Clear();
            Response.Redirect("Doctors.aspx");
        }

        protected void ddlDocID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlDocID.SelectedValue);
            DataSet ds = doctorObj.getInfoID(id);
            txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
            tbSalary.Text = ds.Tables[0].Rows[0]["Salary"].ToString();
            cbxAvailable.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Available"]);
        }
    }
}