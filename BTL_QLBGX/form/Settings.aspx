
<%@ Page Title="" Language="C#" MasterPageFile="~/form/Layout.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="BTL_QLBGX.form.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 38px;
        }
        .auto-style3 {
            height: 38px;
            width: 122px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-main" style="margin-left:300px;margin-top:43px;">
      <div class="w3-container">
        <h2 class="h2_title font-weight-bold text-uppercase m-3">Cài đặt chức năng</h2>
        <div class="card">
            <div class="card-header d-flex justify-content-between align-items-center">
                <div class="font-weight-bold text-uppercase">Nhà sản xuất</div>
                <asp:Button ID="Button2" type="button" class="btn btn-primary btn-sm fas fa-plus-circle" data-toggle="tooltip" data-placement="top" title="Thêm" runat="server" Text="Thêm" OnClick="Button2_Click" />
            </div>
            <div class="card-body">
                <table class="w3-table w3-striped w3-bordered w3-border w3-hoverable w3-white mt-2">
                    <tr class="bg-dodgerblue-tr-table">
                        <th>STT</th>
                        <th>Nhà sản xuất</th>
                        <th>Ngày tạo</th>
                        <th>Thực thi</th>
                    </tr>
                    <asp:Literal runat="server" ID="LitSinhVien" />
                </table>
            </div>
          </div>
          <div class="card mt-3">
            <div class="card-header d-flex justify-content-between align-items-center">
                <div class="font-weight-bold text-uppercase">Kiểu thẻ</div>
                <asp:Button ID="Button1" type="button" class="btn btn-primary btn-sm fas fa-plus-circle" data-toggle="tooltip" data-placement="top" title="Thêm" runat="server" Text="Thêm" OnClick="Button1_Click"/>
            </div>
            <div class="card-body">
                <table class="w3-table w3-striped w3-bordered w3-border w3-hoverable w3-white mt-2">
                    <tr class="bg-dodgerblue-tr-table">
                        <th class="auto-style3">STT</th>
                        <th class="auto-style1">Loại thẻ</th>
                        <th class="auto-style1">Giảm Giá</th>
                        <th class="auto-style1">Thời gian tạo</th>
                        <th class="auto-style1">Thực thi</th>
                    </tr>
                    <asp:Literal runat="server" ID="Literal1" />                    
                </table>
            </div>
          </div>
          <div class="card mt-3">
            <div class="card-header d-flex justify-content-between align-items-center">
                <div class="font-weight-bold text-uppercase">Phân quyền</div>
                <asp:Button ID="Button3" type="button" class="btn btn-primary btn-sm fas fa-plus-circle" data-toggle="tooltip" data-placement="top" title="Thêm" runat="server" Text="Thêm" OnClick="Button3_Click"/>
            </div>
            <div class="card-body">
                <table class="w3-table w3-striped w3-bordered w3-border w3-hoverable w3-white mt-2">
                    <tr class="bg-dodgerblue-tr-table">
                        <th class="auto-style3">STT</th>
                        <th class="auto-style1">Quyền</th>
                        <th class="auto-style1">Trạng thái</th>
                        <th class="auto-style1">Thực thi</th>
                    </tr>
                    <asp:Literal runat="server" ID="Literal2" />                    
                </table>
            </div>
        </div>
      </div>
    </div>
</asp:Content>
