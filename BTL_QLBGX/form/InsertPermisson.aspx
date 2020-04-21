<%@ Page Title="" Language="C#" MasterPageFile="~/form/Layout.Master" AutoEventWireup="true" CodeBehind="InsertPermisson.aspx.cs" Inherits="BTL_QLBGX.form.InsertPermisson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="w3-main" style="margin-left:300px;margin-top:43px;">
        <div class="container">
            <div class="row">
                <div class="col-sm-6 offset-3">
                    <div class="card mt-5" style="box-shadow:0px 1px 11px -2px #838383;">
                        <div class="card-header bg-success text-center text-uppercase font-weight-bold header">Thêm quyền</div>
                         <div class="card-body">
                            <div class="form-group">
                                <label for="exampleInputPassword1">Quyền</label>
                                <asp:TextBox type="text" class="form-control" ID="txt_Permisson" runat="server"></asp:TextBox>
                            </div> 
                             <div class="form-group">
                                <label for="exampleInputPassword1">Trạng thái</label>
                                 <asp:DropDownList type="text" class="form-control" ID="status" runat="server">
                                     <asp:ListItem>True</asp:ListItem>
                                     <asp:ListItem>False</asp:ListItem>
                                 </asp:DropDownList>
                            </div>
                        </div>
                        <div class="card-footer text-muted">
                          <asp:Button ID="insertTyperCard" type="submit" class="btn btn-primary btn-block" runat="server" Text="Thêm kiểu thẻ" OnClick="insertPermisson_Click" />
                      </div>
                      </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
