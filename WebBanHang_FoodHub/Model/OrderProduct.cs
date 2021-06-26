using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang_FoodHub.Model
{
    public class OrderProduct
    {
        public int OrderId { get; set; }

        public DateTime OrderedDate { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public int Active { get; set; }

        public float Total { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public OrderProduct()
        {

        }

    }
}