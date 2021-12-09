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
        List<Users> GetAll();
        Users CheckLogin(string userNo, string password);
        Users GetUsersByToken(string token);
        string AddUser(Users user);

        string RemoveUser(int id);
        string UpdateUser(int id, string userNo, string userName, string password, int? userLevel, Guid? token, Guid? autoLoginTag, DateTime? AutoLoginLimitTime);
        string UpdateUserOfUI(Users user);


    }
}
