using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DCMS
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"].ToString() == "admin")
            {
                lblMessage.Text = "Administartor";
            }
            else
            {
                lblMessage.Text = "Dentist";
            }
            //lblMessage.Text = Session["User"].ToString();
        }
    }
}