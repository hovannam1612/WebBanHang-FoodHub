using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBanHang_FoodHub.Model;

namespace WebBanHang_FoodHub.DataUtil
{
    public class DataOrderProduct
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        public DataOrderProduct()
        {
            conn = Connection.Connect();
        }

        public int InsertOrderProduct(OrderProduct orderProduct)
        {
            conn.Open();
            cmd = new SqlCommand("Proc_InsertOrderProduct", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FullName",orderProduct.FullName);
            cmd.Parameters.AddWithValue("@Active", orderProduct.Active);
            cmd.Parameters.AddWithValue("@PhoneNumber", @orderProduct.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", @orderProduct.Email);
            cmd.Parameters.AddWithValue("@Address", @orderProduct.Address);
            cmd.Parameters.AddWithValue("@Quantity", @orderProduct.Quantity);
            cmd.Parameters.AddWithValue("@Total", @orderProduct.Total);
            cmd.Parameters.AddWithValue("@Description", @orderProduct.Description);
            int rowAffects =  cmd.ExecuteNonQuery();
            conn.Close();
            return rowAffects;
        }
    }
}