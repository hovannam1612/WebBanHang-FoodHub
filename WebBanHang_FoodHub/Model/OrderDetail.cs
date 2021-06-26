using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang_FoodHub.Model
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public OrderDetail()
        {

        }
    }
}