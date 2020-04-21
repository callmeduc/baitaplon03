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
    public partial class InsertPermisson : System.Web.UI.Page
    {
        cls_connect conn = new cls_connect();
        SqlCommand sqlcm;

        public string DrYear;
        public string DrDate;
        public string DrMonth;
        protected void Page_Load(object sender, EventArgs e)
        {
            DrYear = DateTime.Now.Year.ToString();
            DrMonth = DateTime.Now.Month.ToString();
            DrDate = DateTime.Now.Day.ToString();
        }

        protected void insertPermisson_Click(object sender, EventArgs e)
        {
            try
            {
                conn.open_DB();
                string ma = Request.QueryString.Get("id");
                string query_insert = "INSERT INTO [dbo].[permission] ([name],[status],[createdAt]) " +
                    "VALUES('" + txt_Permisson.Text + "','" + status.Text + "','" + DrMonth + "/" + DrDate + "/" + DrYear + "'); ";
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