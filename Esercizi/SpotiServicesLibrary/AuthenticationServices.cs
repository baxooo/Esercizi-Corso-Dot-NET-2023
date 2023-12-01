using SpotiBackEnd.DbContext;
using SpotiBackEnd.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServicesLibrary
{
    public class AuthenticationServices
    {
        //finto Log in
        static AuthenticationServices _instance;
        static SpotifyDbContext _context;
        private static readonly object _instanceLock = new object();
        private string _path = @"D:\db\";
        public static AuthenticationServices Instance
        {
            get
            {
                if (_instance == null)
                    lock (_instanceLock)
                        if (Instance == null)
                            _instance = new AuthenticationServices();
                    
                return Instance;
            }
        }

        private AuthenticationServices()
        {
            _context = new SpotifyDbContext(_path);
        }

        public UserListener Login(string UserName,string Password)// TODO - cambiare l'UserListener in un DTO più appropriato
        {
            //faccio finta di fare un log in al momento 
            if (UserName == "user"|| Password == "user")
                return _context.UserListeners.Where(u => u.Id == 1).FirstOrDefault();
            return null;
        }
    }
}
