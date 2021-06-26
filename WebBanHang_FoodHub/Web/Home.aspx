<%@ Page Title="" Language="C#" MasterPageFile="~/Web/WebMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebBanHang_FoodHub.Web.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Trang chủ - FoodHub
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="style" runat="server">
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

<asp:Content ID="Content4" ContentPlaceHolderID="menuContent" runat="server">
    <div class="menu">
        <h3>Danh mục</h3>
        <ul>
            <li><a href="Home.aspx">Tất cả sản phẩm</a></li>
            <asp:Repeater ID="rptCategory" runat="server">
                <ItemTemplate>
                    <li>
                        <asp:LinkButton runat="server" OnClick="btnCategory_Click" PostBackUrl='<%# string.Format("~/Web/Home.aspx?categoryid={0}", Eval("CategoryId")) %>'><%#:Eval("CategoryName") %></asp:LinkButton>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
    <div class="sort-by">
        <p>Sắp xếp theo</p>
        <div>
            <asp:Button runat="server" ID="btnSortByCreated" Text="Mới nhất" OnClick="btnSortByCreatedDate_Click"></asp:Button>
        </div>
        <div>
            <asp:Button runat="server" ID="btnBestSell" Text="Bán chạy" OnClick="btnBestSell_Click"></asp:Button>
        </div>
        <div>
            <asp:DropDownList ID="ddlSortByPrice" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTimKiem_SelectedIndexChanged">
            </asp:DropDownList>
        </div>

    </div>
    <div class="list-product">
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <div class="product">
                    <a href="ProductDetail.aspx?ProductId=<%# Eval("ProductId") %>">
                        <img src="../img/products/<%# Eval("UrlPicture") %>" alt="">
                        <div class="product-name"><%# Eval("ProductName") %></div>
                        <div class="product-price"><%# Eval("Price") %></div>
                    </a>
                    &nbsp;&nbsp;&nbsp;&nbsp;<div class="order">
                        <button><i class="fa fa-shopping-cart" aria-hidden="true"></i></button>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="more-views">

        <asp:Button ID="btnMoreView" runat="server" Text="Xem thêm" OnClick="btnMoreView_Click" />

    </div>
</asp:Content>
