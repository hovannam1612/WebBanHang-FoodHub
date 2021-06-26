using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBanHang_FoodHub.Model;

namespace WebBanHang_FoodHub.DataUtil
{
    public class DataAccount
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        public DataAccount()
        {
            conn = Connection.Connect();
        }

        public Account FindOneUser(String username, String password)
        {
            try
            {
                conn.Open();
                String sql = "select * from UserAccount where UserName=@UserName and Password=@Password";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password);
                dr = cmd.ExecuteReader();
                Account tk = null;
                while (dr.Read())
                {
                    tk = new Account();
                    tk.UserId = int.Parse(dr["UserId"].ToString());
                    tk.UserName = dr["UserName"].ToString();
                    tk.Password = dr["Password"].ToString();
                    tk.Address = dr["Address"].ToString();
                    tk.PhoneNumber = dr["PhoneNumber"].ToString();
                    tk.FullName = dr["FullName"].ToString();
                    tk.Email = dr["Email"].ToString();
                    tk.IsAdmin = int.Parse(dr["IsAdmin"].ToString());
                    tk.UrlAvatar = dr["UrlAvatar"].ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("DateOfBirth")))
                        tk.DateOfBirth = DateTime.Parse(dr["DateOfBirth"].ToString());
                }
                return tk;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return null;
        }

        public int InsertAccount(Account account)
        {
            conn.Open();
            cmd = new SqlCommand("Proc_InsertAccount", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", account.UserName);
            cmd.Parameters.AddWithValue("@FullName", account.FullName);
            cmd.Parameters.AddWithValue("@Password", account.Password);
            cmd.Parameters.AddWithValue("@Address", account.Address);
            cmd.Parameters.AddWithValue("@PhoneNumber", account.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", account.Email);
            cmd.Parameters.AddWithValue("@IsAdmin", account.IsAdmin);
            int rowAffects = cmd.ExecuteNonQuery();
            conn.Close();
            return rowAffects;
        }
    }
}