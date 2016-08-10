using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Topshelf;
using Quartz;
using Quartz.Impl;

namespace InstinctScheduleJobsTestConsoleApp
{
    public sealed class TestWinService : ServiceControl, ServiceSuspend
    {
        private readonly IScheduler scheduler;

        public TestWinService()
        {
            scheduler = StdSchedulerFactory.GetDefaultScheduler();
        }

        public bool Start(HostControl hostControl)
        {
            scheduler.Start();
            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<InstinctScheduleJobsService.InstinctJobs.HelloInstinctJob>()
                .WithIdentity("job1", "group1")
                .Build();

            // Trigger the job to run now, and then repeat every 10 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
                .Build();

            // Tell quartz to schedule the job using our trigger
            scheduler.ScheduleJob(job, trigger);

            // some sleep to show what's happening
            Thread.Sleep(TimeSpan.FromSeconds(60));
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
