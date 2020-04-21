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
    public partial class add_accesscard : System.Web.UI.Page
    {
        utils util = new utils();
        All_query qr = new All_query();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            { 
                if (!Page.IsPostBack)
                {
                    render_DropList(DropListUsers, sql_query.SELECT_ALL_USERS_NOT_ACCESSCARD);
                    render_DropList(DropListTypeCard, sql_query.SELECT_ALL_TYPECARD, false);
                    render_DropList(DropListProducer, sql_query.SELECT_ALL_PRODUCER);
                    disableInput();
                }
            }
            catch (SqlException ex)
            {
                Response.Write("Lỗi:" + ex);
            }
        }
        public void render_DropList(DropDownList droplist, string sql, Boolean select = true)
        {
            droplist.Items.Clear();
            SqlDataReader re = qr.getData(sql);
            if (select)
                droplist.Items.Add(new ListItem("Lựa chọn", "-1"));
            while (re.Read())
            {
                droplist.Items.Add(new ListItem(re.GetValue(1).ToString(), re.GetValue(0).ToString()));
            }
        }
        protected void onSubmit(object sender, EventArgs e)
        {
            int userId = Int32.Parse(DropListUsers.SelectedValue);
            int txtTypeCardId = Int32.Parse(DropListTypeCard.SelectedValue);
            string sql = "";
            int result = 0;
            if(userId < 0)
            {
                sql = "insert into AccessCard(typeCardId) values ("+ txtTypeCardId + ")";
                result = qr.updateData(sql);
            }
            else
            {
                string txtExpired = expired.Value;
                string txtLicensePlate = licensePlate.Value;
                string txtTypeCar = DropListTypeCar.Value;
                int txtProducerId = Int32.Parse(DropListProducer.SelectedValue);
                sql = "insert into AccessCard(expired,userId,typeCardId,licensePlate,producerId,typeCar) values('"+txtExpired+"', "+userId+", "+txtTypeCardId+", '"+txtLicensePlate+"', "+txtProducerId+", N'"+txtTypeCar+"')";
                result = qr.updateData(sql);
            }
            if (result != 0)
            {
                DropListProducer.SelectedIndex = DropListUsers.SelectedIndex = DropListTypeCard.SelectedIndex=  0;
                expired.Value = licensePlate.Value = "";
                notify.Attributes.Add("class", "color-success");
                notify.Text = "Tạo thành công";
            }
            else
            {
                notify.Attributes.Add("class", "color-errors");
                notify.Text = "Tạo thất bại";
            }
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
                    btnSubmit.CausesValidation = false;
                }
                else
                {
                    btnSubmit.CausesValidation = true;
                    expired.Attributes.Remove("disabled");
                    licensePlate.Attributes.Remove("disabled");
                    DropListProducer.Attributes.Remove("disabled");
                    DropListTypeCar.Attributes.Remove("disabled");
                }
            }
            catch (Exception ex) { }
        }
    }
}