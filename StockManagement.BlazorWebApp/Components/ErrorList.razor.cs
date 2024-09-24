using Microsoft.AspNetCore.Components;

namespace StockManagement.BlazorWebApp.Components
{
    public partial class ErrorList : ComponentBase
    {
        #region properties
        [Parameter]
        public List<string> Errors { get; set; } = [];
        [Parameter]
        public string Area { get; set; } = string.Empty;
        [Parameter]
        public string Title { get; set; } = string.Empty;
        #endregion
    }
}
