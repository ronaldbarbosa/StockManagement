using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using StockManagement.Application.DTOs;
using StockManagement.BlazorWebApp.Services.Interfaces;

namespace StockManagement.BlazorWebApp.Pages.User
{
    public partial class Profile : ComponentBase
    {
        #region services
        [Inject]
        public IBlobStorageWebService BlobStorageWebService { get; set; } = null!;

        [Inject]
        public IAuthWebService AuthWebService { get; set; } = null!;
        #endregion

        #region properties
        public IBrowserFile _selectedFile { get; set; }
        public string _uploadResult { get; set; } =string.Empty;

        public bool _loading { get; set; } = false;

        public UserDTO? User { get; set; }
        #endregion

        #region overrides

        protected override async Task OnInitializedAsync()
        {
            var result = await AuthWebService.GetUserInfoAsync();
            if (result is not null)
            {
                User = result.User;
            }
        }

        #endregion

        #region methods

        private void HandleFile(InputFileChangeEventArgs e)
        {
            _selectedFile = e.File;
        }

        private async Task UploadFile()
        {
            _loading = true;

            if (_selectedFile is null)
            {
                _loading = false;
                return;
            }

            var content = new MultipartFormDataContent();
            var fileContent = new StreamContent(_selectedFile.OpenReadStream(maxAllowedSize: 1024 * 1024 * 4));

            content.Add(fileContent, "file", _selectedFile.Name);

            var response = await BlobStorageWebService.UploadImageAsync(content);

            if (response.IsSuccessStatusCode)
            {
                _uploadResult = "Sucesso";
            }
            else
            {
                _uploadResult = "Erro" + response.ReasonPhrase;
            }

            _loading = false;
        }
        #endregion
    }
}