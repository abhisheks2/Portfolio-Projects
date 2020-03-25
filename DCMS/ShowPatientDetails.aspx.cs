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
    public partial class ShowPatientDetails : System.Web.UI.Page
    {
        string emailPatient = "";
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                emailPatient = Session["searchEmail"].ToString();
                DataSet D = new DataSet();
                D = new PatientDAO().getPatient(emailPatient);
                
                if (D.Tables[0].Rows.Count > 0)
                {
                    id = Convert.ToInt32(D.Tables[0].Rows[0]["id"]);
                    tbID.Text = D.Tables[0].Rows[0]["id"].ToString();
                    tbName.Text = D.Tables[0].Rows[0]["name"].ToString();
                    tbEmail.Text = D.Tables[0].Rows[0]["email"].ToString();
                    tbDOB.Text = Convert.ToDateTime(D.Tables[0].Rows[0]["dob"]).ToString("dd/MM/yyyy");
                    tbAddress.Text = D.Tables[0].Rows[0]["address"].ToString();
                    tbContactNo.Text = D.Tables[0].Rows[0]["contactNo"].ToString();
                    tbAge.Text = D.Tables[0].Rows[0]["age"].ToString();
                    tbSex.Text = D.Tables[0].Rows[0]["sex"].ToString();
                    tbMaritalStatus.Text = D.Tables[0].Rows[0]["maritalStatus"].ToString();
                    tbOccupation.Text = D.Tables[0].Rows[0]["occupation"].ToString();
                    MedInfo.InnerText = D.Tables[0].Rows[0]["medInfo"].ToString();
                }
            }
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string address = tbAddress.Text;
            string contactNo = tbContactNo.Text;
            int age = Convert.ToInt32(tbAge.Text);
            string sex = tbSex.Text;
            string mStatus = tbMaritalStatus.Text;
            string occ = tbOccupation.Text;
            string medInfo = MedInfo.InnerText;
            emailPatient = tbEmail.Text;
            string dob = Convert.ToDateTime(tbDOB.Text).ToString("yyyy/MM/dd");
            if (new PatientDAO().updatePatient(id, new PatientDTO(name, address, contactNo, age, sex, mStatus, occ, medInfo, emailPatient, dob)))
            {
                Response.Redirect("SearchAddPatient.aspx");
                Session["searchEmail"] = emailPatient;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Update Error!! Please try again!!!');</script>");
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchAddPatient.aspx");
        }
        protected void History_Click(object sender, EventArgs e)
        {
            emailPatient = Session["searchEmail"].ToString();
            DataSet D = new DataSet();
            D = new PatientDAO().getPatient(emailPatient);
            id = Convert.ToInt32(D.Tables[0].Rows[0][0]);
            Response.Redirect("DentalHistory.aspx?id=" + id);
        }
    }
}