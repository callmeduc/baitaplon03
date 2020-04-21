using BTL_QLBGX.All_class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_QLBGX.form
{
    public partial class Home : System.Web.UI.Page
    {
        All_query qr = new All_query();
        protected void Page_Load(object sender, EventArgs e)
        {
            try 
            {
                var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
                sumUser.Text = qr.getCount(sql_query.SELECT_COUNT_USERS).ToString();
                sumAccessCard.Text = qr.getCount(sql_query.SELECT_COUNT_ACCESSCARD()).ToString();
                sumParking.Text = qr.getCount(sql_query.SELECT_COUNT_PARKING).ToString();
                sumAmountParking.Text = String.Format(info, "{0:c}", qr.getCountDouble(sql_query.SELECT_SUM_AMOUNT_PARKING));
                findParse fp = new findParse();
                SqlDataReader re = qr.getData(sql_query.SELECT_INFO_USER_PARKING(0,20,""));
                string st_kq = "";
                int dem = 0;
                while (re.Read())
                {
                    dem += 1;
                    st_kq += "<tr><td>" + dem + "</td><td>" + re.GetValue(0).ToString() + "</td><td>" + re.GetValue(1).ToString() + "</td><td>" + re.GetValue(2).ToString() + "</td><td>" + re.GetValue(3).ToString() + "</td><td>" + re.GetValue(4).ToString() + "</td><td>" + re.GetValue(5).ToString() + "</td><td>" + re.GetValue(6).ToString() + "</td></tr>";
                }
                Ltr_qlrv.Text = st_kq;
            }
            catch (SqlException ex)
            {
                Response.Write("Lỗi:" + ex);
            }

        }
    }
}