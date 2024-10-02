using Microsoft.AspNetCore.Components;

namespace StockManagement.BlazorWebApp.Components
{
    public partial class AlertMessage : ComponentBase
    {
        #region properties
        [Parameter]
        public AlertTypes Type { get; set; } = AlertTypes.primary;
        [Parameter]
        public string Title { get; set; } = string.Empty;
        [Parameter]
        public string Message { get; set; } = string.Empty;
        [Parameter]
        public string Icon { get; set; } = "fa-check";
        #endregion
    }

    public enum AlertTypes
    {
        black,
        primary,
        secondary,
        success,
        danger,
        warning,
        info
    }
}
