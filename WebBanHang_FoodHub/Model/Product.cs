using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang_FoodHub.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public float Price { get; set; }
        public string UrlPicture { get; set; }
        public int Quantity { get; set; }   
        public string Unit { get; set; }
        public string Description { get; set; }
        public string Infor { get; set; }
        public int CategoryId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Product()
        {

        }

    }
}