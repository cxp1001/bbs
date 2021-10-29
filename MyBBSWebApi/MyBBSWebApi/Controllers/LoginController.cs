using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using MyBBSWebApi.Core;

namespace MyBBSWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public string Get(string userNo, string password)
        {
            SqlHelper sqlHelper = new SqlHelper();
            DataTable dataTable = sqlHelper.ExecuteTable("SELECT * FROM Users");
            if (dataTable.Rows.Count>0)
            {
                DataRow dr = dataTable.Rows[0];
                string userNum = dr["UserNo"].ToString();
                string passwd = dr["Password"].ToString();
                if (userNum == userNo && passwd == password)
                {
                    return "success!";
                }

                else
                {
                    return "false";
                }
            }
            else
            {
                return "表为空！";
            }
            




            




        }

        [HttpPost]
        public string Insert(string UserNo,string UserName,int Userlevel,string Password)
        {
            using (SqlConnection conn = new SqlConnection("server=162.14.77.192;database=MYBBSDB;Uid=sa;Pwd=Sunrisep1001"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO Users(UserNo,Password,UserName,Userlevel) VALUES('{UserNo}','{Password}','{UserName}','{Userlevel}')", conn);
                cmd.ExecuteNonQuery();
            }
                return "啊啊大大啊";
        }

        [HttpPut]
        public string Update(string UserNo, string UserName, int Userlevel, string Password)
        {
            using (SqlConnection conn = new SqlConnection("server=162.14.77.192;database=MYBBSDB;Uid=sa;Pwd=Sunrisep1001"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE Users SET Password = '666888' Where Id = '1" +
                    $"'", conn);
                cmd.ExecuteNonQuery();
            }


            return "啊啊大大啊";
        }

        [HttpDelete]
        public string Remove(int Id)
        {

            using (SqlConnection conn = new SqlConnection("server=162.14.77.192;database=MYBBSDB;Uid=sa;Pwd=Sunrisep1001"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM Users WHERE Id = {Id}", conn);
                cmd.ExecuteNonQuery();
            }
            return "啊啊大大啊";
        }


    }
}
