using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBanHang_FoodHub.Model;

namespace WebBanHang_FoodHub.Web
{
    public partial class WebMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAccont();
            }
        }
        
        protected void LoadAccont()
        {
            Account tk = null;
            if (Session["TaiKhoan"] != null)
            {
                tk = (Account)Session["TaiKhoan"];
                lblLogin.Visible = false;
                ltrUserName.Text = "<span style='color:white;'>" + "Chào," + tk.FullName + "</span>";
            }
            else
            {
                lblLogin.Visible = true;
                lblLogout.Visible = false;
            }
        }

        protected void lblLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Home.aspx");
        }

        protected void lblLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
       
        
    }
}