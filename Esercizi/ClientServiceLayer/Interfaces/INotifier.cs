using ClientServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServiceLayer.Interfaces
{
    public interface INotifier
    {
        public void SendNotification(string to, string subject, string message);
    }
}
