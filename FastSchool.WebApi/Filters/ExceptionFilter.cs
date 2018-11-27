using FastSchool.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastSchool.WebApi.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private ILogger<ExceptionFilter> Logger { get; set; }
        public ExceptionFilter(ILoggerFactory _logger)
        {
            Logger = _logger.CreateLogger<ExceptionFilter>();
        }
        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                var ex = context.Exception;
                Logger.LogError(new EventId(), ex, ex.Message); //写入日志
                context.Result = new ContentResult
                {
                    Content = "error",
                    StatusCode = StatusCodes.Status200OK,
                    ContentType = "text/html"
                };
            }
            context.ExceptionHandled = true; //异常已处理了
        }
    }
}