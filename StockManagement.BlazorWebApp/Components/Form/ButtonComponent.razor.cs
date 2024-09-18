using Microsoft.AspNetCore.Components;

namespace StockManagement.BlazorWebApp.Components.Form
{
    public partial class ButtonComponent : ComponentBase
    {
        #region properties
        [Parameter] public string ButtonText { get; set; } = string.Empty;
        [Parameter] public ButtonTypes ButtonType { get; set; } = ButtonTypes.button;
        [Parameter] public string IconClass { get; set; } = string.Empty;
        [Parameter] public string ButtonClass { get; set; } = string.Empty;
        [Parameter] public bool IsLoading { get; set; } = false;
        [Parameter] public EventCallback OnClickCallback { get; set; }
        #endregion

        #region methods
        private async Task OnClick()
        {
            if (OnClickCallback.HasDelegate)
            {
                await OnClickCallback.InvokeAsync();
            }
        }
        #endregion
    }

    public enum ButtonTypes
    {
        button = 0,
        submit = 1
    }
}
