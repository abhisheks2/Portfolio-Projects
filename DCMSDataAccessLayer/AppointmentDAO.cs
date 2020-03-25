using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace DCMSDataAccessLayer
{
    public class AppointmentDAO
    {
        Connect c = new Connect();
        string[] times = new string[] { "9:00am", "10:00am", "11:00am", "12:00pm", "1:00pm", "2:00pm", "3:00pm", "4:00pm", "5:00pm" };
        public AppointmentDAO()
        {
            c.sqlConn = new SqlConnection(c.connString);
        }

        public DataSet getDates()
        {
            c.sqlConn.Open();
            string query = "select distinct date from Appointment order by date";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }
        public DataSet appointmentsExist()
        {
            c.sqlConn.Open();
            string query = "select distinct date from Appointment where id is null order by date";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public DataSet appointmentsByPatientID(int id)
        {
            c.sqlConn.Open();
            string query = "select * from Appointment where id=" + id;

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public DataSet appointmentsByDate(string date)
        {
            c.sqlConn.Open();
            string query = "select * from Appointment where id is not null and date='" + date + "'";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public DataSet appointmentsByDoctor(string name)
        {
            c.sqlConn.Open();
            string query = "select * from Appointment where id is not null and name='" + name + "'";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public DataSet getAvlDoctors(string date)
        {
            c.sqlConn.Open();
            string query = "select distinct name from Appointment where id is null and date='" + date + "'";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public DataSet getAppointmentTimes(string date, string name)
        {
            c.sqlConn.Open();
            string query = "select time from Appointment where id is null and date='" + date + "' and name='" + name + "'";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        private DataSet lastAppointmentDate()
        {
            c.sqlConn.Open();
            string query = "select distinct top 1 date from Appointment order by date desc";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public void addRows()
        {
            c.sqlConn.Open();
            string query = "", date = "", name = "";
            DataSet ds = new DoctorDAO().getDoctors();
            foreach (DataRow dRow in ds.Tables[0].Rows)
            {
                name = dRow["name"].ToString();
                for (int i = 0; i < 7; i++)
                {
                    date = System.DateTime.Today.AddDays(i).ToString("yyyy-MM-dd");
                    for (int j=0; j < 9; j++)
                    {
                        query = "INSERT INTO Appointment (Name, Date, Time) values ('" + name + "','" + date + "','" + times[j] + "')";
                        c.sqlComm = new SqlCommand(query, c.sqlConn);
                        c.sqlComm.ExecuteNonQuery();
                    }
                }
            }
            c.sqlConn.Close();
        }

        public void appendRows()
        {
            string query = "", date = "", name = "";
            DataSet dsDate = lastAppointmentDate();
            DateTime lastDate = Convert.ToDateTime(dsDate.Tables[0].Rows[0][0]);
            DataSet ds = new DoctorDAO().getDoctors();
            c.sqlConn.Open();
            foreach (DataRow dRow in ds.Tables[0].Rows)
            {
                name = dRow["name"].ToString();
                for (int i = 1; i < 8; i++)
                {
                    date = lastDate.AddDays(i).ToString("yyyy-MM-dd");
                    for (int j = 0; j < 9; j++)
                    {
                        query = "INSERT INTO Appointment (Name, Date, Time) values ('" + name + "','" + date + "','" + times[j] + "')";
                        c.sqlComm = new SqlCommand(query, c.sqlConn);
                        c.sqlComm.ExecuteNonQuery();
                    }
                }
            }
            c.sqlConn.Close();
        }


        public DataSet getRows(AppointmentDTO a)
        {
            c.sqlConn.Open();
            string query = "select * from Appointment where Name='" + a.Name + "' and Date='" + a.Date + "'";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public bool getApp(AppointmentDTO a)
        {
            c.sqlConn.Open();
            string query = "update Appointment set id=" + a.Id + " where Name='" + a.Name + "' and Date='" + a.Date + "' and time='" + a.Time + "'";
            try
            {
                c.sqlComm = new SqlCommand(query, c.sqlConn);
                c.sqlComm.ExecuteNonQuery();
                c.sqlConn.Close();
                return true;
            }
            catch (Exception e)
            {
                c.sqlConn.Close();
                return false;
            }
        }

        public bool prevDay(int i)
        {
            string date = DateTime.Today.AddDays(-i).ToString("yyyy-MM-DD");
            string query = "select * from Appointment where Date='" + date + "'";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            if (c.dataSet.Tables[0].Rows.Count == 0) return false;
            else return true;
        }


        public string[] find(int id)
        {
            c.sqlConn.Open();
            string query = "";
            int i;
            string[] d = new string[] { "", "", "" };
            string[] times = new string[] { "9:00am", "9:30am", "10:00am", "10:30am", "5:00pm", "5:30pm", "6:00pm", "6:30pm", "7:00pm", "7:30pm", "8:00pm", "8:30pm" };
            for (i = 0; i < 12; i++)
            {
                query = "select * from Appointment where [" + times[i] + "]=" + id + "";
                c.sqlComm = new SqlCommand(query, c.sqlConn);
                c.sqlAdap = new SqlDataAdapter(c.sqlComm);

                c.dataSet = new DataSet();
                c.sqlAdap.Fill(c.dataSet);
                if (c.dataSet.Tables[0].Rows.Count > 0) break;
            }
            if (c.dataSet.Tables[0].Rows.Count > 0)
            {
                d[0] = c.dataSet.Tables[0].Rows[0]["Name"].ToString();
                d[1] = c.dataSet.Tables[0].Rows[0]["Date"].ToString();
                d[2] = times[i];
            }
            return d;
        }

        public bool deleteAppointment(int appointmentID)
        {
            c.sqlConn.Open();
            string query = "update Appointment set id = null where appointmentID=" + appointmentID;
            try
            {
                c.sqlComm = new SqlCommand(query, c.sqlConn);
                c.sqlComm.ExecuteNonQuery();
                c.sqlConn.Close();
                return true;
            }
            catch (Exception e)
            {
                c.sqlConn.Close();
                return false;
            }
        }

        public bool updateAppointment(AppointmentDTO a)
        {
            c.sqlConn.Open();
            string query = "update Appointment set date='" + a.Date + "', time='" + a.Time + "', name='" + a.Name + "' where appointmentID=" + a.AppointmentId;
            try
            {
                c.sqlComm = new SqlCommand(query, c.sqlConn);
                c.sqlComm.ExecuteNonQuery();
                c.sqlConn.Close();
                return true;
            }
            catch (Exception e)
            {
                c.sqlConn.Close();
                return false;
            }
        }

        public DataSet appList()
        {
            c.sqlConn.Open();
            string query = "select * from Appointment";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public void addNew(string name, string date)
        {
            c.sqlConn.Open();
            string query = "INSERT INTO Appointment (Name, Date) values ('" + name + "','" + date + "')";
            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlComm.ExecuteNonQuery();
            c.sqlConn.Close();
        }
    }
}