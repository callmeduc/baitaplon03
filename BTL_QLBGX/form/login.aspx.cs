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
    public partial class login : System.Web.UI.Page
    {
        cls_connect cls_con = new cls_connect();
        getMD5 hash = new getMD5();
        All_query qr = new All_query();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtLogin_Click(object sender, EventArgs e)
        {
            cls_con.open_DB();

            string email = txtEmail.Text.Trim().ToLower();
            string password = hash.HashPass(txtPassword.Text.Trim().ToLower());

            try
            {
                string sql = "select u.*, p.* from users u inner join permission p on p.permissionId=u.permissionId where u.email='" + email + "' and u.password='" + password + "'";
                SqlCommand sqlcmt = new SqlCommand(sql, cls_con.con);
                SqlDataReader re = sqlcmt.ExecuteReader();


                if (re.Read())
                {
                    // set value session
                    int check = Convert.ToInt32(re.GetValue(6));

                    lblBotify.Text = check.ToString();

                    //var profile = new UserProfileSessionData
                    //{
                    //    userID = int.Parse(re.GetValue(0).ToString()),
                    //    fullname = re.GetValue(1).ToString(),
                    //    phone = re.GetValue(2).ToString(),
                    //    email = re.GetValue(3).ToString(),
                    //    password = re.GetValue(4).ToString(),
                    //    permissionID = int.Parse(re.GetValue(5).ToString()),
                    //    isBlock = Convert.ToInt32(re.GetValue(6)),
                    //    createAt = re.GetValue(7).ToString()
                    //}.ToString();
                    Session["user"] = new UserProfileSessionData
                    {
                        userID = int.Parse(re.GetValue(0).ToString()),
                        fullname = re.GetValue(1).ToString(),
                        phone = re.GetValue(2).ToString(),
                        email = re.GetValue(3).ToString(),
                        password = re.GetValue(4).ToString(),
                        permissionID = int.Parse(re.GetValue(5).ToString()),
                        isBlock = Convert.ToInt32(re.GetValue(6)),
                        createAt = re.GetValue(7).ToString()
                    };
                    Response.Redirect("/form/Home.aspx");
                }
                else
                {
                    lblBotify.Text = "Email hoặc mật khẩu không đúng.";
                }
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
}