<%@ Page Title="" Language="C#" MasterPageFile="~/form/Layout.Master" AutoEventWireup="true" CodeBehind="edit-accesscard.aspx.cs" Inherits="BTL_QLBGX.form.edit_accesscard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-main" style="margin-left:300px;margin-top:43px;">
        <div class="w3-container">
            <h2 class="h2_title font-weight-bold text-uppercase m-3">Chi tiết thẻ ra vào</h2>
            <div class="m-3">
                <div class="form-row"> 
                    <div class="form-group col-md-6">
                        <asp:Label runat="server" ID="aaa" />
                        <label for="inputEmail4">Thành viên</label>
                        <input class="form-control" id="txtUser" readonly runat="server"  />
                        <asp:DropDownList  runat="server" ID="DropListUsers" AutoPostBack="true" OnSelectedIndexChanged="changeUser"></asp:DropDownList>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="inputPassword4">Loại thẻ</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="DropListTypeCard"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputAddress">Hết hạn</label>
                    <input type="date" class="form-control" id="expired" name="expired" runat="server" placeholder="Thời gian hết hạn thẻ tháng, năm ,...">
                </div>
                <div class="form-group">
                    <label for="inputAddress">Hãng sản xuất</label>
                    <asp:DropDownList CssClass="form-control" runat="server" ID="DropListProducer"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="inputAddress">Loại xe</label>
                    <asp:DropDownList CssClass="form-control" runat="server" ID="DropListTypeCar"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="inputAddress">Biển số</label>
                    <input type="text" class="form-control" id="licensePlate" name="licensePlate" runat="server" placeholder="Biển số xe">
                    <asp:RequiredFieldValidator ID="RequiredFieldlicensePlate" runat="server" ErrorMessage="Bạn vui lòng nhập biển số" ControlToValidate="licensePlate" Display="Dynamic" CssClass="color-errors"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionlicensePlate" runat="server" ErrorMessage="Biển số không hợp lệ" ViewStateMode="Inherit" ValidationExpression="(\d{2})+( )+\w{1}\d{1}\-\d{5}" ControlToValidate="licensePlate" CssClass="color-errors" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
                <asp:Button runat="server" ID="btnSubmit" OnClick="onSubmit" Text="Cập nhật" CssClass="btn btn-block btn-outline-primary mt-3"/>
                <a href="/form/accesscard.aspx" class="btn btn-block btn-danger mt-3"">Quay lại</a>
            </div>
        </div>
    </div>
</asp:Content>
