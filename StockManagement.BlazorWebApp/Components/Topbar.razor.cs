using Microsoft.AspNetCore.Components;
using StockManagement.Application.DTOs;
using StockManagement.BlazorWebApp.Authentication;
using System.Security.Claims;

namespace StockManagement.BlazorWebApp.Components
{
    public partial class Topbar : ComponentBase
    {
        #region properties
        public UserDTO User { get; set; } = new();
        #endregion

        #region Services
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ICustomAuthenticationStateProvider AuthStateProvider { get; set; } = null!;
        #endregion

        #region overrides
        protected override async Task OnInitializedAsync()
        {
            if (await AuthStateProvider.CheckAuthenticatedAsync())
            {
                var result = await AuthStateProvider.GetAuthenticationStateAsync();
                if (result != null)
                {
                    User.Name = result.User.Claims.First(c => c.Type == ClaimTypes.Name).Value ?? "";
                    User.Email = result.User.Claims.First(c => c.Type == ClaimTypes.Email).Value ?? "";
                }
            }
        }
        #endregion
    }
}
