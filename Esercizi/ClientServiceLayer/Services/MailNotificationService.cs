using ClientServiceLayer.Interfaces;
using ClientServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServiceLayer.Services
{
    public class MailNotificationService : INotificationService
    {
        private readonly IMailTemplate _mailTemplate;
        private readonly INotifier _mailClient;

        public MailNotificationService(IMailTemplate mailtemplate, INotifier emailclient)
        {
            _mailTemplate = mailtemplate;
            _mailClient = emailclient;
        }

        public void SendConfirmationOrder(OrderModel order)
        {
            string filledTemplate = _mailTemplate.GetMailTemplate(order);
            _mailClient.SendNotification(order.CustomerMail, "Order confirmation", filledTemplate);

        }
    }
}
