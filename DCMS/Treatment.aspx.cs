using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCMSDataAccessLayer;
using System.Data.SqlClient;
using System.Data;

namespace DCMS
{
    public partial class Treatment : System.Web.UI.Page
    {
        TreatmentDAO treatment = new TreatmentDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadTreatments();
                panelAdd.Visible = false;
                panelUpdate.Visible = false;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            panelAdd.Visible = true;
            panelUpdate.Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            panelUpdate.Visible = true;
            panelAdd.Visible = false;
            ddlUpdName.Items.Clear();
            loadTreatmentNames();
        }

        protected void btnAddBack_Click(object sender, EventArgs e)
        {
            panelAdd.Visible = false;
            txtAddName.Text = "";
            txtAddCost.Text = "";
        }

        protected void btnAddConfirm_Click(object sender, EventArgs e)
        {
            if (!treatment.verifyTreatment(txtAddName.Text))
            {
                treatment.addTreatment(new TreatmentDTO(txtAddName.Text, Convert.ToInt32(txtAddCost.Text)));
                txtAddCost.Text = "";
                txtAddName.Text = "";
                loadTreatments();
            }
            else
            {
                lblMessage.Text = "Treatment already exists";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void loadTreatments()
        {
            gvTreatment.DataSource = treatment.getAllTreatments();
            gvTreatment.DataBind();
        }

        private void loadTreatmentNames()
        {
            ddlUpdName.DataSource = treatment.getTreatments();
            ddlUpdName.DataBind();
        }

        protected void btnUpdBack_Click(object sender, EventArgs e)
        {
            panelUpdate.Visible = false;
            txtUpdCost.Text = "";
            ddlUpdName.Items.Clear();
        }

        protected void btnUpdFetch_Click(object sender, EventArgs e)
        {
            txtUpdCost.Text = treatment.getCost(ddlUpdName.SelectedValue).ToString();
        }

        protected void btnUpdConfirm_Click(object sender, EventArgs e)
        {
            treatment.updateTreatment(new TreatmentDTO(ddlUpdName.SelectedValue, Convert.ToInt32(txtUpdCost.Text)));
            loadTreatments();
        }

        protected void ddlUpdName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUpdCost.Text = treatment.getCost(ddlUpdName.SelectedValue).ToString();
        }

        protected void gvTreatment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.fontWeight = 'bold';");
                e.Row.Attributes.Add("onmouseout", "this.style.fontWeight= 'normal';");
            }
        }
    }
}