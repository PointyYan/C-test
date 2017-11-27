using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DAL
{
    public  class userDAO
    {
        public Model.UserInfo SelectUser(string userName, string Password)
        {
 
            string ConnString = @"Server =127.0.0.1;DataBase =UserInfo; User ID =sa ;Password =yjq9735";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT ID,UserName,Password,Email   
                                        FROM UserInfo WHERE UserName =@UserName 
                                        AND Password =@Password";

                cmd.CommandType = CommandType.Text;

   
                cmd.Parameters.Add(new SqlParameter(@"UserName", userName));
                cmd.Parameters.Add(new SqlParameter(@"Password", Password));

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                Model.UserInfo user = null;

   
                while (reader.Read())
                {
                    if (user == null)
                    {
                        user = new Model.UserInfo();
                    }
   
                    user.ID = reader.GetInt32(0);
                    user.UserName = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                    {
                        user.Email = reader.GetString(3);
                    }
                }
                conn.Close();
                return user;
            }
        }
    
        public  DataSet GetListUser()
        {
            string ConnString = @"Server =127.0.0.1;DataBase =UserInfo; User ID =sa ;Password =yjq9735";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT ID,UserName,Email FROM UserInfo";
                cmd.CommandType = CommandType.Text;

                List<UserInfo> list = null;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection); 
            
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                da.Fill(ds);
 
                while (reader.Read())
                {
                    string Email;
                    int ID = reader.GetInt32(reader.GetOrdinal("id"));
                    string UserName = reader.GetString(1);
                    string PassWord = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                        Email = reader.GetString(3); 
                    UserInfo userInfo = new UserInfo(ID,UserName,PassWord);
                    list.Add(userInfo);
                }

                conn.Close();

                return ds;
            }

            }
    }
}
