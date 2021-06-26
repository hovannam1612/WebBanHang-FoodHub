using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBanHang_FoodHub.Model;

namespace WebBanHang_FoodHub.Web
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListCart();
                SumTotal();
            }
        }
        
        public void ListCart()
        {
            List<Cart> cartList = (List<Cart>)Session["GioHang"];
            if (cartList != null)
            {
                rptListCart.DataSource = cartList;
                DataBind();
            }
        }

        protected void btnMinus_Click(object sender, EventArgs e)
        {
            int productId = int.Parse(((Button)sender).CommandArgument.ToString());

            List<Cart> carts = (List<Cart>)Session["GioHang"];
            foreach (Cart cart in carts)
            {
                if (cart.ProductId == productId)
                {
                    if (cart.Quantity == 1)
                    {
                        return;
                    }
                    else
                    {
                        cart.Quantity = cart.Quantity - 1;
                        cart.Total = cart.Quantity * cart.Price;
                    }

                    break;
                }
            }

            Session["GioHang"] = carts;
            rptListCart.DataSource = carts;
            DataBind();

            Page.Response.Redirect(Page.Request.Url.ToString(), true);

        }

        protected void btnPlus_Click(object sender, EventArgs e)
        {
            int productId = int.Parse(((Button)sender).CommandArgument.ToString());

            List<Cart> carts = (List<Cart>)Session["GioHang"];
            foreach (Cart cart in carts)
            {
                if (cart.ProductId == productId)
                {
                    cart.Quantity = cart.Quantity + 1;
                    cart.Total = cart.Quantity * cart.Price;
                    break;
                }
            }

            Session["GioHang"] = carts;
            rptListCart.DataSource = carts;
            DataBind();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int productId = int.Parse(((LinkButton)sender).CommandArgument.ToString());
            List<Cart> carts = (List<Cart>)Session["GioHang"];
            foreach (Cart cart in carts)
            {
                if (cart.ProductId == productId)
                {
                    carts.Remove(cart);
                    break;
                }
            }

            Session["GioHang"] = carts;
            rptListCart.DataSource = carts;
            DataBind();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void SumTotal()
        {
            int sumQuantity = 0;
            float sumTotalMoney = 0;
            List<Cart> carts = (List<Cart>)Session["GioHang"];
            if (carts != null)
            {
                foreach (Cart cart in carts)
                {
                    sumQuantity += cart.Quantity;
                    sumTotalMoney += cart.Total;
                }
            }
            lblTotalMoney.Text = sumTotalMoney.ToString();
            lblTotalQuantity.Text = sumQuantity.ToString();
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            List<Cart> carts = (List<Cart>)Session["GioHang"];
            if(carts == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Chưa có hàng trong giỏ')", true);
                return;
            }
            else
            {
                Response.Redirect("Payment.aspx");
            }
        }
    }
}