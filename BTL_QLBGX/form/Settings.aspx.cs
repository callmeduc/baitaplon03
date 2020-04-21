using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTL_QLBGX.All_class;

namespace BTL_QLBGX.form
{
    public partial class Settings : System.Web.UI.Page
    {
        cls_connect conn = new cls_connect();
        SqlCommand sqlcm;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                conn.open_DB();
                string str_query1 = "SELECT * FROM producer";
                string str_query = "SELECT * FROM typeCard";
                sqlcm = new SqlCommand(str_query, conn.con);
                SqlDataReader re = sqlcm.ExecuteReader();
                string str_kq = "";
                int dem = 0;
                while (re.Read())
                {
                    dem += 1;
                    str_kq = str_kq + "<tr><td>" + dem + "</td><td>" + re.GetValue(1).ToString() + "</td><td>" + re.GetValue(2).ToString() + "</td><td>" + re.GetValue(3).ToString() + "</td><td><a href=" + "../form/UpadteTypeCard.aspx?id=" + re.GetValue(0).ToString() + ">Chi tiết</td></tr>";
                }
                re.Close();
                Literal1.Text = str_kq;

                sqlcm = new SqlCommand(str_query1, conn.con);
                SqlDataReader re1 = sqlcm.ExecuteReader();
                string str_kq1 = "";
                dem = 0;
                while (re1.Read())
                {
                    dem += 1;
                    str_kq1 = str_kq1 + "<tr><td>" + dem + "</td><td>" + re1.GetValue(1).ToString() + "</td><td>" + re1.GetValue(2).ToString() + "</td><td><a href=" + "../form/UpdateProducer.aspx?id=" + re1.GetValue(0).ToString() + ">Chi tiết</a></td></tr>";
                }
                re1.Close();
                LitSinhVien.Text = str_kq1;

                string sql_User = "SELECT * FROM [dbo].[permission]";
                sqlcm = new SqlCommand(sql_User, conn.con);
                SqlDataReader re2 = sqlcm.ExecuteReader();
                string str_user = "";
                dem = 0;
                while (re2.Read())
                {
                    dem += 1;
                    str_user = str_user + "<tr><td>" + dem + "</td><td>" + re2.GetValue(1).ToString() + "</td><td>" + re2.GetValue(2).ToString() + "</td><td><a href=" + "../form/UpdatePermisson.aspx?id=" + re2.GetValue(0).ToString() + ">Chỉnh sửa quyền</td></tr>";
                }
                re2.Close();
                Literal2.Text = str_user;
            }
            catch (SqlException ex)
            {
                Response.Write("Error ! " + ex);
            }
            finally
            {
                conn.close_DB();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../form/InsertTypeCard.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../form/InsertProduct.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("../form/InsertPermisson.aspx");
        }
    }
}