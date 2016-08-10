using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace InstinctScheduleJobsService.InstinctJobs
{
    public class HelloInstinctJob : IJob
    {
        /// <summary> 
        /// Empty constructor for job initialization
        /// <para>
        /// Quartz requires a public empty constructor so that the scheduler can instantiate the class whenever it needs.
        /// </para>
        /// </summary>
        public HelloInstinctJob()
        {
        }

        public virtual void Execute(IJobExecutionContext context)
        {
            JobKey jobKey = context.JobDetail.Key;
            Console.WriteLine("Hello Instinct!" + DateTime.Now);
            CommonServiceLogHelper.LogHelper.WriteInfoLog("Hello Instinct!" + DateTime.Now);
        }
    }
}
