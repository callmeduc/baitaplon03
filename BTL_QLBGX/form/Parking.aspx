<%@ Page Title="" Language="C#" MasterPageFile="~/form/Layout.Master" AutoEventWireup="true" CodeBehind="Parking.aspx.cs" Inherits="BTL_QLBGX.form.Parking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="w3-main" style="margin-left:300px;margin-top:43px;">
      <div class="w3-container">
        <h2 class="h2_title text-uppercase m-3">Quản lý lượt gửi</h2>
        <div>
            <div class="d-flex">
             <div>
                 <input type="text" class="form-control" id="txtSearch" name="txtSearch" runat="server" placeholder="Tìm biển số">
             </div>
                <asp:Button type="submit" class="btn btn-success ml-1 mr-2" ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />
            </div>
        </div>
        <table class="w3-table w3-striped w3-bordered w3-border w3-hoverable w3-white mt-2">
            <tr class="bg-dodgerblue-tr-table">
                <th>STT</th>
                <th>Họ & Tên</th>
                <th>Email</th>
                <th>Biển số vào</th>
                <th>Biển số ra</th>
                <th>Thời gian vào</th>
                <th>Thời gian ra</th>
                <th>Giá tiền</th>
            </tr>
            <asp:Literal runat="server" ID="Ltr_qlrv" />
        </table>
        <asp:Label runat="server" ID="notify"></asp:Label>
        <asp:Literal runat="server" ID="LitPagination" />
      </div>
    </div>
</asp:Content>
