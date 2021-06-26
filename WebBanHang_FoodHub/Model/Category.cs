using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang_FoodHub.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Origin { get; set; }
        public int Active { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public Category()
        {

        }
    }
}