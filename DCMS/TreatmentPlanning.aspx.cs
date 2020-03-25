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
    public partial class TreatmentPlanning : System.Web.UI.Page
    {
        string user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                user = Session["User"].ToString();
                if (user == "admin")
                {
                    ddlDoctor.Visible = true;
                    lblDoctor.Visible = true;
                    DataSet dsDoctor = new DoctorDAO().getDocs();
                    ddlDoctor.DataSource = dsDoctor;
                    ddlDoctor.DataTextField = "name";
                    ddlDoctor.DataValueField = "docID";
                    ddlDoctor.DataBind();
                }
                else
                {
                    ddlDoctor.Visible = false;
                    lblDoctor.Visible = false;
                }

                DataSet dsPatient = new PatientDAO().getPatients();
                ddlPatient.DataSource = dsPatient;
                ddlPatient.DataTextField = "Name";
                ddlPatient.DataValueField = "ID";
                ddlPatient.DataBind();

                DataSet dsTreatment = new TreatmentDAO().getAllTreatments();
                ddlTreatment.DataSource = dsTreatment;
                ddlTreatment.DataTextField = "Name";
                ddlTreatment.DataValueField = "Name";
                ddlTreatment.DataBind();
                ddlTreatment.Items.Insert(0, "Please select a treatment");
            }
        }

        protected void ddlTreatment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTreatment.SelectedValue != "Please select a treatment")
            {
                txtCost.Text = new TreatmentDAO().getCost(ddlTreatment.SelectedValue).ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ddlTreatment.SelectedValue != "Please select a treatment")
            {
                string treatment = ddlTreatment.SelectedValue;
                int pID = Convert.ToInt32(ddlPatient.SelectedValue);
                user = Session["User"].ToString();
                int dID;
                if (user == "admin")
                {
                    dID = Convert.ToInt32(ddlDoctor.SelectedValue);
                }
                else
                {
                    dID = new DoctorDAO().getID(user);
                }
                string tooth = ddlTooth.SelectedValue;
                int quantity = 1;
                int cost = Convert.ToInt32(txtCost.Text);
                int paid = 0;
                if (new TreatmentPlanningDAO().createTreatmentPlan(new TreatmentPlanningDTO(treatment, pID, dID, tooth, quantity, cost, paid)))
                {
                    lblMessage.Text = "Treatment plan created";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Treatment planning not created";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMessage.Text = "Please select a valid treatment";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            
        }
    }
}