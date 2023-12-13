using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataLayer.Models
{
    public abstract class Order
    {
        public int Id { get; set; } 
        public Order()
        {
            
        }
    }
}
