using Microsoft.AspNetCore.Components;
using StockManagement.Application.DTOs;
using StockManagement.BlazorWebApp.Services.Interfaces;

namespace StockManagement.BlazorWebApp.Pages.Administration.Roles
{
    public partial class Roles : ComponentBase
    {
        #region services
        [Inject]
        public IUserWebService UserWebService { get; set; } = null!;
        #endregion

        #region properties
        public List<RoleDTO> RoleList { get; set; } = [];
        #endregion

        #region overrides
        protected override async Task OnInitializedAsync()
        {
            var result = await UserWebService.GetAllRolesAsync();
            if (result is not null)
            {
                RoleList = result.Roles ?? [];
            }
        }
        #endregion

        #region methods
        #endregion
    }
}
