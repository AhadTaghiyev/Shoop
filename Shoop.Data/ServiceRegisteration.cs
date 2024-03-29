using System;
using Shoop.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shoop.Data.Repositories.Interfaces;
using Shoop.Data.Repositories.Implementations;

namespace Shoop.Data
{
	public static class ServiceRegisteration
	{
		public static void AddDataLayerServices(this WebApplicationBuilder builder)
		{
            builder.Services.AddDbContext<ShoopDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });


            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
	}
}

