using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class DuneDataAccess
    {
        public DuneDataAccess()
        {
        }

        public EmailCollection GetEmailsToSend()
        {
            EmailCollection emails = new EmailCollection();

            IEmail email = new Email("k_main_3@hotmail.com", "kevmain@gmail.com", "This is a test", "This is test body content generated on " + DateTime.Now.ToString());
            emails.Add(email);

            return emails;
        }
    }
}
