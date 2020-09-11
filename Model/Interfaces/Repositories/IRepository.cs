using Model.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces.Repositories
{
    public interface IRepository<T> where T: IBaseModel, new()
    {
        Task Save(T entity);

        Task<T> GetById(string id);

        Task<List<T>> GetAll();
    }
}
