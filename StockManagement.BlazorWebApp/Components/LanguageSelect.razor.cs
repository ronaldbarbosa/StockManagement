using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace StockManagement.BlazorWebApp.Components
{
    public partial class LanguageSelect : ComponentBase
    {
        #region properties
        public CultureInfo SelectedLanguage { get; set; } = new CultureInfo("pt-br");
        #endregion

        #region overrides
        protected override async Task OnInitializedAsync()
        {
            var js = (IJSInProcessRuntime)JSRuntime;
            var storedCulture = await js.InvokeAsync<string>("applicationCulture.get");

            if (!string.IsNullOrEmpty(storedCulture)) SelectedLanguage = new CultureInfo(storedCulture);
        }
        #endregion

        #region methods
        public void SetCulture(string language)
        {            
            SelectedLanguage = new CultureInfo(language ?? "pt-br");

            if (CultureInfo.CurrentCulture != SelectedLanguage)
            {
                var js = (IJSInProcessRuntime)JSRuntime;
                js.InvokeVoid("applicationCulture.set", SelectedLanguage.Name);
                NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
            }
        }

        public bool IsChecked(string language)
        {            
            return SelectedLanguage.Name == language;
        }
        #endregion
    }
}
