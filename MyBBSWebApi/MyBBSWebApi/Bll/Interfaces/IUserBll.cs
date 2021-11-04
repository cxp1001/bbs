using MyBBSWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBBSWebApi.Bll.Interfaces
{
    interface IUserBll
    {
        public List<Users> GetAll();

        public Users CheckLogin(string userNo, string password);
    }
}
