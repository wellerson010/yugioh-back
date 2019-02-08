using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
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
        public static ISessionFactory BuildSessionFactory ()
        {
            //ConnectionString
            var builder = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var connectionstring = configuration["ConnectionStrings:local"];

            return Fluently.Configure()
            .Database(PostgreSQLConfiguration.Standard
            .ConnectionString(connectionstring))
            //.Mappings(m => entityMappingTypes.ForEach(e => { m.FluentMappings.Add(e); }))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Back.Models.Map.MonsterMap>())
            .CurrentSessionContext("web")
        //    .ExposeConfiguration(cfg => )
            .BuildSessionFactory();
        }
    }
}
