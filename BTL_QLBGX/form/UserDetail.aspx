<%@ Page Title="" Language="C#" MasterPageFile="~/form/Layout.Master" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="BTL_QLBGX.form.abc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-main" style="margin-left: 300px; margin-top: 43px;">
        <div class="w3-container">
            <div class="jumbotron">
                <h1 class="display-4">Thông tin tài khoản</h1>
                <p>
                    <a href="/form/Users.aspx" class="mr-5">Quay lại</a>
                    
                </p> 

                <p>
                    <asp:Button ID="btnChangePass" runat="server" Text="Đổi mật khẩu" CssClass="btn btn-primary" OnClick="ChangePass_Click" />
                    
                </p>
                <p>
                    <asp:Label ID="lblNotify" runat="server" Text="" CssClass="error"></asp:Label>
                </p>

                <div class="form-group">
                    <label for="">Số tài khoản</label>
                    <asp:TextBox ID="txtUserNumber" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="">Họ và tên</label>
                    <asp:TextBox ID="txtFullname" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Trường này không được để trống" ControlToValidate="txtFullname" CssClass="error"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="">Số điện thoại</label>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Trường này không được để trống" ControlToValidate="txtPhone" CssClass="error"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Trường này chỉ được nhập số!" CssClass="error" ControlToValidate="txtPhone" ValidationExpression="(0)+\d{9}"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <label for="">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Trường này không được để trống" ControlToValidate="txtEmail" CssClass="error"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="">Quyền truy cập</label>
                    <asp:DropDownList ID="DropListPermission" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                </div>
                <br />
                <div class="form-group">
                    <label for="">Trạng thái</label>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                </div>
                <br />

                <div class="form-group">
                    <label for="">Ngày tạo</label>
                    <asp:TextBox ID="txtCreateAt" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Trường này không được để trống" ControlToValidate="txtEmail" CssClass="error"></asp:RequiredFieldValidator>
                </div>

                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Chỉnh sửa" OnClick="btnSave_Click" />

            </div>

        </div>
    </div>
    
</asp:Content>
