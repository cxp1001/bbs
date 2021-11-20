using MyBBSWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBBSWebApi.BLL
{
    public interface IUserBll
    {
        public List<Users> GetAll();
        public Users CheckLogin(string userNo, string password);
        public Users GetUsersByToken(string token);
        string AddUser(string UserNo, string UserName, int Userlevel, string Password);

        string RemoveUser(int id);
        string UpdateUser(int id, string userNo, string userName, string password, int? userLevel, Guid? token,Guid? autoLoginTag);
    }
}
