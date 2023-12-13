using ClientServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServiceLayer.Models
{
    public class MailTemplate :IMailTemplate
    {
        public string GetMailTemplate(OrderModel model)
        {
            return "Dear Customer, your order has been placed succesfully!" +
                $"\nThe order id is {model.Id}.";
        }
    }
}
