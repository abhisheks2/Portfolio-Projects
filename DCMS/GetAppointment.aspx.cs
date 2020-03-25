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
    public partial class GetAppointment : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Session["PatientID"]);
                List<string> arrList = new List<string>();
                DataSet ds = new AppointmentDAO().appointmentsExist();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    arrList.Add("Please select a date");
                    foreach (DataRow dRow in ds.Tables[0].Rows)
                    {
                        if (Convert.ToDateTime(dRow["date"]) >= System.DateTime.Today)
                        {
                            //arrList.Add(dRow["date"].ToString());
                            arrList.Add(Convert.ToDateTime(dRow["date"]).ToString("dd-MM-yyyy"));
                        }
                    }
                    ddlDate.DataSource = arrList;
                    ddlDate.DataBind();
                }
                else
                {
                    lblMessage.Text = "No appointment available, please try again later when admin has released next week slots";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    ddlDate.Visible = false;
                    lblDate.Visible = false;
                }
                
                ddlDoctor.Visible = false;
                lblDoctor.Visible = false;
                ddlTime.Visible = false;
                lblTime.Visible = false;
            }
        }
        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDate.SelectedValue != "Please select a date")
            {
                string date = Convert.ToDateTime(ddlDate.SelectedValue).ToString("yyyy-MM-dd");
                DataSet ds = new AppointmentDAO().getAvlDoctors(date);
                ddlDoctor.DataSource = ds;
                ddlDoctor.DataBind();
                ddlDoctor.Items.Insert(0,"Please select a Doctor");
                ddlDoctor.Visible = true;
                lblDoctor.Visible = true;
                ddlTime.Visible = false;
                lblTime.Visible = false;

            }
        }
        protected void ddlDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDoctor.SelectedValue != "Please select a Doctor")
            {
                string date = Convert.ToDateTime(ddlDate.SelectedValue).ToString("yyyy-MM-dd");
                DataSet ds = new AppointmentDAO().getAppointmentTimes(date, ddlDoctor.SelectedValue);
                ddlTime.DataSource = ds;
                ddlTime.DataBind();
                ddlTime.Visible = true;
                lblTime.Visible = true;
            }
        }
        
        protected void Ok_Click(object sender, EventArgs e)
        {
            string date = Convert.ToDateTime(ddlDate.SelectedValue).ToString("yyyy-MM-dd");
            string doc = ddlDoctor.SelectedValue.ToString();
            string time = ddlTime.SelectedValue.ToString();
            id = Convert.ToInt32(Session["PatientID"]);
            if (new AppointmentDAO().getApp(new AppointmentDTO(doc, date, time, id)))
            {
                lblMessage.Text = "Appointment booked";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "Appointment can't be booked at the moment, please try again later";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientHome.aspx");
        }
    }
}