<%@ Page Title="" Language="C#" MasterPageFile="~/Web/WebMaster.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebBanHang_FoodHub.Web.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Giỏ hàng - FoodHub
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="style" runat="server">
    <link rel="stylesheet" href="css/cart.css">
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="menuContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="server">
    <h3 class="title-cart">Giỏ Hàng</h3>
    <div class="list-cart">
        <table>
            <thead>
                <tr>
                    <th>Sản phẩm</th>
                    <th>Tên sản phẩm</th>
                    <th>Đơn giá</th>
                    <th>Số lượng</th>
                    <th>Thành tiền</th>
                    <th>Xóa hàng</th>
                </tr>
            </thead>

            <tbody>
                <asp:Repeater ID="rptListCart" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <img src="../img/products/<%# Eval("UrlPicture") %>" alt="">
                            </td>
                            <td><%# Eval("ProductName") %></td>
                            <td><%# Eval("Price") %></td>
                            <td class="quantity">
                                <asp:Button runat="server" ID="btnMinus" Text="-" OnClick="btnMinus_Click" CommandArgument='<%# Eval("ProductId") %>'></asp:Button>
                                <asp:TextBox runat="server" ID="txtAmount" Text='<%#Eval("Quantity") %>' ReadOnly="true"></asp:TextBox>
                                <asp:Button runat="server" ID="btnPlus" Text="+" OnClick="btnPlus_Click" CommandArgument='<%# Eval("ProductId") %>'></asp:Button>
                            </td>
                            <td><%# Eval("Total") %></td>
                            <td>
                                <asp:LinkButton runat="server" ID="btnDelete" OnClick="btnDelete_Click" CommandArgument='<%# Eval("ProductId") %>' OnClientClick="return confirm('Bạn có muốn xóa sản phẩm này không?')">
                                    <i class="fa fa-trash" aria-hidden="true"></i>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>

    <div class="cart-bill">
        <div class="bill-content">
            <div class="total-money">
                Tổng tiền hàng:
                <asp:Label runat="server" ID="lblTotalMoney"></asp:Label>
            </div>
            <div>
                Tổng số lượng sản phẩm:
                <asp:Label runat="server" ID="lblTotalQuantity"></asp:Label>
            </div>
        </div>
        <div class="buy">
            <asp:Button Text="Đặt hàng" runat="server" ID="btnBuy" OnClick="btnBuy_Click"></asp:Button>

        </div>
        <div class="buy-more">
            <asp:Button Text="Tiếp tục mua hàng" runat="server" ID="btnBuyMore" PostBackUrl="~/Web/Home.aspx"></asp:Button>
        </div>
    </div>
</asp:Content>
