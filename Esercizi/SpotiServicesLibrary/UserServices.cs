using SpotiBackEnd.DbContext;
using SpotiBackEnd.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServicesLibrary
{
    public class UserServices
    {
        private static SpotifyDbContext _context;
        private static UserServices _instance;
        private static readonly object _lockObject = new object();
        private readonly string _path = @"D:\db\";

        public static UserServices Instance 
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                            _instance = new UserServices();
                    }
                }
                return _instance;
            }
        }
        private UserServices()
        {
            _context = new SpotifyDbContext(_path);
        }

        public TimeSpan GetUserListenTime(int id)
        {
            if (_context.UserListeners.Where(u => u.Id == id) == null ||
                _context.UserListeners.Where(u => u.Id == id).Count() == 0)
                throw new ArgumentException($"user does not exist");

            var listenTime = _context.UserListeners.Where(u => u.Id == id).Select(u => u.RemainingTime);
            return TimeSpan.FromSeconds(listenTime.First());
        }
    }
}
