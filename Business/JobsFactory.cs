using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Business
{
    public class JobsFactory : IJobsFactory
    {
        public JobCollection CreateJobs(ILog log)
        {
            JobCollection jobs = new JobCollection();
            
            jobs.Add(new DuneJob(log));

            return jobs;
        }
    }
}
