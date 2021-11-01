using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyBBSWebApi.Core;
using MyBBSWebApi.Dal;
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
            UserDal userDal = new UserDal();
            bool result = userDal.GetUserByUserNoAndPassword(userNo,password);
                if (result)
                {
                    return "success!";
                }
                else
                {
                    return "false";
                }
           
           
        }

        [HttpPost]
        public string Insert(string UserNo, string UserName, int Userlevel, string Password)
        {
            UserDal userDal = new UserDal();
            int effectedRows = userDal.AddUser(UserNo, UserName, Userlevel, Password);

            if (effectedRows > 0)
            {
                return "success!";
            }
            else
            {
                return "false!";
            }
        }

        [HttpPut]
        public string Update(int id,string userNo,string userName,string password,int? userLevel)
        {

            UserDal userDal = new UserDal();
            int effectedRows = userDal.UpdateUser(id, userNo, userName, password, userLevel);
            if (effectedRows>0)
            {
                return "success!";
            }
            else
            {
                return "false!";
            }
        }

        [HttpDelete]
        public string Remove(int id)
        {
            UserDal userDal = new UserDal();
            int effectedRows = userDal.RemoveUser(id);
            if (effectedRows > 0)
            {
                return "success!";
            }
            else
            {
                return "false!";
            }
        }
    }
}