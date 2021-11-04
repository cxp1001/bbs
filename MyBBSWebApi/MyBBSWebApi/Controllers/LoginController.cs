using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyBBSWebApi.Bll;
using MyBBSWebApi.Bll.Interfaces;
using MyBBSWebApi.Core;
using MyBBSWebApi.Dal;
using MyBBSWebApi.Models;
using System.Collections.Generic;
using System.Data;

namespace MyBBSWebApi.Controllers
{
    //[Route("api/[controller]/[action]")]
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public List<Users> GetAll()
        {
            IUserBll userBll = new UserBll();
            return userBll.GetAll(); 
        }



        [HttpGet("{userNo}/{password}")]
        public Users GetLoginRes(string userNo, string password)
        {
            UserBll userBll = new UserBll();
            Users user = userBll.CheckLogin(userNo, password);
            return user;
           
           
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