using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Business
{
    public abstract class JobBase : IJob
    {
        /// <summary>
        /// A unique identifer for the job
        /// </summary>
        public Guid JobId
        {
            get { return jobId; }
        }
        private Guid jobId;

        /// <summary>
        /// 
        /// </summary>
        public string JobName
        {
            get { return jobName; }
        }
        private string jobName;

        protected ILog Log;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobBase"/> class
        /// </summary>
        /// <param name="log"></param>
        /// <param name="jobName">The name of this job</param>
        public JobBase(ILog log, string jobName)
        {
            if (jobName == null)
                throw new ArgumentNullException("jobName");

            this.jobId = Guid.NewGuid();
            this.jobName = jobName;
            this.Log = log;
        }

        /// <summary>
        /// Abstract execute method
        /// </summary>
        public abstract void Execute();
    }
}
