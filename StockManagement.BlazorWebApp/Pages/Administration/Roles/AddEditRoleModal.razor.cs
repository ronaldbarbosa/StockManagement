using Microsoft.AspNetCore.Components;
using StockManagement.Application.DTOs;

namespace StockManagement.BlazorWebApp.Pages.Administration.Roles;

public partial class AddEditRoleModal : ComponentBase
{
    #region services

    #endregion

    #region properties
    [Parameter] public bool IsVisible { get; set; }
    [Parameter] public EventCallback<bool> IsVisibleChanged { get; set; }
    [Parameter] public RoleDTO Role { get; set; } = null!;
    [Parameter] public EventCallback OnSave { get; set; }

    #endregion

    #region overrides

    #endregion

    #region methods
    public void Show()
    {
        IsVisible = true;
        StateHasChanged();
    }

    private void CloseModal()
    {
        IsVisible = false;
        StateHasChanged();
    }

    #endregion
}