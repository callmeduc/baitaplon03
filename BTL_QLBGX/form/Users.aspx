<%@ Page Title="" Language="C#" MasterPageFile="~/form/Layout.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="BTL_QLBGX.form.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-main" style="margin-left: 300px; margin-top: 43px;">
        <div class="w3-container">
            <h2 class="h2_title text-uppercase m-3">Thông tin tài khoản</h2>
            <asp:Label ID="lblAlert" runat="server" Text="" CssClass="error mt-3"></asp:Label>
            <div>
                <div class="d-flex">
                    <div>
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" ></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="btnSearch" runat="server" Text="- Tìm kiếm -" CssClass=" btn btn-success ml-3 mr-3" OnClick="btnSearch_Click" />
                        
                    </div>
                        
                    <div>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="DropListPermission" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="permissionId" OnSelectedIndexChanged="DropListPermission_SelectedIndexChanged"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connect_QLBGX %>" SelectCommand="SELECT [permissionId], [name] FROM [permission]"></asp:SqlDataSource>
                    </div>
                </div>
                <div>

                    <!-- Button trigger modal -->
                    <button type="button" class="btn btn-primary mt-3" data-toggle="modal" data-target="#exampleModal">
                        Thêm mới</button>
                </div>
                <asp:Label ID="lblNotify" runat="server" Text="" CssClass="error mt-3"></asp:Label>
            </div>

            <table class="w3-table w3-striped w3-bordered w3-border w3-hoverable w3-white mt-2">
                <tr class="bg-dodgerblue-tr-table">
                    <th>STT</th>
                    <th>Mã tài khoản</th>
                    <th>Họ & Tên</th>
                    <th>Email</th>
                    <th>Điện thoại</th>
                    <th>Chức vụ</th>
                    <th>Trạng thái</th>
                    <th colspan="3" class="text-center">Thực thi</th>
                </tr>

                <asp:Literal runat="server" ID="LitTaiKhoan" />
            </table>
            
            <asp:Literal ID="LitPagination" runat="server"></asp:Literal>
        </div>

        <!-- Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Form thêm mới tài khoản</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">

                        <div class="form-group">
                            <label for="">Họ và tên</label>
                            <asp:TextBox ID="txtFullname" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Trường này không được để trống" ControlToValidate="txtFullname" CssClass="error" ValidationGroup="gvSave"></asp:RequiredFieldValidator>

                        </div>
                        <div class="form-group">
                            <label for="">Số điện thoại</label>
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Trường này không được để trống" ControlToValidate="txtPhone" CssClass="error" ValidationGroup="gvSave"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Trường này chỉ được nhập số!" CssClass="error" ControlToValidate="txtPhone" ValidationExpression="(0)+\d{9}"></asp:RegularExpressionValidator> 
                        </div>
                        <div class="form-group">
                            <label for="">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Trường này không được để trống" ControlToValidate="txtEmail" CssClass="error" ValidationGroup="gvSave"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="">Mật khẩu</label>
                            <input id="txtPassword" type="password" runat="server" class="form-control" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Trường này không được để trống" ControlToValidate="txtPassword" CssClass="error" ValidationGroup="gvSave"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="">Cấp quyến</label>
                            <asp:DropDownList ID="ddlPermission" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="">Trạng thái</label>
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Unactive" Selected="true" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:Button ID="btnSubmit" runat="server" Text="Lưu" CssClass="btn btn-primary" OnClick="btnSubmit_Click" ValidationGroup="gvSave" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-danger" />
                    </div>  
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>

        
    </script>
</asp:Content>
