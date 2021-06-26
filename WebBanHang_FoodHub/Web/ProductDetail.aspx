<%@ Page Title="" Language="C#" MasterPageFile="~/Web/WebMaster.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="WebBanHang_FoodHub.Web.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Chi tiết sản phẩm - FoodHub
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="style" runat="server">
    <link rel="stylesheet" href="css/detail_product.css">
</asp:Content>
<asp:Content ID="content5" ContentPlaceHolderID="mainHeader" runat="server">
    <div class="main-header">
        <a href="Home.aspx">
            <img src="../img/logo.png" alt="logo" width="120px" height="60px"></a>
        <div class="filter">
            <asp:TextBox type="text" ID="txtFilter" runat="server" placeholder="Tìm kiếm..."></asp:TextBox>
        </div>
        <div class="search">
            <asp:LinkButton runat="server" ID="btnSearch" OnClick="btnSearch_Click">
                            <i class="fa fa-search" aria-hidden="true"></i>
            </asp:LinkButton>
        </div>
        <div class="cart">
            <asp:LinkButton runat="server" PostBackUrl="~/Web/Cart.aspx">
                <i class="fa fa-shopping-cart" aria-hidden="true"></i>
                <asp:Label runat="server" ID="lblQuantity"></asp:Label>
            </asp:LinkButton>
        </div>

        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
    <asp:Repeater ID="rptTopContent" runat="server">
        <ItemTemplate>
            <div class="top-content">
                <div class="left-content">
                    <img src="../img/products/<%# Eval("UrlPicture") %>" alt="">
                    <div class="interactive">
                        <div class="share">
                            <span>Chia sẻ <i class="fa fa-facebook-square" aria-hidden="true"></i><i
                                class="fa fa-instagram" aria-hidden="true"></i></span>
                        </div>
                        <div class="like">
                            <span>Yêu thích <i class="fa fa-heart" aria-hidden="true"></i></span>
                        </div>
                    </div>
                </div>

                <div class="right-content">
                    <h3><%# Eval("ProductName") %></h3>
                    <div class="price"><%# Eval("Price") %>đ</div>
                    <div class="row">
                        <div class="infor">Thông tin</div>
                        <div>
                            <%# Eval("Infor") %>
                        </div>
                    </div>
                    <div class="row">
                        <div>Số lượng</div>
                        <div class="quantity">
                            <asp:Button runat="server" ID="minus" Text="-" OnClick="btnMinus_Click"></asp:Button>
                            <asp:TextBox runat="server" type="number" ID="txtAmount" value="1"></asp:TextBox>
                            <asp:Button runat="server" ID="plus" Text="+" OnClick="btnPlus_Click"></asp:Button>
                        </div>
                    </div>
                    <div class="row">
                        <div>Đơn vị</div>
                        <div><%# Eval("Unit") %></div>
                    </div>
                    <div class="order-buy">
                        <div class="order">
                            <asp:Button runat="server" ID="btnOrder" OnClick="btnOrder_Click" Text="Thêm vào giỏ hàng"></asp:Button>
                        </div>
                        <div class="buy-now">
                            <asp:Button runat="server" ID="btnBuyNow" OnClick="btnBuyNow_Click" Text="Mua ngay"></asp:Button>
                        </div>
                        <div class="buy-more">
                            <asp:Button ID="btnBuyMore" runat="server" PostBackUrl="~/Web/Home.aspx" Text="Tiếp tục mua hàng">
                                
                            </asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Repeater ID="rptBottomContent" runat="server">
        <ItemTemplate>
            <div class="detail-content">
                <div class="row">
                    <h3>Chi tiết sản phẩm</h3>
                    <div class="sub-row">
                        <div>Danh mục</div>
                        <div><%# Eval("CategoryName") %></div>
                    </div>
                    <div class="sub-row">
                        <div>Xuất xứ</div>
                        <div><%# Eval("Origin") %></div>
                    </div>
                    <div class="sub-row">
                        <div>Thương hiệu</div>
                        <div><%# Eval("Manufacturer") %></div>
                    </div>
                </div>
                <div class="row">
                    <h3>Mô tả sản phẩm</h3>
                    <div>
                        <%# Eval("Description") %>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <div class="bot-content">
        <h3>Các sản phẩm liên quan</h3>
        <div class="row">
            <asp:Repeater ID="rptProductRelate" runat="server">
                <ItemTemplate>
                    <div class="product">
                        <a href="ProductDetail.aspx?ProductId=<%# Eval("ProductId") %>">
                            <img src="../img/products/<%# Eval("UrlPicture") %>" alt="">
                            <div class="product-name"><%# Eval("ProductName") %></div>
                            <div class="product-price"><%# Eval("Price") %></div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
