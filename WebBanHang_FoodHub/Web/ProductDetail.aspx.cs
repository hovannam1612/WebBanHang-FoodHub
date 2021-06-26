using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBanHang_FoodHub.DataUtil;
using WebBanHang_FoodHub.Model;

namespace WebBanHang_FoodHub.Web
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        DataProduct dataProduct = new DataProduct();
        DataCategory dataCategory = new DataCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCartQuantity();
                ProductDetail();
                ProductCategory();
                ProductRelate();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
        public void LoadCartQuantity()
        {
            int totalQuantity = 0;
            List<Cart> cartList = (List<Cart>)Session["GioHang"];
            if (cartList != null)
            {
                foreach (Cart cart in cartList)
                {
                    totalQuantity += int.Parse(cart.Quantity.ToString());
                }
                lblQuantity.Text = totalQuantity.ToString();
            }
            else
            {
                lblQuantity.Text = "0";
            }
        }
        private void ProductDetail()
        {
            int productId = int.Parse(Request.QueryString["ProductId"]);
            rptTopContent.DataSource = new object[] { dataProduct.FindById(productId) };
            DataBind();
        }

        private void ProductRelate()
        {
            int productId = int.Parse(Request.QueryString["ProductId"]);
            int categoryId = dataProduct.FindCategoryIdByProductId(productId);
            rptProductRelate.DataSource = dataProduct.FindTopFourByCategoryId(categoryId);
            rptProductRelate.DataBind();
        }
        private void ProductCategory()
        {
            int productId = int.Parse(Request.QueryString["ProductId"]);
            rptBottomContent.DataSource = new object[] { dataCategory.FindByProductId(productId) };
            DataBind();
        }

        protected void btnPlus_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptTopContent.Items)
            {
                TextBox txtQuantity = item.FindControl("txtAmount") as TextBox;
                txtQuantity.Text = (int.Parse(txtQuantity.Text) + 1).ToString();
            }
        }
        protected void btnMinus_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptTopContent.Items)
            {
                TextBox txtQuantity = item.FindControl("txtAmount") as TextBox;
                if (int.Parse(txtQuantity.Text) == 1)
                {
                    return;
                }
                else
                {
                    txtQuantity.Text = (int.Parse(txtQuantity.Text) - 1).ToString();
                }
            }
        }

        public void Order()
        {
            int quantity = 0;
            foreach (RepeaterItem item in rptTopContent.Items)
            {
                TextBox txtQuantity = item.FindControl("txtAmount") as TextBox;
                quantity = int.Parse(txtQuantity.Text);
            }

            int productId = int.Parse(Request.QueryString["ProductId"]);
            List<Cart> cartList = (List<Cart>)Session["GioHang"];
            Product product = dataProduct.FindById(productId);
            Cart cart = null;
            if (cartList == null)
            {
                cartList = new List<Cart>();

                cart = new Cart();
                cart.ProductId = product.ProductId;
                cart.ProductName = product.ProductName;
                cart.UrlPicture = product.UrlPicture;
                cart.Quantity = quantity;
                cart.Price = product.Price;
                cart.Total = quantity * product.Price;

                cartList.Add(cart);
                Session["GioHang"] = cartList;
            }
            else
            {
                bool check = false;
                foreach (Cart carts in cartList)
                {
                    if (productId == carts.ProductId)
                    {

                        carts.Quantity = quantity + carts.Quantity;

                        carts.Total = carts.Quantity * carts.Price;

                        check = true;
                    }
                }

                if (check == false)
                {
                    cart = new Cart();
                    cart.ProductId = product.ProductId;
                    cart.ProductName = product.ProductName;
                    cart.UrlPicture = product.UrlPicture;
                    cart.Quantity = quantity;
                    cart.Price = product.Price;
                    cart.Total = quantity * product.Price;

                    cartList.Add(cart);
                    Session["GioHang"] = cartList;
                }
                else
                {
                    Session["GioHang"] = cartList;
                }
            }
        }
        protected void btnBuyNow_Click(object sender, EventArgs e)
        {
            Order();
            Response.Redirect("Cart.aspx");
        }
        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Order();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

    }
}