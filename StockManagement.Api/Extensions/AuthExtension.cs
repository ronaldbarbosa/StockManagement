using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StockManagement.Api.Extensions;
using StockManagement.Identity;
using StockManagement.Identity.Entities;
using System.Text;

namespace StockManagement.Api.Extensions
{
    public static class AuthExtension
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            
            services.AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<IdentityDBContext>()
                .AddDefaultTokenProviders()
                .AddApiEndpoints();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
            });
        }

        public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection(nameof(JwtOptions));
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("JwtOptions:SecurityKey").Value!));

            services.Configure<JwtOptions>(options =>
            {
                options.Issuer = jwtOptions[nameof(JwtOptions.Issuer)]!;
                options.Audience = jwtOptions[nameof(JwtOptions.Audience)]!;
                options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
                options.AccessTokenExpiration = int.Parse(jwtOptions[nameof(JwtOptions.AccessTokenExpiration)] ?? "0");
                options.RefreshTokenExpiration = int.Parse(jwtOptions[nameof(JwtOptions.RefreshTokenExpiration)] ?? "0");
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = configuration.GetSection("JwtOptions:Issuer").Value,

                ValidateAudience = true,
                ValidAudience = configuration.GetSection("JwtOptions:Audience").Value,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication().AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            }).AddCookie("Identity.Bearer");

            services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
        }
    }
}
