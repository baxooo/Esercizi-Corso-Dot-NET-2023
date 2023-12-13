using ClientServiceLayer.Models;

namespace ClientServiceLayer.Services
{
    public interface IMailTemplate
    {
        public string GetMailTemplate(OrderModel model);
    }
}