﻿using BTL_QLBGX.All_class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_QLBGX.form
{
    public partial class UpadteTypeCard : System.Web.UI.Page
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
                    string str = $"SELECT * FROM [dbo].[typeCard] WHERE [typeCardId] ={ma}";
                    sqlcm = new SqlCommand(str, conn.con);

                    SqlDataReader re = sqlcm.ExecuteReader();
                    re.Read();
                    txt_mathe.Text = re.GetValue(0).ToString();
                    txt_loaithe.Text = re.GetValue(1).ToString();
                    txt_sale.Text = re.GetValue(2).ToString();
                    txt_creadat.Text = re.GetValue(3).ToString();
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

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                conn.open_DB();
                string ma = Request.QueryString.Get("id");
                string query_delete = "UPDATE [dbo].[typeCard] SET [name] = N'" + txt_loaithe.Text + "',[sale] =" + txt_sale.Text + " Where [typeCardId] =" + txt_mathe.Text;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.open_DB();
                string ma = Request.QueryString.Get("id");
                string query_delete = $"DELETE FROM typeCard WHERE typeCardId = {ma} ";
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
    }
}