using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCMSDataAccessLayer;

namespace DCMS
{
    public partial class AddTreatment : System.Web.UI.Page
    {
        TreatmentDAO treatment = new TreatmentDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Confirm_Click(object sender, EventArgs e)
        {
            if (!treatment.verifyTreatment(tbName.Text))
            {
                treatment.addTreatment(new TreatmentDTO(tbName.Text, Convert.ToInt32(tbCost.Text)));
                Response.Redirect("Treatment.aspx");
            }
            else
            {
                lblMessage.Text = "Treatment already exists";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}