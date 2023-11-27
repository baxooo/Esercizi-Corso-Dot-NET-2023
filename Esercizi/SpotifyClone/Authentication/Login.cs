using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Authentication
{
    internal class Login
    {
        public static bool ValidateLogin(string username, string password)
        {
            if(username == "user"&& password == "user")
                return true;
            return false;
        }
    }
}
