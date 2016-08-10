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
    public class InstinctJobService : ServiceControl, ServiceSuspend
    {
        private readonly IScheduler scheduler;
        public InstinctJobService()
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
            scheduler = sf.GetScheduler();

            //use default scheduler factory
            //scheduler = StdSchedulerFactory.GetDefaultScheduler();
        }

        public bool Start(HostControl hostControl)
        {
            scheduler.Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            scheduler.Shutdown(false);
            return true;
        }

        public bool Continue(HostControl hostControl)
        {
            scheduler.ResumeAll();
            return true;
        }

        public bool Pause(HostControl hostControl)
        {
            scheduler.PauseAll();
            return true;
        }
    }
}
