using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang_FoodHub.Model
{
    public class Account
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string UrlAvatar { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int IsAdmin { get; set; }
        public Account()
        {

        }
    }
}