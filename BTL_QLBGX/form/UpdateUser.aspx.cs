using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BTL_QLBGX.All_class;

namespace BTL_QLBGX.form
{
    public partial class UpdateUser : System.Web.UI.Page
    {
        cls_connect cls_con = new cls_connect();
        getMD5 hash = new getMD5();
        SqlCommand sqlcmt;
        SqlDataAdapter ap;
        SqlDataReader re;

        protected void LoadPermission()
        {
            cls_con.open_DB();

            string sql = "select permissionId, name from permission";
            sqlcmt = new SqlCommand(sql, cls_con.con);
            re = sqlcmt.ExecuteReader();
            while (re.Read())
            {
                DropListPermission.Items.Add(new ListItem(re.GetValue(1).ToString(), re.GetValue(0).ToString()));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            cls_con.open_DB();
            LoadPermission();
            if (!IsPostBack)
            {
                try
                {
                    string id = Request.QueryString.Get("userId").ToString();
                    string sql = "select * from users where userId = @id";

                    sqlcmt = new SqlCommand(sql, cls_con.con);
                    SqlParameter sqlpa = new SqlParameter();
                    sqlpa.ParameterName = "@id";
                    sqlpa.Value = id;

                    sqlcmt.Parameters.Add(sqlpa);
                    re = sqlcmt.ExecuteReader();
                    re.Read();

                    txtUserNumber.Text = re.GetValue(0).ToString();
                    txtFullname.Text = re.GetValue(1).ToString();
                    txtPhone.Text = re.GetValue(2).ToString();
                    txtEmail.Text = re.GetValue(3).ToString();
                    DropListPermission.SelectedValue = re.GetValue(5).ToString();
                    ddlStatus.Items.Add(new ListItem("Khóa", "0"));
                    ddlStatus.Items.Add(new ListItem("Hoạt động", "1"));
                    ddlStatus.SelectedValue = re.GetValue(6).ToString().Equals("False") ? "1" : "0";
                    txtCreateAt.Text = re.GetValue(7).ToString();
                }
                catch (SqlException ex)
                {
                    Response.Write("Error: " + ex);
                }
                finally
                {
                    cls_con.close_DB();
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cls_con.open_DB();
                string id = Request.QueryString.Get("userId").ToString();

                string fullname = txtFullname.Text;
                string phone = txtPhone.Text;
                string email = txtEmail.Text;
                string permission = DropListPermission.SelectedValue.ToString();
                string status = ddlStatus.SelectedValue;

                string sql = "update users set fullname = N'" + fullname + "', phone = '" + phone + "', email = '" + email + "', permissionId = '" + permission + "', isBlock = '" + status + "' where userId = '" + id + "'";

                lblNotify.Text = sql.ToString();

                sqlcmt = new SqlCommand(sql, cls_con.con);
                int check = sqlcmt.ExecuteNonQuery();
                if (check != 0)
                {
                    Response.Redirect("/form/Users.aspx");
                    //lblNotify.Text = "Update Successfully";
                }
                else
                {
                    lblNotify.Text = "Update False";
                }
            }
            catch (SqlException ex)
            {
                lblNotify.Text = "Email đã tồn tại";
            }
            finally
            {
                cls_con.close_DB();
            }

        }
    }
}