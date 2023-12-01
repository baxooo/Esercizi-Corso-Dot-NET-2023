using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiBackEnd.Models.MediaModels;
using SpotiBackEnd.Models.UserModels;

namespace SpotiBackEnd
{
    public class Database
    {
        private static Database _instance;

        private static readonly object lockObject = new object();

        private List<UserListener> _users;

        public string FilePath { get; set; }
        private Database()
        {
            _users = new List<UserListener>();
        }

        public static Database Instance
        {
            get
            {
                if (_instance == null)
                    lock (lockObject)
                        if (_instance == null)
                            _instance = new Database();
                        
                return _instance;
            }
        }

    }
}
