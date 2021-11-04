using MyBBSWebApi.Bll.Interfaces;
using MyBBSWebApi.Dal;
using MyBBSWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBBSWebApi.Bll 
{
    public class UserBll:IUserBll
    {
        UserDal userDal = new UserDal();

        public List<Users> GetAll()
        {
            return userDal.GetAll().FindAll(m => !m.IsDelete);
        }

        public Users CheckLogin(string userNo, string password)
        {
            List<Users> userlist = userDal.GetUserByUserNoAndPassword(userNo, password);
            if (userlist.Count <= 0)
            {
                return default;
            }
            else
            {
                Users user = userlist.Find(m => !m.IsDelete);
                return user;
            }

        }

    }
}
