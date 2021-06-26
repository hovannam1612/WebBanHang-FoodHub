<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebBanHang_FoodHub.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập - FoodHub</title>
    <link href="login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="background-img">
            </div>
            <div class="login-form">
                <a href="../Web/Home.aspx"><div class="logo">
                </div>
                    </a>
                <h3>Đăng nhập hệ thống</h3>
                <asp:TextBox runat="server" type="text" placeholder="Tên đăng nhập" ID="txtUserName" />
                <asp:TextBox type="password" placeholder="Mật khẩu" runat="server" ID="txtPassword" />
                <asp:Button ID="btnSubmit" runat="server" Text="Đăng nhập" OnClick="btnLogin_Click"></asp:Button>
                <asp:Button ID="btnSignUp" PostBackUrl="~/Web/SignUp.aspx" runat="server" Text="Đăng Ký"></asp:Button>
            </div>
        </div>
    </form>
</body>
</html>
