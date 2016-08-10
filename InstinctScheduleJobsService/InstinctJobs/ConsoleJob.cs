using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using System.Diagnostics;
using System.IO;

namespace InstinctScheduleJobsService.InstinctJobs
{
    public class ConsoleJob : IJob
    {
        /// <summary> 
        /// Empty constructor for job initialization
        /// <para>
        /// Quartz requires a public empty constructor so that the scheduler can instantiate the class whenever it needs.
        /// </para>
        /// </summary>
        public ConsoleJob()
        {
        }

        public virtual void Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string strFilePath = dataMap.GetString("filePath");

            this.RunBat(strFilePath);

            //var jd = new JavaScriptSerializer().Deserialize<ConsoleJobData>(content);
            //Process p = new Process();
            //p.StartInfo.UseShellExecute = true;
            //p.StartInfo.FileName = jd.Path;
            //p.StartInfo.Arguments = jd.Parameters;   //空格分割
            //p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            //p.Start();



            //CommonServiceLogHelper.LogHelper.WriteInfoLog("Hello Instinct!" + DateTime.Now);
        }

        private void RunBat(string batPath)
        {
            Process pro = new Process();

            FileInfo file = new FileInfo(batPath);
            pro.StartInfo.WorkingDirectory = file.Directory.FullName;
            pro.StartInfo.FileName = batPath;
            //pro.StartInfo.CreateNoWindow = false;
            //pro.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            pro.Start();
            pro.WaitForExit();
        }
    }
}
