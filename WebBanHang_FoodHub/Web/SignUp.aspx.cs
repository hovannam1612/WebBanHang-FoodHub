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
    public partial class WebForm5 : System.Web.UI.Page
    {
        DataAccount dataAccount = new DataAccount();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.UserName = txtUserName.Text;
            account.FullName = txtFullName.Text;
            account.Password = txtPassword.Text;
            account.Address = txtAddress.Text;
            account.Email = txtEmail.Text;
            account.PhoneNumber = txtPhoneNumber.Text;
            account.IsAdmin = 0;

            int rowAffect = dataAccount.InsertAccount(account);
            if(rowAffect > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Đăng ký thành công')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Tên đăng nhập đã có trên hệ thống')", true);
            }
        }
        
    }
}