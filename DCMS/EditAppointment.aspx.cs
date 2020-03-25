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
    public partial class EditAppointment : System.Web.UI.Page
    {
        string[] times = new string[] { "9:00am", "10:00am", "11:00am", "12:00pm", "1:00pm", "2:00pm", "3:00pm", "4:00pm", "5:00pm" };
        int id;
        string loadornot = "";
        string selectedDate = "";
        string selectedDoctor = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getAppointments(); //get and bind appointments to gridview
            }
        }

        //get and bind appointments to gridview
        private void getAppointments()
        {
            id = Convert.ToInt32(Session["PatientID"]);
            DataSet ds = new AppointmentDAO().appointmentsByPatientID(id);
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
                gvAppointments.DataSource = ds;
                gvAppointments.DataBind();
            }
        }

        protected void gvAppointments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            if (e.CommandName == "EditRow")
            {
                gvAppointments.EditIndex = rowIndex;
                getAppointments();
            }
            else if (e.CommandName == "CancelUpdate")
            {
                gvAppointments.EditIndex = -1;
                getAppointments();
            }
            else if (e.CommandName == "DeleteRow")
            {
                int appointmentID = Convert.ToInt32(e.CommandArgument);
                if (new AppointmentDAO().deleteAppointment(appointmentID))
                {
                    lblMessage.Text = "Appointment: " + appointmentID +  " deleted";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    getAppointments();
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
                    getAppointments();
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
                            arrList.Add(Convert.ToDateTime(dRow["date"]).ToString("dd-MM-yyyy"));
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

        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvRow = gvAppointments.Rows[gvAppointments.EditIndex];
            selectedDate = ((DropDownList)gvRow.FindControl("ddlDate")).SelectedValue;
            loadornot = "Date Changed";
            getAppointments();
        }

        protected void ddlDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvRow = gvAppointments.Rows[gvAppointments.EditIndex];
            selectedDate = ((DropDownList)gvRow.FindControl("ddlDate")).SelectedValue;
            selectedDoctor = ((DropDownList)gvRow.FindControl("ddlDoctor")).SelectedValue;
            loadornot = "Doctor Changed";
            getAppointments();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientHome.aspx");
        }
    }
}