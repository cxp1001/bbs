using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyBBSWebApi.BLL;
using MyBBSWebApi.BLL.Interfaces;
using MyBBSWebApi.Model;
using MyBBSWebApi.Models;

namespace MyBBSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostlistController : ControllerBase
    {
        private readonly IPostsBLL _postsBLL;
        public PostlistController(IUserBll userBll, IPostsBLL postsBLL)
        {
            this._postsBLL = postsBLL;
            UserBll = userBll;
        }

        public IUserBll UserBll { get; }

        [HttpGet("{token}")]
        public List<Posts> GetPosts(string token)
        {
            Users user = UserBll.GetUsersByToken(token);
            //获取Posts
            List<Posts> list = _postsBLL.ListAll().ToList();
            return list;
        }
    }
}