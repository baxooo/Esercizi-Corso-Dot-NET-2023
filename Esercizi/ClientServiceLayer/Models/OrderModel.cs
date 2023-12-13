using ClientDataLayer.Interfaces;
using ClientDataLayer.Models;
using ClientDataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServiceLayer.Models
{
    public class OrderModel : Order
    {
        public string ProductsId { get; set; }
        public string CustomerMail {  get; set; }
        public string CustomerPhone { get; set; }
        public double Ammount { get; set; }
    }
}
