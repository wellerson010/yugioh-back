using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Database
{
    public class SessionFactoryBuilder
    {
        public static ISessionFactory BuildSessionFactory (string connectionStringName, bool create = false, bool update = false)
        {
            //ConnectionString

            return Fluently.Configure()
            .Database(PostgreSQLConfiguration.Standard
            .ConnectionString(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
            //.Mappings(m => entityMappingTypes.ForEach(e => { m.FluentMappings.Add(e); }))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernate.Cfg.Mappings>())
            .CurrentSessionContext("web")
        //    .ExposeConfiguration(cfg => )
            .BuildSessionFactory();
        }
    }
}
