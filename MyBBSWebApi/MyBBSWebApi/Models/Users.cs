using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBBSWebApi.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string UserNo { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int UserLevel { get; set; }



    }
}
