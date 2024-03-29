using Microsoft.EntityFrameworkCore;
using Shoop.Core.Entities;

namespace Shoop.Data.Contexts
{
	public class ShoopDbContext:DbContext
	{
		public ShoopDbContext(DbContextOptions<ShoopDbContext> options):base(options)
		{

		}

		public DbSet<Category> Categories { get; set; }
	}
}

