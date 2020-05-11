using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public interface IRepository<T> where T:class, new()
    {
        Task Save(T entity);
    }
}
