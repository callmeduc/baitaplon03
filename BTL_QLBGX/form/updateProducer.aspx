<%@ Page Title="" Language="C#" MasterPageFile="~/form/Layout.Master" AutoEventWireup="true" CodeBehind="updateProducer.aspx.cs" Inherits="BTL_QLBGX.form.updateProducer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-main" style="margin-left:300px;margin-top:43px;">
      <div class="w3-container">
         <div class="row">
            <div class="col-sm-6 offset-3">
                <div class="card mt-5" style="box-shadow:0px 1px 11px -2px #838383;">
                    <div class="card-header bg-success text-center text-uppercase font-weight-bold header">Thông tin nhà sản xuất</div>
                        <div class="card-body">
                        <div class="form-group">
                            <label for="exampleInputEmail1">Mã nhà sản xuất</label>
                            <asp:TextBox type="text" class="form-control" ID="txt_idProduct" runat="server" ReadOnly ="true"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1">Nhà sản xuất</label>
                            <asp:TextBox type="text" class="form-control" ID="txt_Product" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1">Ngày tạo</label>
                            <asp:TextBox type="text" class="form-control" ID="txt_creadat" runat="server" ReadOnly ="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="card-footer text-muted">
                        <div class="d-flex justify-content-between align-items-center p-2">
                            <asp:Button class="btn btn-danger" ID="btn_Delete" runat="server" Text="Delete" OnClick="Button1_Click" />
                            <asp:Button class="btn btn-info" ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click"/>
                            <a href="../form/Settings.aspx" style="text-decoration: underline;">Quay Lại trang trước</a>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </div>
    </div>
</asp:Content>
