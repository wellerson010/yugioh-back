using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Database
{
    public static class NHibernateHelper
    {
        public static ISession Session { get; set; }
    }
}
