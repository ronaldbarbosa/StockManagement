using Microsoft.AspNetCore.Components;
using StockManagement.Application.DTOs;
using StockManagement.BlazorWebApp.Services.Interfaces;

namespace StockManagement.BlazorWebApp.Pages.Administration.Roles;

public partial class AddEditRoleModal : ComponentBase
{
    #region services
    [Inject]
    public IUserWebService UserWebService { get; set; } = null!;
    #endregion

    #region properties
    [Parameter] public bool IsVisible { get; set; }
    [Parameter] public EventCallback<bool> IsVisibleChanged { get; set; }
    [Parameter] public RoleDTO Role { get; set; } = null!;
    [Parameter] public EventCallback OnSave { get; set; }

    private bool Loading { get; set; } = false;

    #endregion

    #region overrides

    #endregion

    #region methods
    public async Task SaveAsync()
    {
        Loading = true;
        await UserWebService.CreateRoleAsync(Role.Name);
        Loading = false;
    }
    
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