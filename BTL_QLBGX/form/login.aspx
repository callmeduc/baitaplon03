<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BTL_QLBGX.form.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <link href="../style/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .error{
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-6 offset-3">
                    <div class="card mt-5" style="box-shadow:0px 1px 11px -2px #838383;">
                        <div class="card-header bg-white text-center text-uppercase font-weight-bold">Hệ thống quản lý thông tin</div>
                        <div class="card-img text-center">
                            <img class="img-fluid rounded-circle" src="../images/icon-ks-10-1.png" />
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="">Email</label>
                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="error" ErrorMessage="Trường nay không được trống" ControlToValidate="txtEmail" ValidationGroup="gvLogin" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email không đúng định dạng" ControlToValidate="txtEmail" CssClass="error" ValidationGroup="gvLogin" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>  
                            </div>
                              <div class="form-group">
                                <label for="">Mật khẩu</label>
                                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="error" ErrorMessage="Trường nay không được trống" ValidationGroup="gvLogin" ControlToValidate="txtPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                              </div>
                        </div>
                      <div class="card-footer text-muted">
                          <div>
                              <asp:Button ID="txtLogin" runat="server" Text="Đăng nhập hệ thống" CssClass="btn btn-primary btn-block" ValidationGroup="gvLogin" OnClick="txtLogin_Click" />
                              <div class="mt-3 mb-3 text-center">
                                  <asp:Label ID="lblBotify" CssClass="error" runat="server" Text=""></asp:Label>
                              </div>
                          </div>
                         <div class="d-flex justify-content-between align-items-center p-2">
                             <div>
                                 <asp:Button ID="btnDestroy" CssClass="btn btn-danger" runat="server" Text="Hủy bỏ" />
                             </div>
                             <div>
                                <input type="checkbox" /> Nhớ mật khẩu !
                             </div>
                             <a href="#" style="text-decoration: underline;">Quên mật khẩu</a>
                         </div>
                      </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../style/js/jquery.min.js"></script>
    <script src="../style/js/boostrap.min.js"></script>
</body>
</html>
