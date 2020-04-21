<%@ Page Title="" Language="C#" MasterPageFile="~/form/Layout.Master" AutoEventWireup="true" CodeBehind="UpadteTypeCard.aspx.cs" Inherits="BTL_QLBGX.form.UpadteTypeCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="w3-main" style="margin-left:300px;margin-top:43px;">
      <div class="w3-container">
     <div class="row">
                <div class="col-sm-6 offset-3">
                    <div class="card mt-5" style="box-shadow:0px 1px 11px -2px #838383;">
                        <div class="card-header bg-success text-center text-uppercase font-weight-bold header">Thông tin kiểu thẻ</div>
                         <div class="card-body">
                            <div class="form-group">
                                <label for="exampleInputEmail1">Mã thẻ</label>
                                <asp:TextBox type="text" class="form-control" ID="txt_mathe" runat="server" ReadOnly ="true"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputPassword1">Loại thẻ</label>
                                <asp:TextBox type="text" class="form-control" ID="txt_loaithe" runat="server"></asp:TextBox>
                            </div>
                             <div class="form-group">
                                <label for="exampleInputEmail1">Sale</label>
                                <asp:TextBox type="text" class="form-control" ID="txt_sale" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputPassword1">Ngày tạo</label>
                                <asp:TextBox type="text" class="form-control" ID="txt_creadat" runat="server" ReadOnly ="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="card-footer text-muted">
                         <div class="d-flex justify-content-between align-items-center p-2">
                             <asp:Button class="btn btn-danger" ID="btn_Delete" runat="server" Text="Delete" OnClick="Button1_Click" />
                             <asp:Button class="btn btn-info" ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
                             <a href="../form/Settings.aspx" style="text-decoration: underline;">Quay Lại trang trước</a>
                         </div>
                      </div>
                    </div>
                </div>
            </div>
           </div>
            </div>
</asp:Content>
