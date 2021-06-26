using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebBanHang_FoodHub.DataUtil
{
    public class Connection
    {
        public static SqlConnection Connect()
        {
            string strConn = @"Data Source=DESKTOP-0MTS6DU\SQLEXPRESS;Initial Catalog=WebBanHang_FoodHub;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strConn);
            return conn;
        }
    }
}