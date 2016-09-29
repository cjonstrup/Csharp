using System.Collections.Generic;
using Nancy.Authentication.Basic;
using Nancy.Security;

namespace WebServer
{
    public class User : IUserIdentity
    {
        public IEnumerable<string> Claims
        {
            get
            {
                return new[] { "Admin" };
            }
        }

        public string UserName
        {
            get
            {
                return "Carsten";
            }
        }
    }

    public class Validator : IUserValidator
    {
        public IUserIdentity Validate(string username, string password)
        {
            return new User();
        }
    }


}
