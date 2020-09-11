using Model.Models;
using Raven.Client.Documents;
using Raven.Client.Documents.Operations;
using Raven.Client.Documents.Session;
using Raven.Client.Exceptions.Database;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;
using System;
using System.Threading.Tasks;

namespace Model.Services
{
    public class RavenService
    {
        public static IDocumentStore Store { get; set; }

        private static IAsyncDocumentSession _Session { get; set; }

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
                    AsyncDocumentIdGenerator = (db, entity) =>
                    {
                        return Task.Run(() => Guid.NewGuid().ToString());
                    },
                    FindCollectionName = type =>
                    {
                        if (typeof(Magic).IsAssignableFrom(type) || typeof(Monster).IsAssignableFrom(type))
                        {
                            return "Card";
                        }

                        return type.Name;
                    }
                },

            }.Initialize();
            CreateDatabase(Store, database);
        }

        public static void CreateDatabase(IDocumentStore store, string database = null)
        {
            database = database ?? store.Database;

            try
            {
                store.Maintenance.ForDatabase(database).Send(new GetStatisticsOperation());
            }
            catch (DatabaseDoesNotExistException)
            {
                store.Maintenance.Server.Send(new CreateDatabaseOperation(new DatabaseRecord(database)));
            }
        }
    }
}
