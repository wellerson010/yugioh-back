using Back.Models.Entities;
using Raven.Client.Documents;
using Raven.Client.Documents.Conventions;
using Raven.Client.Documents.Session;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Database
{
    public class RavenInstance
    {
        public static IDocumentStore Store { get; set; }

        private static IAsyncDocumentSession _Session {get;set;}

        public static IAsyncDocumentSession Session
        {
            get
            {
                return _Session;
            }
            set
            {
                if (_Session != null)
                {
                    _Session.Dispose();
                }

                _Session = value;
            }
        }

        public static void CreateStore(string[] urls, string database)
        {
            Store = new DocumentStore()
            {
                Urls = urls,
                Database = database,
                Conventions =
                {
                    FindCollectionName = type =>
                    {
                        if (typeof(Magic).IsAssignableFrom(type) || typeof(Monster).IsAssignableFrom(type))
                        {
                            return "Card";
                        }

                        return typeof(Magic).Name;
                    }
                }
            }.Initialize();

            Store.Maintenance.Server.Send(new CreateDatabaseOperation(new DatabaseRecord(database)));
        }
    }
}
