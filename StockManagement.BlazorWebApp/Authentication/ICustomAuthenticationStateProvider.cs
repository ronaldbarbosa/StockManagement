using Microsoft.AspNetCore.Components.Authorization;

namespace StockManagement.BlazorWebApp.Authentication
{
    public interface ICustomAuthenticationStateProvider
    {
        Task<bool> CheckAuthenticatedAsync();
        Task<AuthenticationState> GetAuthenticationStateAsync();
        void NotifyAuthenticationStateChanged();
    }
}
