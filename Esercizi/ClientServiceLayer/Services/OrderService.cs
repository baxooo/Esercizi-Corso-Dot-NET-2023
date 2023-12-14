using ClientDataLayer.Interfaces;
using ClientDataLayer.Models;
using ClientDataLayer.Repositories;
using ClientServiceLayer.Interfaces;
using ClientServiceLayer.Models;
using ClientServiceLayer.Models.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientServiceLayer.Services
{
    public class OrderService
    {  
        private readonly IOrderRepository<OrderModel, OrderModelResDTO> _orderRepository;
        private readonly INotificationService _notifier;

        public  OrderService(IOrderRepository<OrderModel,OrderModelResDTO> rep ,INotificationService notifier) 
        {
            _orderRepository = rep;
            _notifier = notifier;
        }

        public List<OrderModelResDTO> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public bool SaveNewOrder(OrderModel orderModel)
        {
            if (orderModel == null )
                return false;
            _orderRepository.StoreOrder(orderModel);
            _notifier.SendConfirmationOrder(orderModel);
            return true;
        }
    }
}
