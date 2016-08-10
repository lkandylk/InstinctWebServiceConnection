using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using log4net;
using log4net.Config;

namespace CommonServiceLogHelper
{
    public class LogHelper
    {

        static LogHelper()
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);
        }

        /// <summary>
        /// Write Debug log message
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        #region static void WriteDebugLog(Type t, string msg)
        public static void WriteDebugLog(Type t, string msg)
         {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Debug(msg);
         }
        #endregion

        /// <summary>
        /// Write Info log message
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        #region static void WriteInfoLog(string msg)
        public static void WriteInfoLog(string msg)
        {
            ILog log = LogManager.GetLogger("INFO");
            log.Info(msg);
        }
        #endregion

        /// <summary>
        /// Write Warn log message
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        #region static void WriteWarnLog( string msg)
        public static void WriteWarnLog(string msg)
        {
            ILog log = LogManager.GetLogger("WARN");
            log.Warn(msg);
        }
        #endregion

        /// <summary>
        /// Write Error log message
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        #region static void WriteErrorLog(Type t, Exception ex)
        public static void WriteErrorLog(Type t, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error(msg);
        }
        #endregion

        //private static void InitLog4Net()
        //{
        //    var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
        //    XmlConfigurator.ConfigureAndWatch(logCfg);
        //}


    }
}
