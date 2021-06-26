using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBanHang_FoodHub.Model;

namespace WebBanHang_FoodHub.DataUtil
{
    public class DataProduct
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        public DataProduct()
        {
            conn = Connection.Connect();
        }

        public List<Product> ListProducts(int row)
        {
            conn.Open();
            List<Product> listProducts = new List<Product>();
            String sql = "SELECT  * FROM Product ORDER BY ProductId OFFSET "+ row +" ROWS FETCH NEXT 28 ROWS ONLY";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Product dv = new Product();
                dv.ProductId = int.Parse(dr["ProductId"].ToString());
                dv.ProductName = dr["ProductName"].ToString();
                dv.ProductCode = dr["ProductCode"].ToString();
                dv.UrlPicture = dr["UrlPicture"].ToString();
                dv.Price = float.Parse(dr["Price"].ToString());
                dv.Quantity = int.Parse(dr["Quantity"].ToString());
                dv.Unit = dr["Unit"].ToString();
                dv.Description = dr["Description"].ToString();
                dv.Infor = dr["Infor"].ToString();
                dv.CategoryId = int.Parse(dr["CategoryId"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("CreatedDate")))
                    dv.CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString());
                listProducts.Add(dv);
            }
            conn.Close();
            return listProducts;
        }

        public List<Product> ListProductsByProductName(string productName)
        {
            conn.Open();
            List<Product> listProducts = new List<Product>();
            String sql = "SELECT  * FROM Product WHERE ProductName like N'%'+@ProductName+'%'";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("ProductName", productName);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Product dv = new Product();
                dv.ProductId = int.Parse(dr["ProductId"].ToString());
                dv.ProductName = dr["ProductName"].ToString();
                dv.ProductCode = dr["ProductCode"].ToString();
                dv.UrlPicture = dr["UrlPicture"].ToString();
                dv.Price = float.Parse(dr["Price"].ToString());
                dv.Quantity = int.Parse(dr["Quantity"].ToString());
                dv.Unit = dr["Unit"].ToString();
                dv.Description = dr["Description"].ToString();
                dv.Infor = dr["Infor"].ToString();
                dv.CategoryId = int.Parse(dr["CategoryId"].ToString());
                if (!dr.IsDBNull(dr.GetOrdinal("CreatedDate")))
                    dv.CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString());
                listProducts.Add(dv);
            }
            conn.Close();
            return listProducts;
        }

        public Product FindById(int productId)
        {
            conn.Open();
            string sql = "select * from Product where ProductId = @ProductId";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("ProductId", productId);
            dr = cmd.ExecuteReader();
            Product dv = null;
            while (dr.Read())
            {
                dv = new Product();
                dv.ProductId = int.Parse(dr["ProductId"].ToString());
                dv.ProductName = dr["ProductName"].ToString();
                dv.ProductCode = dr["ProductCode"].ToString();
                dv.UrlPicture = dr["UrlPicture"].ToString();
                dv.Price = float.Parse(dr["Price"].ToString());
                dv.Quantity = int.Parse(dr["Quantity"].ToString());
                dv.Unit = dr["Unit"].ToString();
                dv.Description = dr["Description"].ToString();
                dv.Infor = dr["Infor"].ToString();
                dv.CategoryId = int.Parse(dr["CategoryId"].ToString());
                if (!dr.IsDBNull(dr.GetOrdinal("CreatedDate")))
                    dv.CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString());
            }
            conn.Close();
            return dv;
        }

        public List<Product> FindTopFourByCategoryId(int categoryId)
        {
            conn.Open();
            List<Product> products = new List<Product>();
            string sql = "select top(4) * from Product where CategoryId = @CategoryId";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("CategoryId", categoryId);
            dr = cmd.ExecuteReader();
            Product dv = null;
            while (dr.Read())
            {
                dv = new Product();
                dv.ProductId = int.Parse(dr["ProductId"].ToString());
                dv.ProductName = dr["ProductName"].ToString();
                dv.UrlPicture = dr["UrlPicture"].ToString();
                dv.Price = float.Parse(dr["Price"].ToString());
                products.Add(dv);
            }
            conn.Close();
            return products;
        }

        public List<Product> FindByCategoryId(int categoryId)
        {
            conn.Open();
            List<Product> listProducts = new List<Product>();
            String sql = "SELECT  * FROM Product WHERE CategoryId=@CategoryId";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("CategoryId", categoryId);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Product dv = new Product();
                dv.ProductId = int.Parse(dr["ProductId"].ToString());
                dv.ProductName = dr["ProductName"].ToString();
                dv.ProductCode = dr["ProductCode"].ToString();
                dv.UrlPicture = dr["UrlPicture"].ToString();
                dv.Price = float.Parse(dr["Price"].ToString());
                dv.Quantity = int.Parse(dr["Quantity"].ToString());
                dv.Unit = dr["Unit"].ToString();
                dv.Description = dr["Description"].ToString();
                dv.Infor = dr["Infor"].ToString();
                dv.CategoryId = int.Parse(dr["CategoryId"].ToString());
                if (!dr.IsDBNull(dr.GetOrdinal("CreatedDate")))
                    dv.CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString());
                listProducts.Add(dv);
            }
            conn.Close();
            return listProducts;
        }

        public int FindCategoryIdByProductId(int productId)
        {
            conn.Open();
            int categoryId = -1;
            String sql = "SELECT CategoryId FROM Product WHERE ProductId=@ProductId";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                categoryId = int.Parse(dr["CategoryId"].ToString());
            }
            conn.Close();
            return categoryId;
        }

        
    }
}