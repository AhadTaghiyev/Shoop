using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shoop.Core.Entities;

namespace Shoop.Data.Contexts
{
	public class ShoopDbContext:IdentityDbContext<AppUser>
	{
		public ShoopDbContext(DbContextOptions<ShoopDbContext> options):base(options)
		{

		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
    }
}

