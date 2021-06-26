using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBanHang_FoodHub.Model;

namespace WebBanHang_FoodHub.DataUtil
{
    public class DataOrderDetail
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        public DataOrderDetail()
        {
            conn = Connection.Connect();
        }

        public int InsertOrderDetail(OrderDetail orderProduct)
        {
            conn.Open();
            cmd = new SqlCommand("Proc_InsertOrderDetail", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductId", orderProduct.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", orderProduct.Quantity);
            int rowAffects = cmd.ExecuteNonQuery();
            conn.Close();
            return rowAffects;
        }
    }
}