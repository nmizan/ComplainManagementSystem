using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComplainRegistrationSystem.Model
{
    public class UserAccount
    {
        public string UserId { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Contact { set; get; }
        public  string Email { set; get; }

    }
}