using Microsoft.AspNetCore.Components.Authorization;
using StockManagement.BlazorWebApp.Authentication;
using StockManagement.BlazorWebApp.Services.Interfaces;
using StockManagement.BlazorWebApp.Services;

namespace StockManagement.BlazorWebApp.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<CookieHandler>();

            RegisterHttpClient<AuthenticationStateProvider, CustomAuthenticationStateProvider>(services);
            services.AddScoped(x =>
                (ICustomAuthenticationStateProvider)x.GetRequiredService<AuthenticationStateProvider>());

            RegisterHttpClient<IUserWebService, UserWebService>(services);
            RegisterHttpClient<IBlobStorageWebService, AzureBlobStorageWebService>(services);
            RegisterHttpClient<ISystemResourceWebService, SystemResourceWebService>(services);
        }

        private static void RegisterHttpClient<TInterface, TImplementation>(IServiceCollection services)
            where TImplementation : class, TInterface
            where TInterface : class
        {
            services.AddHttpClient<TInterface, TImplementation>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7178/");
            }).AddHttpMessageHandler<CookieHandler>();
        }
    }
}
