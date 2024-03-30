using System;
using Shoop.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shoop.Data.Repositories.Interfaces;
using Shoop.Data.Repositories.Implementations;
using Shoop.Service.Services.Interfaces;
using Shoop.Service.Services.Implementations;

namespace Shoop.Service
{
	public static class ServiceRegisteration
	{
		public static void AddServiceLayerServices(this WebApplicationBuilder builder)
		{
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<IProductService, ProductService>();
        }
	}
}

