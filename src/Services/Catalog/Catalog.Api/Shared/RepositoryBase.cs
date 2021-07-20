

using Catalog.Api.Data;
using Catalog.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Shared
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : EntityBase
    {
        private readonly CatalogContext _context = null;
        public RepositoryBase(CatalogContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().OrderBy(x => x.DateCreated).ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
