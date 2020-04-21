<%@ Page Title="" Language="C#" MasterPageFile="~/form/Layout.Master" AutoEventWireup="true" CodeBehind="InsertTypeCard.aspx.cs" Inherits="BTL_QLBGX.form.InsertTypeCard1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="container">
            <div class="row">
                <div class="col-sm-6 offset-3">
                    <div class="card mt-5" style="box-shadow:0px 1px 11px -2px #838383;">
                        <div class="card-header bg-success text-center text-uppercase font-weight-bold header">Thêm kiểu thẻ</div>
                         <div class="card-body">
                            <div class="form-group">
                                <label for="exampleInputPassword1">Tên thẻ</label>
                                <asp:TextBox type="text" class="form-control" ID="txt_loaithe" runat="server" placeholder="Nhập TypeCard"></asp:TextBox>
                            </div>
                             <div class="form-group">
                                <label for="exampleInputEmail1">Giảm giá</label>
                                <asp:TextBox type="text" class="form-control" ID="txt_sale" runat="server" placeholder="Nhập giảm giá"></asp:TextBox>
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
                          <asp:Button ID="insertTyperCard" type="submit" class="btn btn-primary btn-block" runat="server" Text="Thêm kiểu thẻ" OnClick="insertTyperCard_Click" />
                      </div>
                    </div>
                </div>
            </div>
        </div>

</asp:Content>
