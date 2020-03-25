using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace DCMSDataAccessLayer
{
    public class DoctorDAO
    {
        Connect c = new Connect();
        public DoctorDAO()
        {
            c.sqlConn = new SqlConnection(c.connString);
        }

        public DataSet getDoctors()
        {
            string query = "select Name from doctor where Available=1";
            c.sqlConn.Open();
            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);
            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
            
        }

        public DataSet getDoctors2()
        {
            string query = "select Name from doctor";
            c.sqlConn.Open();
            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);
            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public DataSet getDocIDs()
        {
            string query = "select DocID from doctor";
            c.sqlConn.Open();
            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);
            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public int getID(string name)
        {
            string query = "select DocId from doctor where Name='" + name + "'";
            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return Convert.ToInt32(c.dataSet.Tables[0].Rows[0][0]);
        }

        public DataSet getDocs()
        {
            string query = "select * from doctor";
            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public DataSet getInfo(string name)
        {
            string query = "select * from doctor where name='" + name + "'";
            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }
        public DataSet getInfoID(int id)
        {
            string query = "select * from doctor where DocId=" + id;
            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }
        public DataSet getInfoNameID(int id, string name)
        {
            string query = "select * from doctor where DocId=" + id + " and name='" + name + "'";
            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public bool update(DoctorDTO d)
        {
            int s = 0;
            if (d.Available == true) s = 1;
            string query = "update doctor set Name='" + d.Name + "', Salary=" + d.Salary + ", Available =" + s + " where DocId=" + d.DocID;
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

        public bool add(DoctorDTO d)
        {
            int s = 0;
            if (d.Available == true) s = 1;
            try
            {
                string query = "insert into doctor (Name, Salary, Available) values ('" + d.Name + "'," + d.Salary + "," + s + ")";
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