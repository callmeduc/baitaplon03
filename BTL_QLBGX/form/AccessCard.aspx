<%@ Page Title="" Language="C#" MasterPageFile="~/form/Layout.Master" AutoEventWireup="true" CodeBehind="AccessCard.aspx.cs" Inherits="BTL_QLBGX.form.AccessCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-main" style="margin-left:300px;margin-top:43px;">
      <div class="w3-container">
        <h2 class="h2_title font-weight-bold text-uppercase m-3">Thông tin thẻ gửi xe</h2>
        <div style="position:relative;">
            <div class="d-flex"> 
                <div>
                    <input type="text" class="form-control" id="txtSearch" name="txtSearch" runat="server" placeholder="Tìm kiếm theo tên,email chủ thẻ">
                </div>
                <asp:Button runat="server" OnClick="change" Text="Tìm kiếm" CssClass="btn btn-success ml-2"/>
                <div class="ml-3">
                    <asp:DropDownList CssClass="form-control" runat="server" ID="DropListTypeCard" AutoPostBack="true" OnSelectedIndexChanged="change"></asp:DropDownList>
                </div>
            </div>
            <div>
                <a href="/form/add-accesscard.aspx" class="btn btn-primary" style="position: absolute;top: 0;right: 0;color: white; cursor:pointer;">
                    <i class="fas fa-plus-circle"></i>
                </a>
            </div>
        </div>
        <asp:Label runat="server" ID="aaa"></asp:Label>
        <table class="w3-table w3-striped w3-bordered w3-border w3-hoverable w3-white mt-3">
            <tr class="bg-dodgerblue-tr-table">
                <th>STT</th>
                <th>Chủ thẻ</th>
                <th>Email</th>
                <th>Loại thẻ</th>
                <th>Hết hạn</th>
                <th>Biển số</th>
                <th>Loại xe</th>
                <th>Thời gian tạo</th>
                <th>Thực thi</th>
            </tr>
            <asp:Literal runat="server" ID="ListAccessCard" />
        </table>
        <asp:Label runat="server" ID="notify"></asp:Label>
        <asp:Literal runat="server" ID="LitPagination" />
      </div>
    </div>
</asp:Content>
