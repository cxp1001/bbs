﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyBBSWebApi.BLL;
using MyBBSWebApi.DAL;
using MyBBSWebApi.DAL.Core;
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
        private readonly IUserBll _userBll;

        public LoginController(IUserBll userBll)
        {
            _userBll = userBll;
        }

        [HttpGet]
        public List<Users> GetAll()
        {
            
            return _userBll.GetAll(); 
        }



        [HttpGet("{userNo}/{password}")]
        public Users GetLoginRes(string userNo, string password)
        {
            
            Users user = _userBll.CheckLogin(userNo, password);
            return user;
           
           
        }

        [HttpPost]

        
        public string Insert(string UserNo, string UserName, int Userlevel, string Password)
        {
            return _userBll.AddUser(UserNo, UserName, Userlevel, Password);
        }

        [HttpPut]
        public string Update(int id,string userNo,string userName,string password,int? userLevel)
        {

            return _userBll.UpdateUser(id, userNo, userName, password, userLevel); 
        }

        [HttpDelete]
        public string Remove(int id)
        {
            return _userBll.RemoveUser(id);
        }
    }
}