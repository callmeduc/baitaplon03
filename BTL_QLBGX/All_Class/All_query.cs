using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTL_QLBGX.All_class
{
    public class All_query
    {
        cls_connect clscon = new cls_connect();
        SqlCommand sqlcm;
        public All_query()
        {
            clscon.open_DB();
        }
        public int getCount(string sql)
        {
            int sum = 0;
            sqlcm = new SqlCommand(sql, clscon.con);
            sum = (int)sqlcm.ExecuteScalar();
            return sum;
        }
        public double getCountDouble(string sql)
        {
            double sum = 0;
            sqlcm = new SqlCommand(sql, clscon.con);
            sum = (double)sqlcm.ExecuteScalar();
            return sum;
        }
        public SqlDataReader getData(string sql)
        {
            sqlcm = new SqlCommand(sql, clscon.con);
            SqlDataReader re = sqlcm.ExecuteReader();
            return re;
        }
        public int updateData(string sql)
        {
            sqlcm = new SqlCommand(sql, clscon.con);
            return sqlcm.ExecuteNonQuery();
        }
        public void close_DB()
        {
            clscon.close_DB();
        }
    }
}