using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using StockManagement.Application.DTOs;
using StockManagement.BlazorWebApp.Services.Interfaces;
using System.Net;

namespace StockManagement.BlazorWebApp.Components
{
    public partial class Sidebar : ComponentBase
    {
        #region services

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISystemResourceWebService Service { get; set; } = null!;

        #endregion

        #region properties

        public List<SystemResourceDTO> Menu { get; set; } = [];

        #endregion        

        #region overrides

        protected override async Task OnInitializedAsync()
        {
            var response = await Service.GetAllResourcesAsync();

            if (response is not null && response.StatusCode == HttpStatusCode.OK)
            {
                Menu = response.Menu;
            }

            // Inscrever-se no evento de mudança de URL
            NavigationManager.LocationChanged += OnLocationChanged;
        }

        #endregion

        #region methods

        private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
        {
            // Atualiza o estado da página quando a rota muda
            InvokeAsync(StateHasChanged);
        }

        public string IsActive(string href) => NavigationManager.Uri.EndsWith(href) ? "active" : string.Empty;

        public string IsParentActive(string href, ReturnTypeIsParentActive returnType)
        {
            var parent = href.Replace("Menu", "");
            if (NavigationManager.Uri.Contains(parent))
            {
                if (returnType is ReturnTypeIsParentActive.NavItem) return "active";
                else if (returnType is ReturnTypeIsParentActive.Submenu) return "show";
            }

            return string.Empty;
        }

        public void Dispose()
        {
            // Desinscrever-se do evento quando o componente é destruído
            NavigationManager.LocationChanged -= OnLocationChanged;
        }

        #endregion
    }

    #region enums
    public enum ReturnTypeIsParentActive
    {
        NavItem,
        Submenu
    }
    #endregion
}
