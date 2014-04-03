using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace SearchModuleAPI.Common
{
    public class Log4NetProvider
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //public Log4NetProvider() { }

        private static Log4NetProvider instance = null;
        private Log4NetProvider() { }

        public static Log4NetProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Log4NetProvider();
                }
                return instance;
            }
        }

        /// <summary>
        /// use only to write a log verbose
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        private void WriteLogVerbose(Exception ex, String message)
        {
            log.Debug("Verbose -- " + message, ex);
        }
        private void WriteLogVerbose(String msg)
        {
            log.Debug("Verbose -- " + msg);
        }

        public void WriteLog(Exception ex, String message)
        {
            if (ex != null)
            {
                log.Error(String.Format("Error {0} {1} {2}", ex.Message, ex.StackTrace, ex.Source), ex);
            }
            else
            {
                if (!String.IsNullOrEmpty(message))
                {
                    if (log.IsDebugEnabled)
                    {
                        log.Debug("Debug error logging " + message, ex);
                    }
                }
            }
        }
    }
}