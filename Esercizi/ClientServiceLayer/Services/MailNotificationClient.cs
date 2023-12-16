using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using ClientServiceLayer.Interfaces;
using ClientServiceLayer.Models;
using Microsoft.Extensions.Options;
using ClientDataLayer.Models;

namespace ClientServiceLayer.Services
{
    public class MailNotificationClient : INotifier
    {
        readonly MailConf _mailConf;
        public MailNotificationClient(IOptions<MailConf> mailConf)
        {
            _mailConf = mailConf.Value;
        }

        public void SendNotification(string toAddress, string subject, string body)
        {
            var FromAddress = new MailAddress(_mailConf.Username, "CORSONET 2023");
            var ToAddress = new MailAddress(toAddress);

            var smtp = new SmtpClient
            {
                Host = "smtp.ethereal.email",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_mailConf.Username,_mailConf.Password)
            };

            using (var message = new MailMessage(FromAddress, ToAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
