using MyBBSWebApi.Dal;
using MyBBSWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBBSWebApi.Bll 
{
    public class UserBll
    {
        UserDal userDal = new UserDal();

        public Users CheckLogin(string userNo, string password)
        {
            List<Users> userlist =  userDal.GetUserByUserNoAndPassword(userNo,password);
            if(userlist.Count<=0)
            {
                return default;
            }
            else
            {

            }
           
        }

    }
}
