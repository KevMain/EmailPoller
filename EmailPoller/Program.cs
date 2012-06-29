using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business;
using log4net;
using log4net.Config;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace EmailPoller
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        
        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static void Main(string[] args)
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("App.Config"));

            log.Info("Application Starting");

            JobsEngine engine = new JobsEngine(new JobsFactory(), log);
            engine.ExecuteJobs();

            log.Info("Application Ending");
        }
    }
}
