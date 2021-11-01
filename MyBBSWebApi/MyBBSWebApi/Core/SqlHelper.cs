using Microsoft.Data.SqlClient;
using System.Data;

namespace MyBBSWebApi.Core
{
    public class SqlHelper
    {
        public static string ConnectionString
        {
            get;
            set;
        } = "server=162.14.77.192;database=MYBBSDB;Uid=sa;Pwd=Sunrisep1001";

        public static DataTable ExecuteTable(string cmdText, params SqlParameter[] sqlParameters)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddRange(sqlParameters);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }

        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] sqlParameters)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddRange(sqlParameters);
            return cmd.ExecuteNonQuery();
        }
    }
}