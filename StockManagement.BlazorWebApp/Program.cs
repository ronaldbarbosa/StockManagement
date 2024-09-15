using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StockManagement.BlazorWebApp;
using Microsoft.AspNetCore.Components.Authorization;
using StockManagement.BlazorWebApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CookieHandler>();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped(x =>
    (CustomAuthStateProvider)x.GetRequiredService<AuthenticationStateProvider>());
builder.Services.AddAuthorizationCore();


builder.Services
    .AddHttpClient("client", opt => { opt.BaseAddress = new Uri("https://localhost:7178/"); })
    .AddHttpMessageHandler<CookieHandler>();

builder.Services.AddTransient<AuthWebService>();

await builder.Build().RunAsync();