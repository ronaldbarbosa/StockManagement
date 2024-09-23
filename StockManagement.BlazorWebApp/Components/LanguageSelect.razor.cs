using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace StockManagement.BlazorWebApp.Components
{
    public partial class LanguageSelect : ComponentBase
    {
        #region properties
        private CultureInfo _selectedLanguage = new CultureInfo("pt-br");
        #endregion

        #region overrides
        protected override async Task OnInitializedAsync()
        {
            var js = (IJSInProcessRuntime)JSRuntime;
            var storedCulture = await js.InvokeAsync<string>("applicationCulture.get");

            if (!string.IsNullOrEmpty(storedCulture)) _selectedLanguage = new CultureInfo(storedCulture);
        }
        #endregion

        #region methods
        protected void SetCulture(string language)
        {            
            _selectedLanguage = new CultureInfo(language ?? "pt-br");

            if (CultureInfo.CurrentCulture != _selectedLanguage)
            {
                var js = (IJSInProcessRuntime)JSRuntime;
                js.InvokeVoid("applicationCulture.set", _selectedLanguage.Name);
                NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
            }
        }

        protected bool IsChecked(string language)
        {            
            return _selectedLanguage.Name == language;
        }
        #endregion
    }
}
