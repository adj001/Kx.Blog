using log4net;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kx.Blog.HttpApi.Hosting.Filters
{
    public class KxBlogExceptionFilter : IExceptionFilter
    {
        private readonly ILog _log;

        public KxBlogExceptionFilter()
        {
            _log = LogManager.GetLogger(typeof(KxBlogExceptionFilter));
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            _log.Error($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}
