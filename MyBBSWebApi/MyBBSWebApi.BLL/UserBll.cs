using MyBBSWebApi.DAL;
using MyBBSWebApi.Models;
using System;
using System.Collections.Generic;

namespace MyBBSWebApi.BLL
{
    public class UserBll : IUserBll
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


        public string AddUser(string UserNo, string UserName, int Userlevel, string Password)
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


        public string UpdateUser(int id, string userNo, string userName, string password, int? userLevel)
        {

            UserDal userDal = new UserDal();
            int effectedRows = userDal.UpdateUser(id, userNo, userName, password, userLevel);
            if (effectedRows > 0)
            {
                return "success!";
            }
            else
            {
                return "false!";
            }
        }


        public string RemoveUser(int id)
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
