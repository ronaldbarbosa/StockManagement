﻿using Microsoft.EntityFrameworkCore;
using StockManagement.Application.Interfaces.Services;
using StockManagement.Data;
using StockManagement.Identity;
using StockManagement.Domain.Interfaces.Repositories;
using StockManagement.Data.Repositories;
using StockManagement.Domain.Interfaces.Services;
using StockManagement.Domain.Services;
using StockManagement.Application.Services;

namespace StockManagement.Api.Extensions
{
    public static class BuildExtension
    {
        public static void AddDataContexts(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<IdentityDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"))
            );
            builder.Services.AddDbContext<DataDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection"),
                b => b.MigrationsAssembly("StockManagement.Data"))
            );
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            // Repositories
            builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ISystemResourceRepository, SystemResourceRepository>();

            // Services
            builder.Services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ISystemResourceService, SystemResourceService>();

            // AppServices
            builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
            builder.Services.AddScoped<IBlobStorageAppService, AzureBlobStorageAppService>();
            builder.Services.AddScoped<ISystemResourceAppService, SystemResourceAppService>();
            
            //builder.Services.AddScoped<IIdentityAppService, IdentityService>();
        }
    }
}
