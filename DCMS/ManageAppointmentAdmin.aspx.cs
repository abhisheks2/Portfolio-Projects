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
    public partial class ManageAppointmentAdmin : System.Web.UI.Page
    {
        //Global varaibles-------------------------------------------------------------------------------------------------------//
        int pid;
        string loadornot = "";
        string selectedDate = "";
        string selectedDoctor = "";
        bool lblValidate = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlDate1.Visible = false;
                ddlDoctor1.Visible = false;
                ddlPatient1.Visible = false;
            }
        }
        
        //page top button events---------------------------------------------------------------------------------------------------------//
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
        protected void btnGenerateAppointments_Click(object sender, EventArgs e)
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
            lblMessage.Text = "Appointments generated";
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }
        protected void btnAppointmentPatient_Click(object sender, EventArgs e)
        {
            ddlDoctor1.Visible = false;
            ddlDate1.Visible = false;
            ddlPatient1.Visible = true;
            lblMessage.Text = "";
            gvAppointments.DataSource = null;
            gvAppointments.DataBind();
            DataSet ds = new PatientDAO().getPatients();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPatient1.DataSource = ds;
                ddlPatient1.DataTextField = "Name";
                ddlPatient1.DataValueField = "ID";
                ddlPatient1.DataBind();
                ddlPatient1.Items.Insert(0, "Please select a patient");
            }
        }
        protected void btnAppointmentDoc_Click(object sender, EventArgs e)
        {
            ddlDoctor1.Visible = true;
            ddlDate1.Visible = false;
            ddlPatient1.Visible = false;
            lblMessage.Text = "";
            gvAppointments.DataSource = null;
            gvAppointments.DataBind();
            DataSet ds = new DoctorDAO().getDocs();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDoctor1.DataSource = ds;
                ddlDoctor1.DataTextField = "name";
                ddlDoctor1.DataValueField = "name";
                ddlDoctor1.DataBind();
                ddlDoctor1.Items.Insert(0, "Please select a doctor");
            }
        }
        protected void btnAppointmentDate_Click(object sender, EventArgs e)
        {
            ddlDoctor1.Visible = false;
            ddlDate1.Visible = true;
            ddlPatient1.Visible = false;
            lblMessage.Text = "";
            gvAppointments.DataSource = null;
            gvAppointments.DataBind();
            DataSet ds = new AppointmentDAO().getDates();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDate1.DataSource = ds;
                ddlDate1.DataTextField = "date";
                ddlDate1.DataValueField = "date";
                ddlDate1.DataBind();
                ddlDate1.Items.Insert(0, "Please select a date");
            }
        }

        //dropdownlist events for filtering and selecting data for gridview-----------------------------------------------------------------//
        protected void ddlPatient1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            gvAppointments.DataSource = null;
            gvAppointments.DataBind();
            if (ddlPatient1.SelectedValue != "Please select a patient")
            {
                getAppointments();
            }
        }
        protected void ddlDate1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            gvAppointments.DataSource = null;
            gvAppointments.DataBind();
            if (ddlDate1.SelectedValue != "Please select a date")
            {
                getAppointmentsbyDate();
            }
        }
        protected void ddlDoctor1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            gvAppointments.DataSource = null;
            gvAppointments.DataBind();
            if (ddlDoctor1.SelectedValue != "Please select a doctor")
            {
                getAppointmentsbyDoctor();
            }
        }

        //load and bind gridview private methods------------------------------------------------------------------------------------//
        private void getAppointments()
        {
            pid = Convert.ToInt32(ddlPatient1.SelectedValue);
            DataSet ds = new AppointmentDAO().appointmentsByPatientID(pid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dRow in ds.Tables[0].Rows)
                {
                    if (Convert.ToDateTime(dRow["date"]) < System.DateTime.Today)
                    {
                        dRow.Delete();
                    }
                }
                ds.AcceptChanges();
            }
            else
            {
                if (lblValidate)
                {
                    lblMessage.Text = "No Appointments for selected patient";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            gvAppointments.DataSource = ds;
            gvAppointments.DataBind();
        }
        private void getAppointmentsbyDate()
        {
            string date = ddlDate1.SelectedValue;
            DataSet ds = new AppointmentDAO().appointmentsByDate(date);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dRow in ds.Tables[0].Rows)
                {
                    if (Convert.ToDateTime(dRow["date"]) < System.DateTime.Today)
                    {
                        dRow.Delete();
                    }
                }
                ds.AcceptChanges();
            }
            else
            {
                if (lblValidate)
                {
                    lblMessage.Text = "No Appointments for selected date";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            gvAppointments.DataSource = ds;
            gvAppointments.DataBind();
        }
        private void getAppointmentsbyDoctor()
        {
            string name = ddlDoctor1.SelectedValue;
            DataSet ds = new AppointmentDAO().appointmentsByDoctor(name);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dRow in ds.Tables[0].Rows)
                {
                    if (Convert.ToDateTime(dRow["date"]) < System.DateTime.Today)
                    {
                        dRow.Delete();
                    }
                }
                ds.AcceptChanges();
            }
            else
            {
                if (lblValidate)
                {
                    lblMessage.Text = "No Appointments for selected dentist";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            gvAppointments.DataSource = ds;
            gvAppointments.DataBind();
        }

        //gridview gvAppointments events---------------------------------------------------------------------------------------------------//
        protected void gvAppointments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            if (e.CommandName == "EditRow")
            {
                gvAppointments.EditIndex = rowIndex;
                if (ddlDate1.Visible)
                {
                    getAppointmentsbyDate();
                }
                else if (ddlDoctor1.Visible)
                {
                    getAppointmentsbyDoctor();
                }
                else if (ddlPatient1.Visible)
                {
                    getAppointments();
                }
            }
            else if (e.CommandName == "CancelUpdate")
            {
                gvAppointments.EditIndex = -1;
                if (ddlDate1.Visible)
                {
                    getAppointmentsbyDate();
                }
                else if (ddlDoctor1.Visible)
                {
                    getAppointmentsbyDoctor();
                }
                else if (ddlPatient1.Visible)
                {
                    getAppointments();
                }
            }
            else if (e.CommandName == "DeleteRow")
            {
                int appointmentID = Convert.ToInt32(e.CommandArgument);
                if (new AppointmentDAO().deleteAppointment(appointmentID))
                {
                    lblMessage.Text = "Appointment: " + appointmentID + " deleted";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    if (ddlDate1.Visible)
                    {
                        getAppointmentsbyDate();
                    }
                    else if (ddlDoctor1.Visible)
                    {
                        getAppointmentsbyDoctor();
                    }
                    else if (ddlPatient1.Visible)
                    {
                        getAppointments();
                    }
                }
                else
                {
                    lblMessage.Text = "Appointment: " + appointmentID + "  not deleted";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else if (e.CommandName == "UpdateRow")
            {
                int appointmentID = Convert.ToInt32(e.CommandArgument);
                int patientID = Convert.ToInt32(((Label)gvAppointments.Rows[rowIndex].FindControl("lblPID")).Text);
                string date = ((DropDownList)gvAppointments.Rows[rowIndex].FindControl("ddlDate")).SelectedValue;
                string time = ((DropDownList)gvAppointments.Rows[rowIndex].FindControl("ddlTime")).SelectedValue;
                string name = ((DropDownList)gvAppointments.Rows[rowIndex].FindControl("ddlDoctor")).SelectedValue;
                if (new AppointmentDAO().updateAppointment(new AppointmentDTO(name, date, time, patientID, appointmentID)))
                {
                    lblMessage.Text = "Appointment: " + appointmentID + " updated";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    gvAppointments.EditIndex = -1;
                    if (ddlDate1.Visible)
                    {
                        getAppointmentsbyDate();
                    }
                    else if (ddlDoctor1.Visible)
                    {
                        getAppointmentsbyDoctor();
                    }
                    else if (ddlPatient1.Visible)
                    {
                        getAppointments();
                    }
                }
                else
                {
                    lblMessage.Text = "Appointment: " + appointmentID + " not updated";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void gvAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gvAppointments.EditIndex = gvAppointments.SelectedIndex;
        }
        protected void gvAppointments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.fontWeight = 'bold';");
                e.Row.Attributes.Add("onmouseout", "this.style.fontWeight= 'normal';");
            }
            if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit && e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlDate = (DropDownList)e.Row.FindControl("ddlDate");
                List<string> arrList = new List<string>();
                DataSet dsDate = new AppointmentDAO().appointmentsExist();
                if (dsDate.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dRow in dsDate.Tables[0].Rows)
                    {
                        if (Convert.ToDateTime(dRow["date"]) >= System.DateTime.Today)
                        {
                            arrList.Add(dRow["date"].ToString());
                        }
                    }
                    ddlDate.DataSource = arrList;
                    if (loadornot == "")
                    {
                        ddlDate.SelectedValue = arrList[0];
                        selectedDate = arrList[0];
                    }
                    else
                    {
                        ddlDate.SelectedValue = selectedDate;
                    }
                    ddlDate.DataBind();

                    DropDownList ddlDoctor = (DropDownList)e.Row.FindControl("ddlDoctor");
                    DataSet dsDoctor = new AppointmentDAO().getAvlDoctors(selectedDate);
                    ddlDoctor.DataSource = dsDoctor;
                    ddlDoctor.DataTextField = "name";
                    ddlDoctor.DataValueField = "name";
                    if (loadornot == "" || loadornot == "Date Changed")
                    {
                        ddlDoctor.SelectedValue = dsDoctor.Tables[0].Rows[0]["name"].ToString();
                        selectedDoctor = dsDoctor.Tables[0].Rows[0]["name"].ToString();
                    }
                    else
                    {
                        ddlDoctor.SelectedValue = selectedDoctor;
                    }
                    ddlDoctor.DataBind();

                    DropDownList ddlTime = (DropDownList)e.Row.FindControl("ddlTime");
                    DataSet dsTime = new AppointmentDAO().getAppointmentTimes(selectedDate, selectedDoctor);
                    ddlTime.DataSource = dsTime;
                    ddlTime.DataTextField = "time";
                    ddlTime.DataValueField = "time";
                    ddlTime.DataBind();
                }
            }
        }

        //dropdownlists ddlDoctor, ddlDate events inside gridview gvAppointments
        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvRow = gvAppointments.Rows[gvAppointments.EditIndex];
            selectedDate = ((DropDownList)gvRow.FindControl("ddlDate")).SelectedValue;
            loadornot = "Date Changed";
            lblValidate = false;
            if (ddlDate1.Visible)
            {
                getAppointmentsbyDate();
            }
            else if (ddlDoctor1.Visible)
            {
                getAppointmentsbyDoctor();
            }
            else if (ddlPatient1.Visible)
            {
                getAppointments();
            }
        }

        protected void ddlDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvRow = gvAppointments.Rows[gvAppointments.EditIndex];
            selectedDate = ((DropDownList)gvRow.FindControl("ddlDate")).SelectedValue;
            selectedDoctor = ((DropDownList)gvRow.FindControl("ddlDoctor")).SelectedValue;
            loadornot = "Doctor Changed";
            lblValidate = false;
            if (ddlDate1.Visible)
            {
                getAppointmentsbyDate();
            }
            else if (ddlDoctor1.Visible)
            {
                getAppointmentsbyDoctor();
            }
            else if (ddlPatient1.Visible)
            {
                getAppointments();
            }
        }
    }
}