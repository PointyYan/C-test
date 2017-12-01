using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public abstract class DBHelper
    {

        private static string connStr = @"Server =127.0.0.1;DataBase =UserInfo; User ID =sa ;Password =yjq9735";

        private DBHelper() { }

        public static string GetSqlConnStr()
        {
            return ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString;
        }

        //接受一个sql语句
        //返回受影响的行数
        public static int ExecuteNonQuery(string str, params SqlParameter[] sqlParameter)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = str;
                    cmd.Parameters.AddRange(sqlParameter);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //返回查询结果第一行的值
        //其他行将被忽略
        //一般用来查询数量
        public static object ExecuteScalar(string str, params SqlParameter[] sqlParameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = str;
                    cmd.Parameters.AddRange(sqlParameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        //返回一个DataTable
        public static DataTable ExecuteDataTable(string str, params SqlParameter[] sqlParameters)
        {
            SqlConnection conn = new SqlConnection(connStr);
            using (SqlDataAdapter da = new SqlDataAdapter(str, connStr))
            {
                SqlCommand cmd = new SqlCommand(str, conn);
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.SelectCommand.Parameters.AddRange(sqlParameters);
                da.Fill(dt);
                return dt;
            }
        }

        //返回一个DataSet
        public static DataSet ExecuteDataSet(string str, params SqlParameter[] sqlParameters)
        {
            SqlConnection conn = new SqlConnection(connStr);
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                SqlCommand cmd = new SqlCommand(str, conn);
                DataSet dt = new DataSet();
                da.SelectCommand = cmd;
                da.SelectCommand.Parameters.AddRange(sqlParameters);
                //da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
        }

        //返回一个sqlreader
        public static SqlDataReader ExecuteReader(string str, params SqlParameter[] sqlParameters)
        {
            //SqlDataReader要求，它读取数据的时候有，它独占它的SqlConnection对象，而且SqlConnection必须是Open状态
            SqlConnection conn = new SqlConnection(connStr);//不要释放连接，因为后面还需要连接打开状态
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = str;
            cmd.Parameters.AddRange(sqlParameters);
            //CommandBehavior.CloseConnection当SqlDataReader释放的时候，顺便把SqlConnection对象也释放掉
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
