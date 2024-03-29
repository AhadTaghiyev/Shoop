using System;
using Shoop.Core.Entities;
using Shoop.Data.Contexts;
using Shoop.Data.Repositories.Interfaces;

namespace Shoop.Data.Repositories.Implementations
{
	public class CategoryRepository:Repository<Category>,ICategoryRepository
	{
		public CategoryRepository(ShoopDbContext context) : base(context)
		{

		}
	}
}

