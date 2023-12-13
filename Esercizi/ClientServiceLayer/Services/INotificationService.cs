using ClientServiceLayer.Models;

namespace ClientServiceLayer.Services
{
    public interface INotificationService
    {
        public void SendConfirmationOrder(OrderModel order);
    }
}