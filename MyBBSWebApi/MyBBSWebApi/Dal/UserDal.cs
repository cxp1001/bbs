using Microsoft.Data.SqlClient;
using MyBBSWebApi.Core;
using MyBBSWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyBBSWebApi.Dal
{
    public class UserDal
    {
        public List<Users> GetAll()
        {
            DataTable dataTable = SqlHelper.ExecuteTable("SELECT * FROM Users");


            return ToModelList(dataTable);
        }


        public List<Users> GetUserByUserNoAndPassword(string userNo, string password)
        {

            
            DataTable dataTable = SqlHelper.ExecuteTable("SELECT * FROM Users WHERE UserNo = @UserNo AND Password = @Password", new SqlParameter("@UserNo", userNo), new SqlParameter("@Password", password));


            return ToModelList(dataTable);


        }


        public Users GetUserById(int id)
        {
            DataRow dr = null;
         
            DataTable dataTable = SqlHelper.ExecuteTable("SELECT * FROM Users WHERE Id = @Id", new SqlParameter("@Id", id));
            if (dataTable.Rows.Count > 0)
            {
                dr = dataTable.Rows[0];
                Users user = ToModel(dr);
                return user;
            }
            else
            {
                return default;
            }
           


        }


        public int AddUser(string UserNo, string UserName, int Userlevel, string Password)
        {



            return SqlHelper.ExecuteNonQuery("INSERT INTO Users(UserNo,Password,UserName,Userlevel) VALUES(@UserNo,@Password,@UserName,@Userlevel)", new SqlParameter("@UserNo", UserNo), new SqlParameter("@Password", Password), new SqlParameter("@UserName", UserName), new SqlParameter("@Userlevel", Userlevel));


        }


        public int UpdateUser(int id, string userNo, string userName, string password, int? userLevel)
        {

            DataRow dr = null;
            DataTable dataTable = SqlHelper.ExecuteTable("SELECT * FROM Users WHERE Id = @Id", new SqlParameter("@Id", id));
            int effctedRow = 0;
            if (dataTable.Rows.Count != 0)
            {
                dr = dataTable.Rows[0];
                Users user = new Users();
                user.Id = (int)dr["Id"];
                user.Password = password ?? dr["Password"].ToString();
                user.UserLevel = userLevel ?? (int)dr["Userlevel"];
                user.UserName = userName ?? dr["UserName"].ToString();
                user.UserNo = userNo ?? dr["UserNo"].ToString();

                effctedRow = SqlHelper.ExecuteNonQuery("UPDATE Users Set UserNo = @UserNo,UserName = @UserName,UserLevel = @UserLEvel,Password = @Password WHERE Id = @Id",
                new SqlParameter("@UserNo", user.UserNo),
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@UserLevel", user.UserLevel),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Id", user.Id));
            }

            return effctedRow;
        }

        public int RemoveUser(int id)
        {
            return SqlHelper.ExecuteNonQuery("DELETE FROM Users WHERE ID = @Id", new SqlParameter("@Id", id));


        }


        private List<Users> ToModelList(DataTable dataTable)
        {
            List<Users> userList = new List<Users>();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dr = dataTable.Rows[i];

                Users user = ToModel(dr);
                userList.Add(user);
            }

            return userList;
        }



        private Users ToModel(DataRow dr)
        {
            Users user = new Users();
            user.Id = (int)dr["Id"];
            user.Password = dr["Password"].ToString();
            user.UserLevel = (int)dr["Userlevel"];
            user.UserName = dr["UserName"].ToString();
            user.UserNo = dr["UserNo"].ToString();
            user.IsDelete = (bool)dr["IsDelete"];
            return user;
        }


    }

}
