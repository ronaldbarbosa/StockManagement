using Microsoft.EntityFrameworkCore;
using StockManagement.Application.Interfaces.Services;
using StockManagement.Application.Services;
using StockManagement.Core.Interfaces.Services;
using StockManagement.Data;
using StockManagement.Identity;
using StockManagement.Identity.Services;

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
                options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection"))
            );
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IIdentityService, IdentityService>();

            builder.Services.AddScoped<ICategoryService, CategoryService>();           
        }
    }
}
