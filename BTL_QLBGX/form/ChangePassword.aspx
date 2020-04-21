<%@ Page Title="" Language="C#" MasterPageFile="~/form/Layout.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="BTL_QLBGX.form.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="w3-main" style="margin-left: 300px; margin-top: 43px;">
        <div class="w3-container">
            <div class="jumbotron">
                <h1 class="display-4">Đổi mật khẩu</h1>
                <p>
                    <asp:Label ID="lblNotify" runat="server" Text="" CssClass="error"></asp:Label>
                </p>
                <div class="form-group">
                    <label for="">Mật khẩu cũ</label>
                    <asp:TextBox ID="txtPasswordCu" runat="server" class="form-control" TextMode="Password" ControlToValidate="txtPasswordCu"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Trường này không được để rỗng" CssClass="error" ControlToValidate="txtPasswordCu" ValidationGroup="gvSave"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="">Mật khẩu mới</label>
                    <asp:TextBox ID="txtPassNew1" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Trường này không được để rỗng" CssClass="error" ControlToValidate="txtPassNew1" ValidationGroup="gvSave"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="">Mật khẩu mới</label>
                    <asp:TextBox ID="txtPassNew2" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Trường này không được để rỗng" CssClass="error" ControlToValidate="txtPassNew2" ValidationGroup="gvSave"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Mật khẩu không trùng" ControlToCompare="txtPassNew1" CssClass="error" ControlToValidate="txtPassNew2" ValidationGroup="gvSave"></asp:CompareValidator>
                </div>
                <asp:Button ID="btnSaveChangePass" runat="server" Text="Lưu" CssClass="btn btn-primary" OnClick="btnSaveChangePass_Click" ValidationGroup="gvSave" />
                <asp:Button ID="btnBack" runat="server" Text="Hủy" CssClass="btn btn-danger" OnClick="btnBack_Click" />
                
            </div>
        </div>
        
        
    </div>
</asp:Content>
