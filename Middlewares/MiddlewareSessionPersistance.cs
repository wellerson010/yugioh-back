using Back.Database;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Middlewares
{
    public class MiddlewareSessionPersistance
    {
        private readonly RequestDelegate next;

        public MiddlewareSessionPersistance(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            BeginInvoke(context);
            await next(context);
            EndInvoke(context);
        }

        private void BeginInvoke(HttpContext context)
        {
            RavenInstance.Session = RavenInstance.Store.OpenAsyncSession();
        }

        private void EndInvoke(HttpContext context)
        {
            if (RavenInstance.Session != null)
            {
                Task.Run(async () => await RavenInstance.Session.SaveChangesAsync());
                RavenInstance.Session.Dispose();
            }
        }
    }
}
