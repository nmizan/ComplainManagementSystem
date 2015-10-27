using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComplainRegistrationSystem.DAL;

namespace ComplainRegistrationSystem.BAL
{
    public class LoginManager
    {
        LoginGateway aLoginGateway=new LoginGateway();

        public string [] Login(string userId, string password)
        {
            return aLoginGateway.Login(userId, password);
        }

        public string GetPassword(string username)
        {
            return aLoginGateway.GetPassword(username);
        }

        public void UpdatePassword(string username,string value)
        {
             aLoginGateway.UpdatePassword(username,value);
        }
    }
}