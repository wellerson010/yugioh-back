﻿using Back.Database;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models.Repository
{
    public abstract class Repository<T> where T:class
    {
        public IAsyncDocumentSession Session
        {
            get
            {
                return RavenInstance.Session;
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
    }
}
