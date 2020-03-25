using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace DCMSDataAccessLayer
{
    public class UsersDAO
    {
        Connect c = new Connect();

        public UsersDAO()
        {
            c.sqlConn = new SqlConnection(c.connString);
            c.sqlConn.Open();
        }

        public bool verifyAdmin(string user)
        {
            string query = "select role from Users where username='" + user + "'";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();

            if (c.dataSet.Tables[0].Rows[0]["role"].ToString() == "admin") return true;
            else return false;
        }

        public bool verifyUser(string user, string pass)
        {
            string query = "select * from Users where username='" + user + "' and pass='" + pass + "'";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            //string s = dataSet.Tables[0].Rows[0][0].ToString();
            //string q = dataSet.Tables[0].Rows[0][1].ToString();
            //if (s.Equals(user) && q.Equals(pass)) return true;
            if (c.dataSet.Tables[0].Rows.Count > 0) return true;
            else return false;
        }

        public bool changePass(string user, string pass, string newpass)
        {
            if (this.verifyUser(user, pass))
            {
                c.sqlConn.Open();
                string query = "update Users set pass='" + newpass + "' where username='" + user + "'";

                c.sqlComm = new SqlCommand(query, c.sqlConn);
                c.sqlAdap = new SqlDataAdapter(c.sqlComm);

                c.dataSet = new DataSet();
                c.sqlAdap.Fill(c.dataSet);
                c.sqlConn.Close();
                return true;
            }
            else return false;
        }

        public bool addUser(UsersDTO a)
        {
            try
            {
                string query;
                if (a.DoctorID == 0)
                {
                    query = "insert into Users (username, pass, role, doctorID) values ('" + a.USER + "','" + a.PASS + "','" + a.Role + "',null)";
                }
                else
                {
                    query = "insert into Users (username, pass, role, doctorID) values ('" + a.USER + "','" + a.PASS + "','" + a.Role + "'," + a.DoctorID + ")";
                }
                c.sqlComm = new SqlCommand(query, c.sqlConn);
                c.sqlComm.ExecuteNonQuery();
                c.sqlConn.Close();
                return true;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                return false;
            }
        }

    }
}