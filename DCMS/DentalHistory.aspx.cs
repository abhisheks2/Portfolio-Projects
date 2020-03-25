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
    public partial class DentalHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dsPatient = new PatientDAO().getPatients();
                ddlPatient.DataSource = dsPatient;
                ddlPatient.DataTextField = "name";
                ddlPatient.DataValueField = "id";
                ddlPatient.DataBind();
                ddlPatient.Items.Insert(0, "Please select a patient");
                txtMedInfo.Visible = false;
            }
        }

        protected void ddlPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPatient.SelectedValue != "Please select a patient")
            {
                int pID = Convert.ToInt32(ddlPatient.SelectedValue);
                txtMedInfo.Text = new PatientDAO().getMedInfo(pID);
                txtMedInfo.Visible = true;
                DataTable dt = new TreatmentPlanningDAO().getTreatmentPlansByPatient(pID);
                if (dt.Rows.Count > 0)
                {
                    lblMessage.Text = "";
                }
                else
                {
                    lblMessage.Text = "No dental history";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                gvPatientHistory.DataSource = dt;
                gvPatientHistory.DataBind();
            }
            else
            {
                gvPatientHistory.DataSource = null;
                gvPatientHistory.DataBind();
                lblMessage.Text = "";
                txtMedInfo.Visible = false;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}