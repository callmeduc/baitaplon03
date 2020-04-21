using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BTL_QLBGX.All_class
{
    public class cls_connect
    {
        public string s_con = WebConfigurationManager.ConnectionStrings["connect_QLBGX"].ToString();
        public SqlConnection con;
        public void open_DB()
        {
            if (con == null) con = new SqlConnection(s_con);
            if (con.State == ConnectionState.Closed) con.Open();
        }
        public void close_DB()
        {
            //if (con != null) 
            //{
            //    con.Dispose();
            //}
            con.Close();
        }
    }
}