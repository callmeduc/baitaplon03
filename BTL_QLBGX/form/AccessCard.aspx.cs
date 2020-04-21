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
    public partial class AccessCard : System.Web.UI.Page
    {
        utils util = new utils();
        All_query qr = new All_query();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    render_table();
                    render_DropList_TypeCard();
                }
                UserProfileSessionData user = (UserProfileSessionData)Session["user"];
                
            }
            catch(SqlException ex)
            {
                Response.Write("Lỗi:" + ex);
            }
            finally
            {
                qr.close_DB();
            }
        }
        protected void change(object sender, EventArgs e)
        {
            int typecard = Int32.Parse(DropListTypeCard.SelectedValue);
            Response.Redirect("/form/accesscard.aspx?typecard=" + typecard + "&search=" + txtSearch.Value );
        }
        public void render_DropList_TypeCard(string select = "-1")
        {
            DropListTypeCard.Items.Clear();
            SqlDataReader re = qr.getData(sql_query.SELECT_ALL_TYPECARD);
            DropListTypeCard.Items.Add(new ListItem("Lựa chọn", "-1"));
            while (re.Read())
            {
                DropListTypeCard.Items.Add(new ListItem(re.GetValue(1).ToString(), re.GetValue(0).ToString()));
            }
            if (Request.QueryString.Get("typecard") != null)
                select = Request.QueryString.Get("typecard");
            DropListTypeCard.SelectedValue = select;
        }
        public void render_table()
        {
            try
            {
                findParse fp = new findParse();
                int page = fp.parseIntParams("page", 1);
                int limit = fp.parseIntParams("limit", 10);
                int typeCard = fp.parseIntParams("typecard", -1);
                string search = Request.QueryString.Get("search") != null ? Request.QueryString.Get("search") : "";
                txtSearch.Value = search;
                int total = qr.getCount(sql_query.SELECT_COUNT_ACCESSCARD(typeCard, search));
                int pages = (int)Math.Ceiling((decimal)total / limit);
                page = page > pages ? pages : page;
                int offset = limit * (page - 1);
                SqlDataReader re = qr.getData(sql_query.SELECT_ACCESSCARD_PAGINATION(offset, limit, typeCard, search));
                string st_kq = "";
                int dem = 0;
                while (re.Read())
                {
                    dem += 1;
                    string fullName = re.GetValue(0).ToString() != "" ? re.GetValue(0).ToString() : "Chưa đăng ký";
                    string email = re.GetValue(1).ToString() != "" ? re.GetValue(1).ToString() : "";
                    string expired = re.GetValue(3).ToString() != "" ? re.GetValue(3).ToString() : "";
                    st_kq += "<tr><td>" + dem + "</td><td>" + fullName + "</td><td>" + email + "</td><td>" + re.GetValue(2).ToString() + "</td><td>" + expired + "</td><td>" + re.GetValue(4).ToString() + "</td><td>" + re.GetValue(5).ToString() + " - " + re.GetValue(6).ToString() + "</td><td>" + re.GetValue(7).ToString() + "</td><td><a href='/form/edit-accesscard.aspx?id=" + re.GetValue(9).ToString() + "' class='btn btn-outline-danger btn-sm'><i class='fas fa-eye'></i> Chi tiết</a></td></tr>";
                }
                ListAccessCard.Text = st_kq;
                if (st_kq.Equals(""))
                {
                    notify.Text = "Không có thẻ nào";
                }
                render_pagination(pages, page, limit, typeCard, search);
            }
            catch( Exception ex)
            {
                notify.Text = "Không có thẻ nào";
            }
        }
        public void render_pagination(int pages, int page, int limit, int typeCard,string search)
        {
            string urlPrev = util.parseUrl(Request.Url.AbsolutePath, page - 1, limit, typeCard, search);
            string urlNext = util.parseUrl(Request.Url.AbsolutePath, page + 1, limit, typeCard, search);
            string pagination = @"<nav aria-label='Page navigation example' class='mt-2 d-flex justify-content-center'><ul class='pagination'>";
            string prev = @"<li class='page-item'><a class='page-link' href='"+ urlPrev + "' aria-label='Previous'><span aria-hidden='true'>&laquo;</span><span class='sr-only' > Previous</span></a></li>";
            string next = @"<li class='page-item'><a class='page-link' href='" + urlNext + "' aria-label='Next' ><span aria-hidden='true'>&raquo;</span><span class='sr-only'>Next</span></a></li>";
            string paginationEnd = "</ul></nav>";
            if(page != 0 && page != 1) pagination += prev;
            for(int i = 1; i<= pages; i++)
            {
                string urlPage = util.parseUrl(Request.Url.AbsolutePath, i, limit, typeCard, search);
                if (i == page)
                    pagination += @"<li class='page-item active'><div class='page-link'>" + i + "</div></li>";
                else
                    pagination += @"<li class='page-item'><a class='page-link' href='" + urlPage + "'>" + i + "</a></li>";
            }
            if (page != pages) pagination += next;
            LitPagination.Text = pagination;
        }
    } 
}