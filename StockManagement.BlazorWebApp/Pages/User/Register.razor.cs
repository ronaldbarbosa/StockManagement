using Microsoft.AspNetCore.Components;
using StockManagement.Application.DTOs.Request;
using StockManagement.BlazorWebApp.Authentication;
using StockManagement.BlazorWebApp.Services.Interfaces;

namespace StockManagement.BlazorWebApp.Pages.User
{
    public partial class Register : ComponentBase
    {
        #region services
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ICustomAuthenticationStateProvider AuthStateProvider { get; set; } = null!;

        [Inject]
        public IUserWebService AuthWebService { get; set; } = null!;

        #endregion

        #region properties
        public CreateUserRequest InputModel { get; set; } = new();
        public bool Loading { get; set; } = false;
        public List<string> Errors { get; set; } = [];
        #endregion

        #region overrides

        #endregion

        #region methods

        public async Task OnValidSubmitAsync()
        {
            Loading = true;
            Errors = [];

            try
            {
                var result = await AuthWebService.SignUpAsync(InputModel);
                if (result.IsSucceded())
                {
                    await AuthStateProvider.GetAuthenticationStateAsync();
                    AuthStateProvider.NotifyAuthenticationStateChanged();
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    if (result.Errors.Count != 0)
                    {
                        foreach (var errorList in result.Errors.Keys)
                        {
                            Errors.Add(errorList);
                        }
                    }
                }
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
