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
    public partial class ChangePassword : System.Web.UI.Page
    { 
        cls_connect cls_con = new cls_connect();
        getMD5 hash = new getMD5();
        SqlCommand sqlcmt;
        SqlDataAdapter ap;
        SqlDataReader re;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString.Get("userId").ToString();
            Response.Redirect("/form/abc.aspx?userId=" + id);
        }

        protected void btnSaveChangePass_Click(object sender, EventArgs e)
        {
            cls_con.open_DB();

            string id = Request.QueryString.Get("userId").ToString();
            string passwordCu = "";
            if (txtPasswordCu.Text != "")
            {
                passwordCu = hash.HashPass(txtPasswordCu.Text);
            }

            string sql = "select password from users where userId = @id";
            sqlcmt = new SqlCommand(sql, cls_con.con);
            SqlParameter sqlpa = new SqlParameter();
            sqlpa.ParameterName = "@id";
            sqlpa.Value = id;
            sqlcmt.Parameters.Add(sqlpa);
            re = sqlcmt.ExecuteReader();
            re.Read();
            string getPass = re.GetValue(0).ToString();

            if (getPass != passwordCu)
            {
                lblNotify.Text = "Mật khẩu cũ không đúng. Đổi mật khẩu không thánh công.";
            }
            else
            {
                string passwordNew = hash.HashPass(txtPassNew2.Text);
                string updatePassword = "update users set password = '" + passwordNew + "' where userId = '" + id + "'";
                sqlcmt = new SqlCommand(updatePassword, cls_con.con);
                int check = sqlcmt.ExecuteNonQuery();
                if (check != 0)
                {
                    Response.Redirect("/form/UserDetail.aspx?userId=" + id + "&type=view&status=success");
                }
                else
                {
                    lblNotify.Text = "Đổi mật khẩu không thành công.";
                }
            }
        }
    }
}