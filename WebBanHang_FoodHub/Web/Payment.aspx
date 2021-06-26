<%@ Page Title="" Language="C#" MasterPageFile="~/Web/WebMaster.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="WebBanHang_FoodHub.Web.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Thanh toán - FoodHub
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="style" runat="server">
    <link rel="stylesheet" href="css/payment.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menuContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="server">
    <div class="dialog">
        <h3>Thông tin thanh toán</h3>
        <asp:ValidationSummary ValidationGroup="checkInput" ForeColor="Red" ID="ValidationSummary1" runat="server" />
        <div class="row">
            <span>Họ tên</span>
            <asp:TextBox runat="server" ID="txtFullName"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" runat="server" ControlToValidate="txtFullName"
                        ErrorMessage="Bạn phải nhập họ tên" ValidationGroup="checkInput"></asp:RequiredFieldValidator>
        </div>
        <div class="row">
            <span>Số điện thoại</span>
            <asp:TextBox runat="server" ID="txtPhoneNumber"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="None" runat="server" ControlToValidate="txtPhoneNumber"
                        ErrorMessage="Bạn phải nhập số điện thoại" ValidationGroup="checkInput"></asp:RequiredFieldValidator>
        </div>
        <div class="row">
            <span>Email</span>
            <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="None" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Bạn phải nhập email" ValidationGroup="checkInput"></asp:RequiredFieldValidator>
        </div>
        <div class="row">
            <span>Địa chỉ</span>
            <asp:TextBox runat="server" ID="txtAddress"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="None" runat="server" ControlToValidate="txtAddress"
                        ErrorMessage="Bạn phải nhập địa chỉ" ValidationGroup="checkInput"></asp:RequiredFieldValidator>
        </div>
        <div class="row">
            <span>Số lượng hàng hóa</span>
            <asp:TextBox runat="server" ID="txtQuantity"></asp:TextBox>
        </div>
        <div class="row">
            <span>Thành tiền</span>
            <asp:TextBox runat="server" ID="txtTotal"></asp:TextBox>
        </div>
        <div class="row description">
            <span>Ghi chú</span>
            <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="row">
            <asp:Button ValidationGroup="checkInput" runat="server" ID="btnPayOnDelivery" Text="Thanh toán khi nhận hàng" OnClick="btnPayOnDelivery_Click"></asp:Button>
            <asp:Button ValidationGroup="checkInput" runat="server" ID="btnPayOnOnline" Text="Thanh toán online" OnClick="btnPayOnOnline_Click"></asp:Button>
        </div>
    </div>
   
</asp:Content>
