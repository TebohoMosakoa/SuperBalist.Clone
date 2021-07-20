using Catalog.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Api.Shared
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
