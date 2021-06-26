using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBanHang_FoodHub.DataUtil;
using WebBanHang_FoodHub.Model;

namespace WebBanHang_FoodHub.Login
{
    public partial class Login : System.Web.UI.Page
    {
        DataAccount dataAccount = new DataAccount();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUserName.Text;
            String password = txtPassword.Text;
            Account tk = null;
            if (username != null && password != null)
            {
                tk = dataAccount.FindOneUser(username, password);

                if (tk != null)
                {
                    if (Session["TaiKhoan"] == null)
                    {
                        Session["TaiKhoan"] = tk;
                    }

                    int isAdmin = tk.IsAdmin;
                    if (isAdmin == 1)
                    {
                        Response.Redirect("~/Admin/AdminHome.aspx");
                    }
                    else if (isAdmin == 0)
                    {
                        Response.Redirect("~/Web/Home.aspx");
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Tên đăng nhập hoặc mật khẩu không đúng')", true);
                }
            }
        }
    }
}