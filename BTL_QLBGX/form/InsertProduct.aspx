<%@ Page Title="" Language="C#" MasterPageFile="~/form/Layout.Master" AutoEventWireup="true" CodeBehind="InsertProduct.aspx.cs" Inherits="BTL_QLBGX.form.InsertProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-main" style="margin-left:300px;margin-top:43px;">
        <div class="container">
            <div class="row">
                <div class="col-sm-6 offset-3">
                    <div class="card mt-5" style="box-shadow:0px 1px 11px -2px #838383;">
                        <div class="card-header bg-success text-center text-uppercase font-weight-bold header">Thêm Nhà Sản Xuất</div>
                         <div class="card-body">
                            <div class="form-group">
                                <label for="exampleInputPassword1">Nhà sản xuất</label>
                                <asp:TextBox type="text" class="form-control" ID="txt_Product" runat="server"></asp:TextBox>
                            </div>
                                <label for="exampleInputPassword1">Ngày tạo</label>
                             <div class="form-group">
                                <div class="d-flex justify-content-between align-items-center p-2">
                                    <asp:TextBox type="text" class="form-control" runat="server" ID="DrDate" ReadOnly ="true"></asp:TextBox>
                                    <asp:TextBox type="text" class="form-control" ID="DrMonth" runat="server" ReadOnly ="true"></asp:TextBox>
                                    <asp:TextBox type="text" class="form-control" ID="DrYear" runat="server" ReadOnly ="true"></asp:TextBox>
                                </div>
                             </div>
                        </div>
                      <div class="card-footer text-muted">
                          <asp:Button ID="insertProduct" type="submit" class="btn btn-primary btn-block" runat="server" Text="Thêm nhà sản xuất" OnClick="insertProduct_Click" />
                      </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
