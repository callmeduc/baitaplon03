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
    public partial class Users : System.Web.UI.Page
    {
        cls_connect cls_con = new cls_connect();
        getMD5 hash = new getMD5();
        utils util = new utils();
        All_query qr = new All_query();
        SqlCommand sqlcmt;
        SqlDataAdapter ap;
        SqlDataReader re;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                cls_con.open_DB();
                if (!Page.IsPostBack)
                {
                    render_Table();
                    LoadPermission();
                }
                string alert = Request.QueryString.Get("status");
                if (alert == "True")
                {
                    lblAlert.Text = "Insert Data Successfully";
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

        public void render_Table()
        {
            try
            {
                cls_con.open_DB();
                findParse fp = new findParse();
                int page = fp.parseIntParams("page", 1);
                int limit = fp.parseIntParams("limit", 5);
                int total = qr.getCount("select COUNT(*) from users");
                int pages = (int)Math.Ceiling((decimal)total / limit);
                page = page > pages ? pages : page;
                int offset = limit * (page - 1);
                string sql = "SELECT * FROM users ORDER BY userId DESC OFFSET " + offset + " rows FETCH NEXT " + limit + " ROWS ONLY";
                SqlDataReader re = qr.getData(sql);
                string result = "";
                string status = "";
                string permission = "";
                int dem = 0;
                while (re.Read())
                {
                    dem++;
                    status = re.GetValue(6).ToString();
                    permission = re.GetValue(5).ToString();
                    if (status == "False")
                    {
                        status = "Active";
                    }
                    else
                    {
                        status = "Unactive";
                    }
                    if (permission == "1")
                    {
                        permission = "ADMIN";
                    }
                    else
                    {
                        permission = "Nhân viên";
                    }
                    result = result + "<tr><td>" + dem +
                        "</td><td>" + re.GetValue(0).ToString() +
                        "</td><td>" + re.GetValue(1).ToString() +
                        "</td><td>" + re.GetValue(3).ToString() +
                        "</td><td>" + re.GetValue(2).ToString() +
                        "</td><td>" + permission +
                        "</td><td>" + status +
                        "</td><td><a href='UserDetail.aspx?userId=" + re.GetValue(0).ToString() + "&type=view'>Chi tiết</a></td></tr>";
                }
                re.Close();
                LitTaiKhoan.Text = result;
                render_Pagination(pages, page, limit);
            }
            catch (SqlException ex)
            {

                lblNotify.Text = "Không có tài khoản nào.";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                cls_con.open_DB();

                string fullname = Request.Form.Get("ctl00$ContentPlaceHolder1$txtFullname");
                string phone = Request.Form.Get("ctl00$ContentPlaceHolder1$txtPhone");
                string email = Request.Form.Get("ctl00$ContentPlaceHolder1$txtEmail");
                string password = Request.Form.Get("ctl00$ContentPlaceHolder1$txtPassword");
                password = hash.HashPass(password);
                string permissionId = Request.Form.Get("ctl00$ContentPlaceHolder1$ddlPermission");
                string status = Request.Form.Get("ctl00$ContentPlaceHolder1$ddlStatus");

                string sql = "insert into users(fullname, phone, email, password, permissionId, isBlock) values(N'" + fullname + "', '" + phone + "', '" + email + "', '" + password + "','" + permissionId + "', '" + status + "')";
                sqlcmt = new SqlCommand(sql, cls_con.con);
                int check = sqlcmt.ExecuteNonQuery();
                if (check != 0)
                {
                    Response.Redirect("Users.aspx?status=True");
                }
            }
            catch (SqlException ex)
            {
                lblAlert.Text = "Email đã tồn tại";
            }
            finally
            {
                cls_con.close_DB();
            }

        }

        protected void LoadPermission()
        {
            cls_con.open_DB();

            string sql = "select permissionId, name from permission";
            sqlcmt = new SqlCommand(sql, cls_con.con);
            re = sqlcmt.ExecuteReader();
            while (re.Read())
            {
                ddlPermission.Items.Add(new ListItem(re.GetValue(1).ToString(), re.GetValue(0).ToString()));
                DropListPermission.Items.Add(new ListItem(re.GetValue(1).ToString(), re.GetValue(0).ToString()));
            }
        }

        public void render_Pagination(int pages, int page, int limit)
        {
            string urlPrev = util.parseUrlUser(Request.Url.AbsolutePath, page - 1, limit);
            string urlNext = util.parseUrlUser(Request.Url.AbsolutePath, page + 1, limit);
            string pagination = @"<nav aria-label='Page navigation example' class='mt-2 d-flex justify-content-center'><ul class='pagination'>";
            string prev = @"<li class='page-item'><a class='page-link' href='" + urlPrev + "' aria-label='Previous'><span aria-hidden='true'>&laquo;</span><span class='sr-only' > Previous</span></a></li>";
            string next = @"<li class='page-item'><a class='page-link' href='" + urlNext + "' aria-label='Next' ><span aria-hidden='true'>&raquo;</span><span class='sr-only'>Next</span></a></li>";
            string paginationEnd = "</ul></nav>";

            if (page != 0 && page != 1)
            {
                pagination += prev;
            }
            for (int i = 1; i <= pages; i++)
            {
                string urlPage = util.parseUrlUser(Request.Url.AbsolutePath, i, limit);
                if (i == page)
                    pagination += @"<li class='page-item active'><div class='page-link'>" + i + "</div></li>";
                else
                    pagination += @"<li class='page-item'><a class='page-link' href='" + urlPage + "'>" + i + "</a></li>";
            }
            if (page != pages)
            {
                pagination += next;
            }
            LitPagination.Text = pagination;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            cls_con.open_DB();
            try
            {
                string search = txtSearch.Text.Trim();
                search = search.ToLower();
                string sql = "select * from users where userId like '%' + @id + '%' or fullname like '%' + @id + '%' or email like '%' + @id + '%'";
                sqlcmt = new SqlCommand(sql, cls_con.con);
                SqlParameter sqlpa = new SqlParameter();
                sqlpa.ParameterName = "@id";
                sqlpa.Value = search;
                sqlcmt.Parameters.Add(sqlpa);

                SqlDataReader re = sqlcmt.ExecuteReader();
                string result = "";
                string status = "";
                string permission = "";
                int dem = 0;
                while (re.Read())
                {
                    dem++;
                    status = re.GetValue(6).ToString();
                    permission = re.GetValue(5).ToString();
                    if (status == "False")
                    {
                        status = "Active";
                    }
                    else
                    {
                        status = "Unactive";
                    }
                    if (permission == "1")
                    {
                        permission = "ADMIN";
                    }
                    else
                    {
                        permission = "Nhân viên";
                    }
                    result = result + "<tr><td>" + dem +
                        "</td><td>" + re.GetValue(0).ToString() +
                        "</td><td>" + re.GetValue(1).ToString() +
                        "</td><td>" + re.GetValue(3).ToString() +
                        "</td><td>" + re.GetValue(2).ToString() +
                        "</td><td>" + permission +
                        "</td><td>" + status +
                        "</td><td><a href='UserDetail.aspx?userId=" + re.GetValue(0).ToString() + "&type=view'>Chi tiết</a></td></tr>";
                }
                re.Close();
                LitTaiKhoan.Text = result;
                if (dem == 0)
                {
                    lblNotify.Text = "Không có kết quả được tìm thấy.";
                }
                else
                {
                    lblNotify.Text = dem + " kết quả được tìm thấy.";
                }
            }
            catch (SqlException ex)
            {
                Response.Write("Lỗi: " + ex);
            }
        }

        protected void DropListPermission_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = DropListPermission.SelectedValue.ToString();

            try
            {
                cls_con.open_DB();
                string sql = "select * from users where permissionId=@id order by createdAt desc";
                sqlcmt = new SqlCommand(sql, cls_con.con);
                SqlParameter sqlpa = new SqlParameter();
                sqlpa.ParameterName = "@id";
                sqlpa.Value = id;
                sqlcmt.Parameters.Add(sqlpa);

                SqlDataReader re = sqlcmt.ExecuteReader();
                string result = "";
                string status = "";
                string permission = "";
                int dem = 0;
                while (re.Read())
                {
                    dem++;
                    status = re.GetValue(6).ToString();
                    permission = re.GetValue(5).ToString();
                    if (status == "False")
                    {
                        status = "Active";
                    }
                    else
                    {
                        status = "Unactive";
                    }
                    if (permission == "1")
                    {
                        permission = "ADMIN";
                    }
                    else
                    {
                        permission = "Nhân viên";
                    }
                    result = result + "<tr><td>" + dem +
                        "</td><td>" + re.GetValue(0).ToString() +
                        "</td><td>" + re.GetValue(1).ToString() +
                        "</td><td>" + re.GetValue(3).ToString() +
                        "</td><td>" + re.GetValue(2).ToString() +
                        "</td><td>" + permission +
                        "</td><td>" + status +
                        "</td><td><a href='UserDetail.aspx?userId=" + re.GetValue(0).ToString() + "&type=view'>Chi tiết</a></td><td><a href='UserDetail.aspx?userId=" + re.GetValue(0).ToString() + "&type=delete' style='color: red;'><i class='fas fa-trash-alt'></i></a></td></tr>";
                }
                re.Close();

                LitTaiKhoan.Text = result;
            }
            catch (SqlException ex)
            {
                Response.Write("Lỗi: " + ex);
            }



        }
    }
}