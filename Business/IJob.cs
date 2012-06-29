using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    /// <summary>
    /// Interface that all scheduled jobs must implement
    /// </summary>
    public interface IJob
    {
        /// <summary>
        /// Unique ID of the job
        /// </summary>
        Guid JobId { get; }

        /// <summary>
        /// The name of the job to execute
        /// </summary>
        string JobName { get; }

        /// <summary>
        /// This is the main function which does all the processing
        /// </summary>
        void Execute();
    }
}
