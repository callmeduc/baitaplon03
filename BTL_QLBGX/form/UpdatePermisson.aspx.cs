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
    public partial class InfoUser : System.Web.UI.Page
    {
        cls_connect conn = new cls_connect();
        SqlCommand sqlcm;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                try
                {
                    conn.open_DB();
                    string ma = Request.QueryString.Get("id");
                    string str = $"SELECT * FROM [dbo].[permission] WHERE [permissionId] ={ma}";
                    sqlcm = new SqlCommand(str, conn.con);

                    SqlDataReader re = sqlcm.ExecuteReader();
                    re.Read();
                    txt_idUser.Text = re.GetValue(0).ToString();
                    txt_User.Text = re.GetValue(1).ToString();
                    phone.Text = re.GetValue(2).ToString();
                    re.Close();
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

        protected void Update_Click(object sender, EventArgs e)
        {
            int id;
            if (phone.Text == "True") id = 1;
            else id = 0;
            try
            {
                try
                {
                    conn.open_DB();
                    string ma = Request.QueryString.Get("id");
                    string query_delete = "UPDATE [dbo].[permission] SET [name] ='" + txt_User.Text + "', [status] = '" + id + "' Where [permissionId] =" + ma;
                    sqlcm = new SqlCommand(query_delete, conn.con);
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
            try
            {
                conn.open_DB();
                string ma = Request.QueryString.Get("id");
                string query_delete = $"DELETE FROM [dbo].[permission] WHERE [permissionId] = {ma} ";
                sqlcm = new SqlCommand(query_delete, conn.con);
                sqlcm.ExecuteNonQuery();
                Response.Redirect("../form/Settings.aspx");
            }
            catch (SqlException ex)
            {
                int repost = 1;
                Response.Redirect("../form/Repost.aspx?repost=" + repost);
            }
            finally
            {
                conn.close_DB();
            }
        }
    }
}