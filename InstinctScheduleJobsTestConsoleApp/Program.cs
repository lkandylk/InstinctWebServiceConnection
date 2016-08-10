using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Topshelf;


namespace InstinctScheduleJobsTestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //InstinctScheduleJobsService.InstinctJobService.Run();
            serviceRun();
        }

        public static void serviceRun()
        {
            HostFactory.Run(x =>                                 
            {
                x.Service<TestWinService>();
                x.RunAsLocalSystem();                            

                x.SetDescription("Sample Topshelf Host");        
                x.SetDisplayName("TestWinServicec");                       
                x.SetServiceName("TestWinServicec");                       
            });
        }
    }
}
