using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Web2_Backend.Service
{
    public class EmailService
    {
        public void SendMessage(string to, string subject, string message) 
        {
            SmtpClient client = GetClient();

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("", "");
            mail.To.Add(new MailAddress(to));
            mail.Body = message;
            mail.Subject = subject;

            Task.Run(() =>
            {
                client.SendMailAsync(mail);
            });
        }


        private SmtpClient GetClient() 
        {
            SmtpClient smtpClient = new SmtpClient("", 0);

            smtpClient.Credentials = new System.Net.NetworkCredential("", "");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            return smtpClient;
        }
    }
}
