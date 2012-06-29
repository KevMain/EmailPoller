using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business;
using log4net;

namespace EmailPoller
{
    /// <summary>
    /// A Jobs Engine for exectuing jobs
    /// </summary>
    public class JobsEngine
    {
        /// <summary>
        /// Internal reference to the jobs factory to use
        /// </summary>
        private IJobsFactory jobsFactory;

        /// <summary>
        /// 
        /// </summary>
        private ILog Log;

        /// <summary>
        /// Default constructor for the jobs engine
        /// Takes a reference to the factory to use to build the jobs
        /// </summary>
        /// <param name="jobsFactory"></param>
        /// <param name="log"></param>
        public JobsEngine(IJobsFactory jobsFactory, ILog log)
        {
            if (jobsFactory == null)
                throw new ArgumentNullException("jobsFactory");

            this.jobsFactory = jobsFactory;
            this.Log = log;
        }

        /// <summary>
        /// Main method which executes all the jobs
        /// </summary>
        public void ExecuteJobs()
        {
            JobCollection jobs = jobsFactory.CreateJobs(Log);

            foreach (IJob job in jobs)
            {
                Log.Info("Starting Job: " + job.JobName);
                job.Execute();
                Log.Info("Ending Job: " + job.JobName);
            }
        }
    }
}
