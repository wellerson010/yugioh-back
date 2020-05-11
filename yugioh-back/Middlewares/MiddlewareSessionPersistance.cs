using Microsoft.AspNetCore.Http;
using Model.Services;
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
            await EndInvoke(context);
        }

        private void BeginInvoke(HttpContext context)
        {
            RavenService.Session = RavenService.Store.OpenAsyncSession();
        }

        private async Task EndInvoke(HttpContext context)
        {
            if (RavenService.Session != null)
            {
                await RavenService.Session.SaveChangesAsync();
                RavenService.Session.Dispose();
            }
        }
    }
}
