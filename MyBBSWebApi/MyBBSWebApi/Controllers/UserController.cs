using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyBBSWebApi.BLL;
using MyBBSWebApi.Models;

namespace MyBBSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserBll _userBll;
        public UserController(IUserBll userBll)
        {
            _userBll = userBll;
        }

        [HttpPost]
        public bool EditUser(UserEditViewModel edit)
        {
            try
            {
                 
            Users editUser = _userBll.GetAll().FirstOrDefault(m => m.Id == edit.Id);
            editUser.UserName = edit.UserName;
            if (edit.Password != null && edit.Password.Trim() != "")
            {
                editUser.Password = edit.Password;
                _userBll.UpdateUserOfUI(editUser);
                  return true;
            }
            else{
                return false;
            }
          
            }
            catch (System.Exception ex)
            {
                
                return false;
                throw;
            }
        }
    }
}