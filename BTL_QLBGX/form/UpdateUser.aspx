<%@ Page Title="" Language="C#" MasterPageFile="~/form/Layout.Master" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="BTL_QLBGX.form.UpdateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="w3-main" style="margin-left: 300px; margin-top: 43px;">
        <div class="w3-container">
            <div class="jumbotron">
                <h1 class="display-4">Chỉnh sửa tài khoản</h1>
                <p>
                    <asp:Label ID="lblNotify" runat="server" Text="" CssClass="error"></asp:Label>
                </p>

                <div class="form-group">
                    <label for="">Số tài khoản</label>
                    <asp:TextBox ID="txtUserNumber" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="">Họ và tên</label>
                    <asp:TextBox ID="txtFullname" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Trường này không được để trống" ControlToValidate="txtFullname" CssClass="error" ValidationGroup="gvUpdate"></asp:RequiredFieldValidator>
                </div>


                <div class="form-group">
                    <label for="">Số điện thoại</label>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Trường này không được để trống" ControlToValidate="txtPhone" CssClass="error" ValidationGroup="gvUpdate"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Số điện thoại không đúng." CssClass="error" ControlToValidate="txtPhone" ValidationExpression="(0)+\d{9}"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <label for="">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Trường này không được để trống" ControlToValidate="txtEmail" CssClass="error" ValidationGroup="gvUpdate"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Email không đúng định dạng" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="gvUpdate" CssClass="error" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <label for="">Quyền truy cập</label>
                    <asp:DropDownList ID="DropListPermission" runat="server" CssClass="form-control" ></asp:DropDownList>
                </div>
                <br />
                <div class="form-group">
                    <label for="">Trạng thái</label>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" ></asp:DropDownList>
                </div>
                <br />

                <div class="form-group">
                    <label for="">Ngày tạo</label>
                    <asp:TextBox ID="txtCreateAt" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Lưu" ValidationGroup="gvUpdate" OnClick="btnSave_Click" />

            </div>

        </div>
    </div>




</asp:Content>
