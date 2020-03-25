using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DCMSDataAccessLayer
{
    public class Connect
    {
        public string connString = ConfigurationManager.ConnectionStrings["dbDCMS"].ConnectionString;
        public SqlConnection sqlConn;
        public SqlCommand sqlComm;
        public SqlDataAdapter sqlAdap;
        public DataSet dataSet;
        public SqlDataReader DR;
    }
}