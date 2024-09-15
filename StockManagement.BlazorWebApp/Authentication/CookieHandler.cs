
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace StockManagement.BlazorWebApp.Authentication
{
    public class CookieHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            request.Headers.Add("X-RequestedWith", ["XMLHttpRequest"]);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
