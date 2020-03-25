using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace DCMSDataAccessLayer
{
    public class TreatmentDAO
    {
        Connect c = new Connect();
        public TreatmentDAO()
        {
            c.sqlConn = new SqlConnection(c.connString);
        }

        public int getCost(string treatment)
        {
            int cost;
            string query = "select * from Treatment where Name ='" + treatment + "'";

            c.sqlConn.Open();
            c.sqlComm = new SqlCommand(query, c.sqlConn);
            
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            cost = Convert.ToInt32(c.dataSet.Tables[0].Rows[0][1]);
            return cost;
        }

        public DataSet getTreatments()
        {
            string query = "select Name from Treatment";
            c.sqlConn.Open();
            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);
            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public DataSet getAllTreatments()
        {
            string query = "select * from Treatment";
            c.sqlConn.Open();
            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);
            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public bool verifyTreatment(string name)
        {
            string query = "select name from Treatment  where name='" + name + "'";
            c.sqlConn.Open();
            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            if (c.dataSet.Tables[0].Rows.Count > 0) return true;
            else return false;
        }

        public bool updateTreatment(TreatmentDTO t)
        {
            try
            {
                string query = "update Treatment set cost=" + t.Cost + " where name='" + t.Name + "'";
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

        public bool addTreatment(TreatmentDTO t)
        {
            try
            {
                string query = "insert into Treatment (Name, Cost) values ('" + t.Name + "'," + t.Cost + ")";

                c.sqlComm = new SqlCommand(query, c.sqlConn);
                c.sqlConn.Open();
                c.sqlComm.ExecuteNonQuery();
                c.sqlConn.Close();

                query = "CREATE TABLE " + t.Name + " (tID int primary key identity, pID int, dID int, tooth varchar(50), quantity int, cost int, paid int, date varchar(50));";
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