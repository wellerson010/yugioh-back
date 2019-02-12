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

        public T GetById(long id)
        {
            return NHibernateHelper.Session.Get<T>(id);
        }

        public void Save(T obj)
        {
            BeginTransaction();
            NHibernateHelper.Session.Save(obj);
            Commit();
        }

    }
}
