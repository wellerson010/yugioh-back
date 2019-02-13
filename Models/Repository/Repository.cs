using Back.Database;
using Back.Models.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models.Repository
{
    public class Repository<T> where T:BaseModel
    {
        private ITransaction transaction;


        private void CloseTransaction()
        {
            transaction.Dispose();
            transaction = null;
        }

        private void BeginTransaction()
        {
            transaction = NHibernateHelper.Session.BeginTransaction();
        }

        private void Commit()
        {
            try
            {
                // commit transaction if there is one active
                if (transaction != null && transaction.IsActive)
                {
                    transaction.Commit();
                }
            }
            catch
            {
                // rollback if there was an exception
                if (transaction != null && transaction.IsActive)
                {
                    transaction.Rollback();
                }

                throw;
            }
            finally
            {
                CloseTransaction();
            }
        }

        public Task<T> GetById(long id)
        {
            return NHibernateHelper.Session.GetAsync<T>(id);
        }

        public async Task Save(T obj)
        {
            BeginTransaction();
            await NHibernateHelper.Session.SaveAsync(obj);
            Commit();
        }

        public async Task DeleteById(long id)
        {
            BeginTransaction();
            T obj = await GetById(id);
            await NHibernateHelper.Session.DeleteAsync(obj);
            Commit();
        }
    }
}
