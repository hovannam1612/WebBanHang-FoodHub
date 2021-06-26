using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBanHang_FoodHub.DataUtil;
using WebBanHang_FoodHub.Model;

namespace WebBanHang_FoodHub.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataProduct dataProduct = new DataProduct();
        DataCategory dataCategory = new DataCategory();
        int row;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCartQuantity();
                loadCategory();

                row = 0;
                rptList.DataSource = dataProduct.ListProducts(row);

                StatusMoreView();

                DataBind();

                LoadCombo();
            }
        }
        public void StatusMoreView()
        {
            btnMoreView.Visible = false;
            int items = dataProduct.ListProducts(row).Count();
            if (items >= 28)
                btnMoreView.Visible = true;
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

        public void LoadCombo()
        {
            ddlSortByPrice.Items.Add("Giá từ thấp đến cao");
            ddlSortByPrice.Items.Add("Giá cao đến thấp");
        }

        protected void ddlTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Product> products = null;
            if (ddlSortByPrice.SelectedIndex == 0)
            {
                products = dataProduct.ListProducts(0).OrderBy(o => o.Price).ToList();
            }
            if (ddlSortByPrice.SelectedIndex == 1)
            {
                products = dataProduct.ListProducts(0).OrderByDescending(o => o.Price).ToList();
            }
            rptList.DataSource = products;
            DataBind();
            loadCategory();
            StatusMoreView();

        }

        protected void btnSortByCreatedDate_Click(object sender, EventArgs e)
        {
            List<Product> products = dataProduct.ListProducts(0).OrderByDescending(o => o.CreatedDate).ToList();
            rptList.DataSource = products;
            DataBind();
            loadCategory();
            StatusMoreView();

        }
        protected void btnBestSell_Click(object sender, EventArgs e)
        {
            List<Product> products = dataProduct.ListProducts(0).OrderBy(x => Guid.NewGuid()).ToList();
            rptList.DataSource = products;
            DataBind();
            loadCategory();
            StatusMoreView();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtFilter.Text;
            rptList.DataSource = dataProduct.ListProductsByProductName(search);
            DataBind();
            loadCategory();

            StatusMoreView();
        }


        protected void btnMoreView_Click(object sender, EventArgs e)
        {
            row = row + 28;
            rptList.DataSource = dataProduct.ListProducts(row);
            DataBind();
            loadCategory();
            btnMoreView.Visible = false;

            StatusMoreView();

        }

        public void loadCategory()
        {
            rptCategory.DataSource = dataCategory.ListCategory();
            DataBind();
        }

        public void loadProductByCategoryId(int categoryId)
        {
            rptList.DataSource = dataProduct.FindByCategoryId(categoryId);
            DataBind();
        }

        protected void btnCategory_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(Request.QueryString["categoryid"]);
            loadProductByCategoryId(categoryId);
            loadCategory();
        }
    }
}