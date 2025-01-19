using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StockManagement.BlazorWebApp;
using StockManagement.BlazorWebApp.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.RegisterServices();

builder.Services.AddAuthorizationCore();

builder.Services.AddLocalization();
var host = builder.Build();
await host.SetDefaultCulture();

await builder.Build().RunAsync();