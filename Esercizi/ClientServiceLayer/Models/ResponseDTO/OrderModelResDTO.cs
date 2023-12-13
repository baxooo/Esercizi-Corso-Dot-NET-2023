using ClientDataLayer.Interfaces;
using ClientDataLayer.Models;
using ClientDataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServiceLayer.Models.ResponseDTO
{
    public class OrderModelResDTO : Order
    {
        public int ProductId { get; set; }
        public string CustomerMail { get; set; }
        public double Ammount { get; set; }
        public OrderModelResDTO()
        {

        }

        public OrderModelResDTO(OrderModel order)
        {
            Id = order.Id;
            int prodId = 0;
            int.TryParse(order.ProductsId, out prodId);
            ProductId = prodId;
            CustomerMail = order.CustomerMail;
            Ammount = order.Ammount;

        }
    }
}
