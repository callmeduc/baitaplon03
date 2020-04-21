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
    public partial class Parking : System.Web.UI.Page
    {
        utils util = new utils();
        All_query qr = new All_query();
        SqlCommand sqlcm;
        cls_connect conn = new cls_connect();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    render_table();
                }
            }
            catch (SqlException ex)
            {
                Response.Write("Lỗi:" + ex);
            }
            finally
            {
                qr.close_DB();
            }
        }
        public void render_table()
        {
            try
            {
                conn.open_DB();
                findParse fp = new findParse();
                int page = fp.parseIntParams("page", 1);
                int limit = fp.parseIntParams("limit", 10);
                string search = Request.QueryString.Get("search") != null ? Request.QueryString.Get("search") : "";
                txtSearch.Value = search;
                int total = qr.getCount(sql_query.SELECT_COUNT_USER_PARKING(search));
                int pages = (int)Math.Ceiling((decimal)total / limit);
                page = page > pages ? pages : page;
                int offset = limit * (page - 1);
                SqlDataReader re = qr.getData(sql_query.SELECT_INFO_USER_PARKING(offset, limit, search));
                string st_kq = "";
                int dem = 0;
                while (re.Read())
                {
                    dem += 1;
                    st_kq += "<tr><td>" + dem + "</td><td>" + re.GetValue(0).ToString() + "</td><td>" + re.GetValue(1).ToString() + "</td><td>" + re.GetValue(2).ToString() + "</td><td>" + re.GetValue(3).ToString() + "</td><td>" + re.GetValue(4).ToString() + "</td><td>" + re.GetValue(5).ToString() + "</td><td>" + re.GetValue(6).ToString() + "</td></tr>";
                }
                Ltr_qlrv.Text = st_kq;
                render_pagination(pages, page, limit, search);
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
        public void render_pagination(int pages, int page, int limit, string search)
        {
            string urlPrev = util.parseUrl(Request.Url.AbsolutePath, page - 1, limit, search);
            string urlNext = util.parseUrl(Request.Url.AbsolutePath, page + 1, limit, search);
            string pagination = @"<nav aria-label='Page navigation example' class='mt-2 d-flex justify-content-center'><ul class='pagination'>";
            string prev = @"<li class='page-item'><a class='page-link' href='" + urlPrev + "' aria-label='Previous'><span aria-hidden='true'>&laquo;</span><span class='sr-only' > Previous</span></a></li>";
            string next = @"<li class='page-item'><a class='page-link' href='" + urlNext + "' aria-label='Next' ><span aria-hidden='true'>&raquo;</span><span class='sr-only'>Next</span></a></li>";
            string paginationEnd = "</ul></nav>";
            if (page != 0 && page != 1) pagination += prev;
            for (int i = 1; i <= pages; i++)
            {
                string urlPage = util.parseUrl(Request.Url.AbsolutePath, i, limit, search);
                if (i == page)
                    pagination += @"<li class='page-item active'><div class='page-link'>" + i + "</div></li>";
                else
                    pagination += @"<li class='page-item'><a class='page-link' href='" + urlPage + "'>" + i + "</a></li>";
            }
            if (page != pages) pagination += next;
            LitPagination.Text = pagination;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            Response.Redirect("/form/Parking.aspx?search=" + txtSearch.Value);
        }
    }
}