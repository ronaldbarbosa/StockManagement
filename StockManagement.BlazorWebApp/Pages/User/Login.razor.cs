using Microsoft.AspNetCore.Components;
using StockManagement.Application.DTOs.Request;
using StockManagement.BlazorWebApp.Authentication;
using StockManagement.BlazorWebApp.Services.Interfaces;
using System.Net;

namespace StockManagement.BlazorWebApp.Pages.User
{
    public partial class Login : ComponentBase
    {
        #region services

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ICustomAuthenticationStateProvider AuthStateProvider { get; set; } = null!;

        [Inject]
        public IAuthWebService AuthWebService { get; set; } = null!;

        #endregion

        #region properties
        public LoginRequest InputModel { get; set; } = new();
        public bool Loading { get; set; } = false;
        public List<string> Errors { get; set; } = [];
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
            Errors = [];

            try
            {
                var result = await AuthWebService.LoginAsync(InputModel);

                if (result.IsSucceded() && result.StatusCode != HttpStatusCode.Unauthorized)
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
                    else if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Errors.Add("Unauthorized");
                    }
                }                    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RedirectToRegister()
        {
            NavigationManager.NavigateTo("/Cadastro");
        }

        #endregion
    }
}
