using System.Linq.Expressions;
using Shoop.Core.Entities;
using Shoop.Core.Entities.BaseEntities;

namespace Shoop.Data.Repositories.Interfaces
{
	public interface IRepository<T> where T:BaseEntity
	{
		public Task AddAsync(T data);
		public Task UpdateAsync(T data);
		public Task RemoveAsync(T data);
		public Task<T> GetAsync(Expression<Func<T, bool>> expression);
		public Task<IQueryable<T>> GetQuery(Expression<Func<T, bool>> expression, params string[] includes);
        public Task<int> SaveAsync();
        public int Save();
		public Task<bool> IsExsist(Expression<Func<T, bool>> expression);
    }
}

