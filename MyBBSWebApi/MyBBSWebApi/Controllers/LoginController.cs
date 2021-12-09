using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyBBSWebApi.BLL;
using MyBBSWebApi.Common;
using MyBBSWebApi.DAL;
using MyBBSWebApi.DAL.Core;
using MyBBSWebApi.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System;


namespace MyBBSWebApi.Controllers
{
    //[Route("api/[controller]/[action]")]
    [Route("[controller]")]
    //[ApiController]
    [EnableCors("any")]
    public class LoginController : ControllerBase
    {
        private readonly IUserBll _userBll;

        public LoginController(IUserBll userBll)
        {
            _userBll = userBll;
        }

        [HttpGet]
        // public List<Users> GetAll()
        // {
            
        //     return _userBll.GetAll(); 
        // }



        [HttpGet("{userNo}/{password}")]
        public Users GetLoginRes(string userNo, string password)
        {
            
            
            Users user = _userBll.CheckLogin(userNo, password);
            return user;
           
           
        }

        [HttpPost]
        public string Insert([FromBody]Users user)
        {
          
            return _userBll.AddUser(user);
        }

        [HttpPut]
        public string Update(int id,string userNo,string userName,string password,int? userLevel,Guid token,Guid? autoLoginTag,DateTime? AutoLoginTimeLimit)
        {

            return _userBll.UpdateUser(id, userNo, userName, password, userLevel,token,null,null); 
        }

        [HttpDelete]
        public string Remove(int id)
        {
            return _userBll.RemoveUser(id);
        }
    }
}