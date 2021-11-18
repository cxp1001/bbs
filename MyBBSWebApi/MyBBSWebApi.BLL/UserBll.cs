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
                user.Token = Guid.NewGuid();
                UpdateUser(user.Id, user.UserNo, user.UserName, user.Password, user.UserLevel, user.Token);
                return user;
            }

        }


        public string AddUser(string UserNo, string UserName, int Userlevel, string Password)
        {
            
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


        public string UpdateUser(int id, string userNo, string userName, string password, int? userLevel, Guid? token)
        {

            
            int effectedRows = userDal.UpdateUser(id, userNo, userName, password, userLevel, token);
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

        public Users GetUsersByToken(string token)
        {
            Users user = userDal.GetUserByToken(token);
            if (user == null)
            {
                throw new Exception("token错误");
            }
            
            return user;
        }
    }
}
