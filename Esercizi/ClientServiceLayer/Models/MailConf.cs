using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServiceLayer.Models
{
    public class MailConf
    {

        public string Host { get; set; }
        public int Port { get; set; }
        public string Security { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
