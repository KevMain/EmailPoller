using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Business
{
    public class DuneJob : JobBase
    {
        private const string JOB_NAME = "Dune Daily Job Summary Emails";

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public DuneJob(ILog log)
            : base(log, JOB_NAME)
        {
        }

        /// <summary>
        /// Execute method for this job - do any work that needs doing here
        /// </summary>
        public override void Execute()
        {
            EmailSender sender = new EmailSender();

            EmailCollection emails = new DuneDataAccess().GetEmailsToSend();

            foreach(IEmail message in emails)
            {
                base.Log.Debug("Sending Email to email address: " + message.EmailAddressTo);
                sender.Send(message);
            }
        }
    }
}
