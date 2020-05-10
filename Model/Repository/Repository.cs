using Model.Services;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Repository
{
    public abstract class Repository<T> where T:class
    {
        public IAsyncDocumentSession Session
        {
            get
            {
                return RavenService.Session;
            }
        }

        public Task Save(T entity)
        {
            return Session.StoreAsync(entity);
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
        }

        public void DeleteById(string id)
        {
            Session.Delete(id);
        }

        public Task<T> GetById(string id)
        {
            return Session.LoadAsync<T>(id);
        }
    }
}
