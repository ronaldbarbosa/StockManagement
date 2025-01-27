using Microsoft.AspNetCore.Components;
using StockManagement.Application.DTOs;
using StockManagement.BlazorWebApp.Services.Interfaces;

namespace StockManagement.BlazorWebApp.Pages.Administration.Roles
{
    public partial class Roles : ComponentBase
    {
        #region services

        [Inject] public IUserWebService UserWebService { get; set; } = null!;

        #endregion

        #region properties

        public List<RoleDTO> RoleList { get; set; } = [];
        public bool IsAddEditModalVisible { get; set; }
        public RoleDTO SelectedRole { get; set; } = null!;
        public string ModalTitle { get; set; } = string.Empty;

        #endregion

        #region overrides

        protected override async Task OnInitializedAsync()
        {
            await LoadRoles();
        }

        #endregion

        #region methods

        private async Task LoadRoles()
        {
            var result = await UserWebService.GetAllRolesAsync();
            RoleList = result.Roles ?? [];
        }

        private void ShowAddRoleModal()
        {
            SelectedRole = new RoleDTO();
            IsAddEditModalVisible = true;
            ModalTitle = "Add Role";
        }

        private void ShowEditRoleModal(RoleDTO role)
        {
            SelectedRole = role;
            IsAddEditModalVisible = true;
            ModalTitle = "Edit Role";
        }

        #endregion
    }
}