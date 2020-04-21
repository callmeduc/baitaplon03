using BTL_QLBGX.All_class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_QLBGX.form
{
    public partial class InsertProduct : System.Web.UI.Page
    {
        cls_connect conn = new cls_connect();
        SqlCommand sqlcm;
        protected void Page_Load(object sender, EventArgs e)
        {
            DrYear.Text = DateTime.Now.Year.ToString();
            DrMonth.Text = DateTime.Now.Month.ToString();
            DrDate.Text = DateTime.Now.Day.ToString();
        }

        protected void insertProduct_Click(object sender, EventArgs e)
        {
            try
            {
                conn.open_DB();
                string query_insert = "INSERT INTO [dbo].[producer] ([name],[createdAt]) " +
                    "VALUES('" + txt_Product.Text + "','" + DrMonth.Text + "/" + DrDate.Text + "/" + DrYear.Text + "'); ";
                sqlcm = new SqlCommand(query_insert, conn.con);
                sqlcm.ExecuteNonQuery();
                Response.Redirect("../form/Settings.aspx");
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
    }
}