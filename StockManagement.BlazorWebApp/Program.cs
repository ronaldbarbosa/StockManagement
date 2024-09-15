using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StockManagement.BlazorWebApp;
using Microsoft.AspNetCore.Components.Authorization;
using StockManagement.BlazorWebApp.Services;
using StockManagement.BlazorWebApp.Authentication;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CookieHandler>();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped(x =>
    (ICustomAuthenticationStateProvider)x.GetRequiredService<AuthenticationStateProvider>());
builder.Services.AddAuthorizationCore();


builder.Services
    .AddHttpClient("client", opt => { opt.BaseAddress = new Uri("https://localhost:7178/"); })
    .AddHttpMessageHandler<CookieHandler>();

builder.Services.AddTransient<AuthWebService>();

await builder.Build().RunAsync();