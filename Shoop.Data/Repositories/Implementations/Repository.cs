using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shoop.Core.Entities.BaseEntities;
using Shoop.Data.Contexts;
using Shoop.Data.Repositories.Interfaces;

namespace Shoop.Data.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T:BaseEntity
    {
        readonly ShoopDbContext _context;
        public Repository(ShoopDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T data)
        {
            await _context.Set<T>().AddAsync(data);
        }

        public async Task<T> GetAsync(Expression<Func<T,bool>> expression)
        {
           return await _context.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        public async Task<IQueryable<T>> GetQuery(Expression<Func<T, bool>> expression,params string[] includes)
        {
            var query = _context.Set<T>().Where(expression);
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }

        public async Task<bool> IsExsist(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public async Task RemoveAsync(T data)
        {
            _context.Set<T>().Remove(data);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T data)
        {
            _context.Set<T>().Update(data);
        }
    }
}

