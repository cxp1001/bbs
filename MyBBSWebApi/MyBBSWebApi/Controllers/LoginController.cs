using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyBBSWebApi.Core;
using MyBBSWebApi.Models;
using System.Data;

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
            if (dataTable.Rows.Count > 0)
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
        public string Insert(string UserNo, string UserName, int Userlevel, string Password)
        {
            SqlHelper sqlHelper = new SqlHelper();


            int yxdh = sqlHelper.ExecuteNonQuery("INSERT INTO Users(UserNo,Password,UserName,Userlevel) VALUES(@UserNo,@Password,@UserName,@Userlevel)", new SqlParameter("@UserNo", UserNo), new SqlParameter("@Password", Password), new SqlParameter("@UserName", UserName), new SqlParameter("@Userlevel", Userlevel));

            return yxdh.ToString();

            //using (SqlConnection conn = new SqlConnection("server=162.14.77.192;database=MYBBSDB;Uid=sa;Pwd=Sunrisep1001"))
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand($"INSERT INTO Users(UserNo,Password,UserName,Userlevel) VALUES('{UserNo}','{Password}','{UserName}','{Userlevel}')", conn);
            //    cmd.ExecuteNonQuery();
            //}
            //return "啊啊大大啊";
        }

        [HttpPut]
        public string Update(int id,string userNo,string userName,string password,int? userLevel)
        {
            SqlHelper sqlHelper = new SqlHelper();
            DataRow dr = null;
            DataTable dataTable = sqlHelper.ExecuteTable("SELECT * FROM Users WHERE Id = @Id",new SqlParameter("@Id",id));
            if (dataTable.Rows.Count!=0)
            {
                dr = dataTable.Rows[0];
                Users user = new Users();
                user.Id = (int)dr["Id"];
                user.Password = password??dr["Password"].ToString();
                user.UserLevel = userLevel??(int)dr["Userlevel"];
                user.UserName = userName??dr["UserName"].ToString();
                user.UserNo = userNo??dr["UserNo"].ToString();

                sqlHelper.ExecuteNonQuery("UPDATE Users Set UserNo = @UserNo,UserName = @UserName,UserLevel = @UserLEvel,Password = @Password WHERE Id = @Id",
                new SqlParameter("@UserNo", user.UserNo),
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@UserLevel", user.UserLevel),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Id", user.Id));

                

            }

            return "success!";






            //using (SqlConnection conn = new SqlConnection("server=162.14.77.192;database=MYBBSDB;Uid=sa;Pwd=Sunrisep1001"))
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand($"UPDATE Users SET Password = '666888' Where Id = '1" +
            //        $"'", conn);
            //    cmd.ExecuteNonQuery();
            //}

            //return "啊啊大大啊";
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