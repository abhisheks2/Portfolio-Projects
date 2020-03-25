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
    public partial class PatientDentalHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int pID = Convert.ToInt32(Session["PatientID"]);
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
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientHome.aspx");
        }
    }
}