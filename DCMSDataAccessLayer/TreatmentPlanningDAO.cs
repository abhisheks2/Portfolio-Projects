    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace DCMSDataAccessLayer
{
    public class TreatmentPlanningDAO
    {
        Connect c = new Connect();
        public TreatmentPlanningDAO()
        {
            c.sqlConn = new SqlConnection(c.connString);
        }

        public bool createTreatmentPlan(TreatmentPlanningDTO p)
        {
            try
            {
                string query = "INSERT INTO " + p.Treatment + " (pID, dID, tooth, quantity, cost, paid, date) values (" + p.PID + "," + p.DID + ",'" + p.Tooth + "'," + p.Quantity + "," + p.Cost + "," + p.Paid + ",'" + p.Date + "')";
                c.sqlComm = new SqlCommand(query, c.sqlConn);
                c.sqlConn.Open();
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
        public DataTable getTreatmentPlansByPatient(int pID)
        {
            bool addTreatmentNameColumn = true;
            DataTable dt = new DataTable();
            DataSet dsTreatments = new TreatmentDAO().getAllTreatments();
            c.sqlConn.Open();
            foreach (DataRow dRow in dsTreatments.Tables[0].Rows)
            {
                string query = "Select * from " + dRow["name"].ToString() + " where pID=" + pID;
                c.sqlComm = new SqlCommand(query, c.sqlConn);
                c.sqlAdap = new SqlDataAdapter(c.sqlComm);
                c.dataSet = new DataSet();
                c.sqlAdap.Fill(dt);
                if (addTreatmentNameColumn)
                {
                    dt.Columns.Add("treatmentname", typeof(string));
                    addTreatmentNameColumn = false;
                }
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["treatmentname"].ToString() == "")
                    {
                        dr["treatmentname"] = dRow["name"].ToString();
                    }
                    
                }
            }
            c.sqlConn.Close();
            return dt;
        }

        public DataSet getPlanforPayment(string tName, int tID)
        {
            c.sqlConn.Open();
            string query = "Select '" + tName + "' as tName, tID, cost, paid from " + tName + " where tID=" + tID;
            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);
            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public bool updatePlanforPayment(string tName, int tID, int paid)
        {
            string query = "Update " + tName + " set paid=" + paid + " where tID=" + tID;
            try
            {
                c.sqlComm = new SqlCommand(query, c.sqlConn);
                c.sqlConn.Open();
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
    }
}