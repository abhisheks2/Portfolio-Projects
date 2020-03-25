using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace DCMSDataAccessLayer
{
    public class InventoryDAO
    {
        Connect c = new Connect();
        public InventoryDAO()
        {
            c.sqlConn = new SqlConnection(c.connString);
            c.sqlConn.Open();
        }

        public DataSet getMedicine()
        {
            string query = "select * from Inventory";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public SqlDataReader getMedicineNames()
        {
            string query = "select Name from Inventory";
            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.DR = c.sqlComm.ExecuteReader();
            return c.DR;
        }

        public DataSet getMedicineInfo(string name)
        {
            string query = "select * from Inventory where Name ='" + name + "'";

            c.sqlComm = new SqlCommand(query, c.sqlConn);
            c.sqlAdap = new SqlDataAdapter(c.sqlComm);

            c.dataSet = new DataSet();
            c.sqlAdap.Fill(c.dataSet);
            c.sqlConn.Close();
            return c.dataSet;
        }

        public bool update(InventoryDTO m)
        {
            string query = "update Inventory set Quantity=" + m.Quantity + ", Price=" + m.Price + ", Supplier='" + m.Supplier + "' where Name='" + m.Name + "'";
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

        public bool add(InventoryDTO m)
        {
            try
            {
                string query = "insert into Inventory (Name, Quantity, Price, Supplier) values ('" + m.Name + "'," + m.Quantity + "," + m.Price + ",'" + m.Supplier + "')";
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
    }
}