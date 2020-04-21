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
    public partial class edit_accesscard : System.Web.UI.Page
    {
        utils util = new utils();
        All_query qr = new All_query();
        protected void Page_Load(object sender, EventArgs e)
        { 
            try
            {
                if (!Page.IsPostBack)
                {
                    render_data();
                    disableInput();
                }
            }
            catch (SqlException ex)
            {
                Response.Write("Lỗi:" + ex);
            }
            finally
            {
                //qr.close_DB();
            }
        }
        public void render_data()
        {
            try {
                int id = Int32.Parse(Request.QueryString.Get("id"));
                SqlDataReader re;
                SqlDataReader AccessCardUser = qr.getData(sql_query.SELECT_ACCESSCARD_USER_BY_ID(id));
                SqlDataReader listTypeCard = qr.getData(sql_query.SELECT_ALL_TYPECARD);
                SqlDataReader listProducer = qr.getData(sql_query.SELECT_ALL_PRODUCER);
                string st_kq = "";
                // listTypeCard
                while (listTypeCard.Read())
                {
                    DropListTypeCard.Items.Add(new ListItem(listTypeCard.GetValue(1).ToString(), listTypeCard.GetValue(0).ToString()));
                }
                // listProduct
                while (listProducer.Read())
                {
                    DropListProducer.Items.Add(new ListItem(listProducer.GetValue(1).ToString(), listProducer.GetValue(0).ToString()));
                }
                DropListTypeCar.Items.Add(new ListItem("Ô tô", "Ô tô"));
                DropListTypeCar.Items.Add(new ListItem("Xe máy", "Xe máy"));
                if (AccessCardUser.Read())
                {
                    re = qr.getData(sql_query.SELECT_ACCESSCARD_BY_ID(id));
                    txtUser.Attributes.Add("readonly", "true");
                    DropListUsers.Attributes.Add("class", "d-none");
                    while (re.Read())
                    {
                        txtUser.Value = re.GetValue(1).ToString() + " - " + re.GetValue(2).ToString();
                        DropListTypeCard.SelectedValue = re.GetValue(3).ToString();
                        DropListProducer.SelectedValue = re.GetValue(7).ToString();
                        DropListTypeCar.SelectedValue = re.GetValue(6).ToString();
                        expired.Value = re.GetValue(4).ToString();
                        licensePlate.Value = re.GetValue(5).ToString();

                    }
                }
                else
                {
                    re = qr.getData("select typeCardId from AccessCard where accessCardId = "+ id);
                    while (re.Read())
                    {
                        DropListTypeCard.SelectedValue = re.GetValue(0).ToString();
                    }
                    txtUser.Attributes.Add("class", "d-none");
                    DropListUsers.Attributes.Add("class", "form-control");
                    SqlDataReader listUser = qr.getData(sql_query.SELECT_ALL_USERS_NOT_ACCESSCARD);
                    DropListUsers.Items.Add(new ListItem("Lựa chọn", "-1"));
                    while (listUser.Read())
                    {
                        DropListUsers.Items.Add(new ListItem(listUser.GetValue(2).ToString() + " - " + listUser.GetValue(1).ToString(), listUser.GetValue(0).ToString()));
                    }
                    btnSubmit.CausesValidation = false;
                }

            }
            catch (Exception ex)
            {
                Response.Redirect("/form/accesscard.aspx");
                //Response.Write("looxi"+ ex);
            }
        }
        protected void onSubmit(object sender, EventArgs e)
        {
            int id = Int32.Parse(Request.QueryString.Get("id"));
            string txtExpired = expired.Value ;
            string txtLicensePlate = licensePlate.Value;
            string txtTypeCar = DropListTypeCar.SelectedValue;
            int txtProducerId = Int32.Parse(DropListProducer.SelectedValue);
            int txtTypeCardId = Int32.Parse(DropListTypeCard.SelectedValue);
            SqlDataReader AccessCardUser = qr.getData(sql_query.SELECT_ACCESSCARD_USER_BY_ID(id));
            // cập nhật lại thẻ cho người dùng
            string sql = sql_query.UPDATE_ACCESSCARD_BY_ID(id, txtExpired, txtLicensePlate, txtTypeCar, txtProducerId, txtTypeCardId);
            int result = 0;
            if (AccessCardUser.Read())
            {
                result = qr.updateData(sql);
            }
            else
            {
                //thêm người dùng cho thẻ
                int userId = Int32.Parse(DropListUsers.SelectedValue);
                if(userId < 0)
                {
                    sql = "update AccessCard set typeCardId = '" + txtTypeCardId + "'  where accessCardId = " + id;
                    result = qr.updateData(sql);
                }else
                {
                    sql = sql_query.UPDATE_ACCESSCARD_BY_ID(id, txtExpired, txtLicensePlate, txtTypeCar, txtProducerId, txtTypeCardId, userId);
                    result = qr.updateData(sql);
                }
            }
            if (result != 0)
                Response.Redirect("/form/accesscard.aspx");
            else
                aaa.Text = "Update False";

            //aaa.Text = txtUser.Value+"-"+DropListTypeCard.SelectedValue + "-"+DropListProducer.SelectedValue +"-"+ expired.Value;
        }
        protected void changeUser(object sender, EventArgs e)
        {
            disableInput();
        }
        public void disableInput()
        {
            try
            {
                int userId = Int32.Parse(DropListUsers.SelectedValue);
                if (userId < 0)
                {
                    expired.Attributes.Add("disabled", "true");
                    licensePlate.Attributes.Add("disabled", "true");
                    DropListProducer.Attributes.Add("disabled", "true");
                    DropListTypeCar.Attributes.Add("disabled", "true");
                }
                else
                {
                    btnSubmit.CausesValidation = true;
                    expired.Attributes.Remove("disabled");
                    licensePlate.Attributes.Remove("disabled");
                    DropListProducer.Attributes.Remove("disabled");
                    DropListTypeCar.Attributes.Remove("disabled");
                }
            }catch(Exception ex){}
        }
    }
}