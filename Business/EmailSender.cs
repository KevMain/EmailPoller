using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Business
{
    public class EmailSender
    {
        public EmailSender()
        {
        }

        public void Send(IEmail email)
        {
            SmtpClient client = new SmtpClient();  //takes settings from config

            MailAddress from = new MailAddress(email.EmailAddressFrom);
            MailAddress to = new MailAddress(email.EmailAddressTo);
            MailMessage message = new MailMessage(from, to);
            message.IsBodyHtml = true;
            message.Subject = email.Subject;
            message.Body = email.Body;

            client.Send(message);
        }
    }
}
