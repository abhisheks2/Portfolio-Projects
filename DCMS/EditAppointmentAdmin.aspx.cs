using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCMSDataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace DCMS
{
    public partial class EditAppointmentAdmin : System.Web.UI.Page
    {
        string[] times = new string[] { "9:00am", "10:00am", "11:00am", "12:00pm", "1:00pm", "2:00pm", "3:00pm", "4:00pm", "5:00pm" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new AppointmentDAO().appointmentsExist();
                if (ds.Tables[0].Rows.Count == 0)
                {
                    new AppointmentDAO().addRows();
                }
                else
                {
                    new AppointmentDAO().appendRows();
                }
                List<string> arrList = new List<string>();
                for (int i = 0; i < 7; i++)
                {
                    arrList.Add(System.DateTime.Today.AddDays(i).ToString("dd-MM-yyyy"));
                }

                ddlDate.DataSource = arrList;
                ddlDate.DataBind();

                ddlDoctor.DataSource = new DoctorDAO().getDoctors();
                ddlDoctor.DataBind();
            }
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbPatientID.Text);
            tbPatientName.Text = new PatientDAO().getName(id);
            string[] d = new string[3];
            string app = "";
            d = new AppointmentDAO().find(id);
            app += "Doctor's Name: " + d[0] + "\n";
            app += "Patient's Name: " + new PatientDAO().getName(id) + "\n";
            app += "Date: " + d[1] + "\n";
            app += "Time: " + d[2] + "\n";
            Appoint.InnerText = app;

        }
        protected void Fetch_Click(object sender, EventArgs e)
        {
            string date = ddlDate.SelectedValue.ToString();
            string doc = ddlDoctor.SelectedValue.ToString();
            DataSet d = new AppointmentDAO().getRows(new AppointmentDTO(doc, date));
            ddlTime.Items.Clear();
            for (int i = 0; i < 12; i++)
            {
                //if (Convert.ToInt32(d.Tables[0].Rows[0][i + 2]) == 0) ddlTime.Items.Add(times[i]);
                ddlTime.Items.Add(times[i]);
            }
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbPatientID.Text);
            string[] d = new string[3];
            d = new AppointmentDAO().find(id);
            if (new AppointmentDAO().deleteAppointment(id)) //Abhi to replace id by appointmentID
            {
                string date = ddlDate.SelectedValue.ToString();
                string doc = ddlDoctor.SelectedValue.ToString();
                string time = ddlTime.SelectedValue.ToString();
                if (new AppointmentDAO().getApp(new AppointmentDTO(doc, date, time, id)))
                {
                    string app = "";
                    d = new AppointmentDAO().find(id);
                    app += "Doctor's Name: " + d[0] + "\n";
                    app += "Patient's Name: " + new PatientDAO().getName(id) + "\n";
                    app += "Date: " + d[1] + "\n";
                    app += "Time: " + d[2] + "\n";
                    Appoint.InnerText = app;
                    Response.Redirect("ViewAppointments.aspx");
                }
                else Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('ERROR!!!');</script>");
            }
            else Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('ERROR!!!');</script>");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbPatientID.Text);
            string[] d = new string[3];
            d = new AppointmentDAO().find(id);
            if (new AppointmentDAO().deleteAppointment(id)) //Abhi to replace id by appointmentID
            {
                Appoint.InnerText = "";
                Response.Redirect("ViewAppointments.aspx");
            }
            else Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('ERROR!!!');</script>");
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAppointments.aspx");
        }
    }
}