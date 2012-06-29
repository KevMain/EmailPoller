using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Business
{
    /// <summary>
    /// Main interface for the factory pattern which creates jobs to be executed
    /// </summary>
    public interface IJobsFactory
    {
        /// <summary>
        /// Create the jobs for this instance
        /// </summary>
        /// <returns></returns>
        JobCollection CreateJobs(ILog log);
    }
}
