using Microsoft.AspNetCore.Components;
using StockManagement.Application.DTOs.Request;
using StockManagement.BlazorWebApp.Authentication;
using StockManagement.BlazorWebApp.Services;

namespace StockManagement.BlazorWebApp.Pages.User
{
    public partial class LoginPage : ComponentBase
    {
        #region services

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ICustomAuthenticationStateProvider AuthStateProvider { get; set; } = null!;

        [Inject]
        public AuthWebService AuthWebService { get; set; } = null!;

        #endregion

        #region properties
        public LoginRequest InputModel { get; set; } = new();
        public bool Loading { get; set; } = false;
        #endregion

        #region overrides

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity is { IsAuthenticated: true })
                NavigationManager.NavigateTo("/");
        }

        #endregion

        #region methods

        public async Task OnValidSubmitAsync()
        {
            Loading = true;

            try
            {
                var result = await AuthWebService.LoginAsync(InputModel);
                if (result.Contains("sucesso"))
                {
                    await AuthStateProvider.GetAuthenticationStateAsync();
                    AuthStateProvider.NotifyAuthenticationStateChanged();
                    NavigationManager.NavigateTo("/");
                }
                else
                    Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
