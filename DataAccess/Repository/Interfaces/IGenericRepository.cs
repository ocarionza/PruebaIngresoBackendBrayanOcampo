using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<T> Insert(T model);
        Task<List<T>> InsertList(List<T> model);
        Task<T> Update(T model);
        Task<bool> Delete(T model);
        Task<IQueryable<T>> GetAll();
    }
}
