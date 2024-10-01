using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace StockManagement.BlazorWebApp.Components.Form
{
    public partial class CheckInputComponent : ComponentBase
    {
        #region properties
        [Parameter]
        public string Label { get; set; } = string.Empty;
        [Parameter]
        public string Id { get; set; } = string.Empty;
        [Parameter]
        public bool Value { get; set; } = false;
        [Parameter]
        public bool Disabled { get; set; } = false;
        [Parameter]
        public EventCallback<bool> ValueChanged { get; set; }
        [Parameter]
        public Expression<Func<bool>> ValueExpression { get; set; }
        #endregion

        #region methods
        public async Task HandleChange(ChangeEventArgs e)
        {
            Value = (bool)e.Value;
            await ValueChanged.InvokeAsync(Value); // Notifica o componente pai sobre a mudança de valor
        }
        #endregion
    }
}
