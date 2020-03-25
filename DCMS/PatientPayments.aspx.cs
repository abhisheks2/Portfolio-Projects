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
    public partial class PatientPayments : System.Web.UI.Page
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
                dvReceivePayment.Visible = false;
            }
        }

        protected void ddlPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessageDV.Text = "";
            lblMessageDV.ForeColor = System.Drawing.Color.Green;
            dvReceivePayment.DataSource = null;
            dvReceivePayment.DataBind();
            if (ddlPatient.SelectedValue != "Please select a patient")
            {
                loadTreatmentPlansbyPatient();
            }
            else
            {
                gvPatientHistory.DataSource = null;
                gvPatientHistory.DataBind();
                lblMessageGV.Text = "";
            }
        }

        private void loadTreatmentPlansbyPatient()
        {
            int pID = Convert.ToInt32(ddlPatient.SelectedValue);
            DataTable dt = new TreatmentPlanningDAO().getTreatmentPlansByPatient(pID);
            if (dt.Rows.Count > 0)
            {
                lblMessageGV.Text = "";
                lblMessageGV.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessageGV.Text = "New patient or no treatments ever done";
                lblMessageGV.ForeColor = System.Drawing.Color.Red;
            }
            gvPatientHistory.DataSource = dt;
            gvPatientHistory.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void gvPatientHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblMessageDV.Text = "";
            lblMessageDV.ForeColor = System.Drawing.Color.Green;
            if (e.CommandName == "ReceivePayment")
            {
                int tID = Convert.ToInt32(e.CommandArgument);
                string tName = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).Cells[1].Text;
                Session["tName"] = tName;
                DataSet ds = new TreatmentPlanningDAO().getPlanforPayment(tName, tID);
                dvReceivePayment.DataSource = ds;
                dvReceivePayment.ChangeMode(DetailsViewMode.Edit);
                dvReceivePayment.DataBind();
                dvReceivePayment.Visible = true;
            }
        }

        protected void dvReceivePayment_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (e.NewMode == DetailsViewMode.ReadOnly)
            {
                dvReceivePayment.DataSource = null;
                dvReceivePayment.ChangeMode(e.NewMode);
                dvReceivePayment.DataBind();
                dvReceivePayment.Visible = false;
                Session["tName"] = "";
                lblMessageDV.Text = "";
                lblMessageDV.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void dvReceivePayment_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            //int tID = Convert.ToInt32(dvReceivePayment.SelectedValue); //this also works to get tID
            int tID = Convert.ToInt32(e.Keys["tID"]);
            int paid = Convert.ToInt32(e.NewValues["paid"]);
            string tName = Session["tName"].ToString();
            bool updateSuccess = new TreatmentPlanningDAO().updatePlanforPayment(tName, tID, paid);
            lblMessageDV.Text = "Payment updated";
            lblMessageDV.ForeColor = System.Drawing.Color.Green;
            dvReceivePayment.DataSource = null;
            dvReceivePayment.ChangeMode(DetailsViewMode.ReadOnly);
            dvReceivePayment.DataBind();
            dvReceivePayment.Visible = false;
            loadTreatmentPlansbyPatient();
            Session["tName"] = "";
        }
    }
}