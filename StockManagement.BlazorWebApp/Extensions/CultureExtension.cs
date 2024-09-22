using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;

namespace StockManagement.BlazorWebApp.Extensions
{
    public static class CultureExtension
    {
        public async static Task SetDefaultCulture(this WebAssemblyHost host)
        {
            var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
            var result = await jsInterop.InvokeAsync<string>("applicationCulture.get");

            CultureInfo culture;

            if (result == null) culture = new CultureInfo("pt-br");
            else culture = new CultureInfo(result);
            
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}