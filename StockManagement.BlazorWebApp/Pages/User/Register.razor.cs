using Microsoft.AspNetCore.Components;
using StockManagement.Application.DTOs.Request;
using StockManagement.BlazorWebApp.Authentication;
using StockManagement.BlazorWebApp.Services;

namespace StockManagement.BlazorWebApp.Pages.User
{
    public partial class RegisterPage : ComponentBase
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
        public CreateUserRequest InputModel { get; set; } = new();
        public bool Loading { get; set; } = false;
        #endregion

        #region overrides

        #endregion

        #region methods

        public async Task OnValidSubmitAsync()
        {
            Loading = true;
            // TODO: show identity's validations on register page; 
            
            try
            {
                var result = await AuthWebService.RegisterAsync(InputModel);
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

        protected void RedirectToLogin()
        {
            NavigationManager.NavigateTo("/Login");
        }

        #endregion
    }
}
