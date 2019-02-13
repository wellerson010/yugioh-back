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
            NHibernateHelper.Session = SessionFactoryBuilder.session.OpenSession();
        }

        private void EndInvoke(HttpContext context)
        {
            if (NHibernateHelper.Session != null)
            {
                NHibernateHelper.Session.Close();
                NHibernateHelper.Session.Dispose();
                NHibernateHelper.Session = null;
            }
        }
    }
}
