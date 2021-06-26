using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang_FoodHub.Model
{
    public class Cart
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string UrlPicture { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }
        public Cart()
        {

        }
    }
}