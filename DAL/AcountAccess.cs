using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DAL
{
    public class AcountAccess: DatabaseAccess
    {
        public List<Account>Acount(string username, string password)
        {
            List<Account> User = new List<Account>();
            OpenConnection();
            SqlCommand command = new SqlCommand("check_dangnhap", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@tendn", username);
            command.Parameters.AddWithValue("@matkhau", password);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tendn = reader["Tendangnhap"].ToString();
                string manv = reader["IDNhanVien"].ToString();
                string bophan = reader["IDBoPhan"].ToString();
                Account account = new Account();
                account.Tendangnhap = tendn;
                account.IDNhanVien = manv;
                account.IDBoPhan = bophan;
                User.Add(account);
                
            }
            reader.Close();
            return User;
        }

        public string checklogin(string username, string password)
        {
            string user = null;
            OpenConnection();
            SqlCommand command = new SqlCommand("check_dangnhap", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@tendn", username);
            command.Parameters.AddWithValue("@matkhau", Hash(password));
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user = reader.GetString(0)+"_"+ reader.GetString(2)+"_"+ reader.GetString(3) + "_" + reader["TenNhanVien"].ToString();
                    return user;
                }
                reader.Close();
                conn.Close();
            }
            return user;
        }


        private static string getbumhash(byte[] data)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }
            return builder.ToString();
        }
        public static string Hash(string data)
        {
            using (var bum = SHA256.Create())
            {
                return getbumhash(bum.ComputeHash(Encoding.UTF8.GetBytes(data)));
            }
        }

        // tbl_ bàn ăn
        public int update_matkhau_moi(string username, string pass)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("update_matkhau_moi", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@pass", Hash(pass));
            int ret = cmd.ExecuteNonQuery();
            return ret;
        }

    }
}
