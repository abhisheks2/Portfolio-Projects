using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCMSDataAccessLayer;

namespace DCMS
{
    public partial class Password : System.Web.UI.Page
    {
        string _user = "", _pass = "", _newPass = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            _user = Session["User"].ToString();
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
        protected void Confirm_Click(object sender, EventArgs e)
        {
            _user = Session["User"].ToString();
            _pass = PASS.Text;
            _newPass = Newpass.Text;
            if (new UsersDAO().changePass(_user, _pass, _newPass))
            {
                lblMessage.Text = "Password changed successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "Password not changed";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}