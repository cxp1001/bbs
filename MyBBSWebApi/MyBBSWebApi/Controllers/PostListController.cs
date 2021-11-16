using Microsoft.AspNetCore.Mvc;

namespace MyBBSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostListController : ControllerBase
    {
        public IUserBll UserBll { get; }

        public PostListController(IUserBll userBll)
        {
            UserBll = userBll;
        }

        [HttpGet("{token}")]
        public List<Posts> GetPosts(string token)
    {

        Users user = UserBll.GetUserByToken(token);
        //获取Posts
        


    }
}



}