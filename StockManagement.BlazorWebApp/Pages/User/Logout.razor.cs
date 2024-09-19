﻿using Microsoft.AspNetCore.Components;
using StockManagement.BlazorWebApp.Authentication;
using StockManagement.BlazorWebApp.Services;

namespace StockManagement.BlazorWebApp.Pages.User
{
    public partial class LogoutPage : ComponentBase
    {
        #region Services

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ICustomAuthenticationStateProvider AuthStateProvider { get; set; } = null!;

        [Inject]
        public AuthWebService AuthWebService { get; set; } = null!;

        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            if (await AuthStateProvider.CheckAuthenticatedAsync())
            {
                await AuthWebService.LogoutAsync();
                await AuthStateProvider.GetAuthenticationStateAsync();
                AuthStateProvider.NotifyAuthenticationStateChanged();
            }

            await base.OnInitializedAsync();
        }

        protected void RedirectToLogin()
        {
            NavigationManager.NavigateTo("");
        }

        #endregion
    }
}