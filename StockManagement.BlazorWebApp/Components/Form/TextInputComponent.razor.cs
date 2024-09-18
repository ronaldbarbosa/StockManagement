using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace StockManagement.BlazorWebApp.Components.Form
{
    public partial class TextInputComponent : ComponentBase
    {
        #region properties
        [Parameter] public string Label { get; set; } = string.Empty;
        [Parameter] public InputTypes Type { get; set; } = InputTypes.text;
        [Parameter] public string Id { get; set; } = string.Empty;
        [Parameter] public string Value { get; set; } = string.Empty;
        [Parameter] public EventCallback<string> ValueChanged { get; set; }
        [Parameter] public Expression<Func<string>> ValueExpression { get; set; }
        #endregion

        #region methods
        private async Task HandleInput(ChangeEventArgs e)
        {
            Value = e.Value.ToString();
            await ValueChanged.InvokeAsync(Value); // Notifica o componente pai sobre a mudança de valor
        }
        #endregion
    }

    public enum InputTypes
    {
        text = 0,
        email = 1,
        password = 2,
    }
}
