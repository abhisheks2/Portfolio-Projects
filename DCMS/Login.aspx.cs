using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCMSDataAccessLayer;

namespace DCMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                USER.Focus();
        }
        protected void Log_Click(object sender, EventArgs e)
        {
            string user = USER.Text;
            Session["User"] = user;
            string pass = PASS.Text;
            if (new UsersDAO().verifyUser(user, pass))
            {

                Response.Redirect("Menu.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Wrong User Name or Password!!! Please recheck!');</script>");
            }
        }
    }
}