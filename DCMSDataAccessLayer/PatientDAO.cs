using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace DCMSDataAccessLayer
{
    public class PatientDAO
    {
        Connect c = new Connect();
        public PatientDAO()
        {
            c.sqlConn = new SqlConnection(c.connString);
            c.sqlConn.Open();
        }

        public bool createPatient(PatientDTO p)
        {
            try
            {
                string query = "insert into patient (Name, Address, ContactNo, Age, Sex, MaritalStatus, Occupation, MedInfo, Email, DOB) values ('" + p.Name + "','" + p.Address + "','" + p.ContactNo + "'," + p.Age + ",'" + p.Sex + "','" + p.MaritalStatus + "','" + p.Occupation + "','" + p.MedInfo + "','" + p.Email + "','" + p.DOB +"')";

                c.sqlComm = new SqlCommand(query, c.sqlConn);
                c.sqlComm.ExecuteNonQuery();
                c.sqlConn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataSet getPatient(string email)
        {
            string query = "select * from patient where email ='" + email + "'";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public string getName(int id)
        {
            string query = "select Name from patient where id =" + id;

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet.Tables[0].Rows[0][0].ToString();
        }

        public bool updatePatient(int id, PatientDTO p)
        {
            try
            {
                string query = "UPDATE patient SET Name='" + p.Name + "', email='" + p.Email +"' dob='" + p.DOB + "' Address='" + p.Address + "', Contact='" + p.ContactNo + "', Age=" + p.Age + ", Sex='" + p.Sex + "', MaritalStatus='" + p.MaritalStatus + "', Occupation='" + p.Occupation + "', MedicalInfo='" + p.MedInfo + "' WHERE ID=" + id;
                c.sqlComm = new SqlCommand(query, c.sqlConn);
                c.sqlComm.ExecuteNonQuery();
                c.sqlConn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool verifyPatient(string email, int id)
        {
            string query = "select * from patient where email='" + email + "' and ID=" + id;

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            if (c.dataSet.Tables[0].Rows.Count > 0) return true;
            else return false;
        }

        public bool verifyPatientEmail(string email)
        {
            string query = "select * from patient where email='" + email + "'";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            if (c.dataSet.Tables[0].Rows.Count > 0) return true;
            else return false;
        }

        public DataSet getPatients()
        {
            string query = "select ID, Name, Address, ContactNo, Email, DOB from patient";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public string getMedInfo(int id)
        {
            string query = "select medInfo from patient where id=" + id;

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet.Tables[0].Rows[0]["medInfo"].ToString();
        }
        public int getID(string email)
        {
            string query = "select ID from patient where email = '" + email + "'";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return Convert.ToInt32(c.dataSet.Tables[0].Rows[0]["ID"]);
        }
    }
}