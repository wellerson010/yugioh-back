using Back.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Back.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try { 
                await next(context);
            }
            catch (Exception e)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                string stackTrace = e.StackTrace;

                if (stackTrace.Length > 1000)
                {
                    stackTrace = stackTrace.Substring(0, 1000);
                }

                ErrorViewModel response = new ErrorViewModel()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = (e.InnerException != null)?e.InnerException.Message:e.Message,
                    StackTrace = stackTrace
                };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}
