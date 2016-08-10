using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Calendar;

namespace InstinctScheduleJobsService
{
    class Program
    {
        static void Main(string[] args)
        {
            //InstinctScheduleJobsService.InstinctJobService.Run();
            //Run();
            serviceRun();
        }

        public static void Run()
        {
            NameValueCollection properties = new NameValueCollection();
            properties["quartz.scheduler.instanceName"] = "XmlConfiguredInstance";

            // set thread pool info
            properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            properties["quartz.threadPool.threadCount"] = "5";
            properties["quartz.threadPool.threadPriority"] = "Normal";

            // job initialization plugin handles our xml reading, without it defaults are used
            properties["quartz.plugin.xml.type"] = "Quartz.Plugin.Xml.XMLSchedulingDataProcessorPlugin, Quartz";
            properties["quartz.plugin.xml.fileNames"] = "~/quartz_jobs.xml";



            ISchedulerFactory sf = new StdSchedulerFactory(properties);
            //ISchedulerFactory sf = new StdSchedulerFactory();

            //sf.GetScheduler()
            IScheduler sched = sf.GetScheduler();

            // we need to add calendars manually, lets create a silly sample calendar
            //var dailyCalendar = new DailyCalendar("00:01", "23:59");
            //dailyCalendar.InvertTimeRange = true;
            //sched.AddCalendar("cal1", dailyCalendar, false, false);


            // Tell quartz to schedule the job using our trigger
            //scheduler.ScheduleJob(job, trigger);

            // some sleep to show what's happening
            //Thread.Sleep(TimeSpan.FromSeconds(60));
            sched.Start();
            IList<string> strJobGroup = sched.GetJobGroupNames();
            //sched.GetJobKeys()
            try
            {
                Thread.Sleep(30 * 100000);
            }
            catch (ThreadInterruptedException)
            {
            }
            sched.Shutdown(false);
        }

        public static void serviceRun()
        {
            HostFactory.Run(x =>
            {
                x.Service<InstinctJobService>();
                x.RunAsLocalSystem();

                x.SetDescription("Sample Topshelf Host");
                x.SetDisplayName("InstinctJobService");
                x.SetServiceName("InstinctJobService");
            });
        }
    }
}
