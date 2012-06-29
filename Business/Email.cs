using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class Email : IEmail
    {
        public string EmailAddressTo
        {
            get { return emailAddressTo; }
        }
        private string emailAddressTo;

        public string EmailAddressFrom
        {
            get { return emailAddressFrom; }
        }
        private string emailAddressFrom;

        public string Subject
        {
            get { return subject; }
        }
        private string subject;

        public string Body
        {
            get { return body; }
        }
        private string body;

        public Email(string emailTo, string emailFrom, string subject, string body)
        {
            this.emailAddressTo = emailTo;
            this.emailAddressFrom = emailFrom;
            this.subject = subject;
            this.body = body;
        }
    }
}
