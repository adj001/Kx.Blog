using log4net;
using log4net.Config;
using log4net.Core;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace kx.Blog.ToolKits.Helper
{
   public static class LoggerHelper
    {
        private static readonly ILoggerRepository repository = LoggerManager.CreateRepository("NETCoreRepository");
        private static readonly ILog log = LogManager.GetLogger(repository.Name, "NETCorelog4net");

        static LoggerHelper()
        {
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message"></param>
        public static void WriteToFile(string message)
        {
            log.Info(message);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void WriteToFile(string message,Exception ex)
        {
            if(string.IsNullOrEmpty(message))
            {
                message = ex.Message;
            }
            log.Error(message, ex);
        }
    }
}
