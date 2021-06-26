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
    public partial class WebForm4 : System.Web.UI.Page
    {
        DataOrderProduct dataOrderProduct = new DataOrderProduct();
        DataOrderDetail dataOrderDetail = new DataOrderDetail();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFullName.Focus();
                LoadInforCart();
            }
        }

        public void LoadInforCart()
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
            txtQuantity.Text = sumQuantity.ToString();
            txtTotal.Text = sumTotalMoney.ToString();
            txtTotal.Enabled = false;
            txtQuantity.Enabled = false;
        }
        public void Payment(int active)
        {
            int rowAffects = 0;
            List<Cart> carts = (List<Cart>)Session["GioHang"];

            OrderProduct orderProduct = new OrderProduct();
            orderProduct.Active = active;
            orderProduct.Address = txtAddress.Text;
            orderProduct.Description = txtDescription.Text;
            orderProduct.Email = txtEmail.Text;
            orderProduct.FullName = txtFullName.Text;
            orderProduct.Quantity = int.Parse(txtQuantity.Text);
            orderProduct.Total = float.Parse(txtTotal.Text);
            orderProduct.PhoneNumber = txtPhoneNumber.Text;

            if(carts != null)
            {
                rowAffects = dataOrderProduct.InsertOrderProduct(orderProduct);
            }

            if (rowAffects > 0)
            {
                if (carts != null)
                {
                    foreach (Cart cart in carts)
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.ProductId = cart.ProductId;
                        orderDetail.Quantity = cart.Quantity;
                        dataOrderDetail.InsertOrderDetail(orderDetail);
                    }
                    Session.Remove("GioHang");
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Đặt hàng thành công')", true);
            }
        }

        protected void btnPayOnDelivery_Click(object sender, EventArgs e)
        {
            Payment(0);
        }

        protected void btnPayOnOnline_Click(object sender, EventArgs e)
        {
            Payment(1);
        }

        
    }
}