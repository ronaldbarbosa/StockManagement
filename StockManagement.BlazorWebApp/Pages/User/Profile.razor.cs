using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using StockManagement.BlazorWebApp.Services.Interfaces;

namespace StockManagement.BlazorWebApp.Pages.User
{
    public partial class Profile : ComponentBase
    {
        #region services
        [Inject]
        public IBlobStorageWebService BlobStorageWebService { get; set; } = null!;
        #endregion

        #region properties
        private IBrowserFile _selectedFile;
        private string _uploadResult;
        private bool _loading = false;
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