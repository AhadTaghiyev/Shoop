using System;
using Shoop.Core.Entities;
using Shoop.Data.Contexts;
using Shoop.Data.Repositories.Interfaces;

namespace Shoop.Data.Repositories.Implementations
{
	public class ProductRepository:Repository<Product>,IProductRepository
	{
		public ProductRepository(ShoopDbContext context) : base(context)
		{

		}
	}
}

