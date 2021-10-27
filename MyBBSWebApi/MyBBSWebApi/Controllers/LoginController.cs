using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
            DataRow dr = null;
            using (SqlConnection conn = new SqlConnection("server=162.14.77.192;database=MYBBSDB;Uid=sa;Pwd=Sunrisep1001"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from Users", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable res = ds.Tables[0];
                dr = res.Rows[0];
            }
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

        [HttpPost]
        public string Insert()
        {
            return "啊啊大大啊";
        }

        [HttpPut]
        public string Update()
        {
            return "啊啊大大啊";
        }

        [HttpDelete]
        public string Remove()
        {
            return "啊啊大大啊";
        }


    }
}
