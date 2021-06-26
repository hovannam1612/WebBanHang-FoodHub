using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBanHang_FoodHub.Model;

namespace WebBanHang_FoodHub.DataUtil
{
    public class DataCategory
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        public DataCategory()
        {
            conn = Connection.Connect();
        }

        public List<Category> ListCategory()
        {
            conn.Open();
            List<Category> listProducts = new List<Category>();
            String sql = "SELECT CategoryId,CategoryName FROM Category";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Category dv = new Category();
                dv.CategoryId = int.Parse(dr["CategoryId"].ToString());
                dv.CategoryName = dr["CategoryName"].ToString();
                listProducts.Add(dv);
            }
            conn.Close();
            return listProducts;
        }
        public Category FindByProductId(int productId)
        {
            conn.Open();
            string sql = "select Product.CategoryId, CategoryName, Origin, Manufacturer, Active, Description from Category inner join Product on Category.CategoryId = Product.CategoryId where Product.ProductId = @ProductId";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("ProductId", productId);
            dr = cmd.ExecuteReader();
            Category dv = null;
            while (dr.Read())
            {
                dv = new Category();
                dv.CategoryId = int.Parse(dr["CategoryId"].ToString());
                dv.CategoryName = dr["CategoryName"].ToString();
                dv.Origin = dr["Origin"].ToString();
                dv.Manufacturer = dr["Manufacturer"].ToString();
                dv.Active = int.Parse(dr["Active"].ToString());
                dv.Description = dr["Description"].ToString();
            }
            conn.Close();
            return dv;
        }
    }
}