using System;
using Shoop.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shoop.Data.Repositories.Interfaces;
using Shoop.Data.Repositories.Implementations;
using Shoop.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

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
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ShoopDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = "https://localhost:7256",
                    ValidIssuer = "https://localhost:7256",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ec597d4a-da8d-4fe4-814e-1a4db6e1a59b")),
                    LifetimeValidator = (_, expires, _, _) => expires != null ? expires > DateTime.UtcNow : false,

                    NameClaimType = ClaimTypes.Name

                };
            });
        }
	}
}

