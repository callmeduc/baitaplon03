<%@ Page Title="" Language="C#" MasterPageFile="~/form/Layout.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BTL_QLBGX.form.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!-- !PAGE CONTENT! -->
    <div class="w3-main" style="margin-left:300px;margin-top:43px;">

      <!-- Header -->
      <header class="w3-container" style="padding-top:22px">
        <h5><b><i class="fas fa-tachometer-alt"></i> Tổng hợp dữ liệu hệ thống</b></h5>
      </header>

      <div class="w3-row-padding w3-margin-bottom">
        <div class="w3-quarter">
          <div class="w3-container w3-red w3-padding-16">
            <div class="w3-left"><i class="fas fa-users fs-32"></i></div>
            <div class="w3-right">
              <h3><asp:Label runat="server" ID="sumUser"/></h3>
            </div> 
            <div class="w3-clear"></div>
            <h4>Tài khoản</h4>
          </div>
        </div>
        <div class="w3-quarter">
          <div class="w3-container w3-blue w3-padding-16">
            <div class="w3-left"><i class="fas fa-user-times fs-32"></i></div>
            <div class="w3-right">
              <h3><asp:Label runat="server" ID="sumAccessCard"/></h3>
            </div>
            <div class="w3-clear"></div>
            <h4>Thẻ gửi xe</h4>
          </div>
        </div>
        <div class="w3-quarter">
          <div class="w3-container w3-teal w3-padding-16">
            <div class="w3-left"><i class="fas fa-university fs-32"></i></div>
            <div class="w3-right">
              <h3><asp:Label runat="server" ID="sumParking"/></h3>
            </div>
            <div class="w3-clear"></div>
            <h4>Lượt gửi</h4>
          </div>
        </div>
        <div class="w3-quarter">
          <div class="w3-container w3-orange w3-text-white w3-padding-16">
            <div class="w3-left"><i class="fas fa-lock fs-32"></i></div>
            <div class="w3-right">
              <h3><asp:Label runat="server" ID="sumAmountParking"/></h3>
            </div>
            <div class="w3-clear"></div>
            <h4>Tổng doanh thu</h4>
          </div>
        </div>
      </div>

      <div class="w3-container">
        <h5>Lượt gửi gần nhất</h5>
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
      </div>
</asp:Content>
