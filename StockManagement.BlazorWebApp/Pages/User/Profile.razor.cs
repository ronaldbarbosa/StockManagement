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
        public IBrowserFile? SelectedFile { get; set; }
        public string UploadResult { get; set; } =string.Empty;

        public bool Loading { get; set; } = false;

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
            SelectedFile = e.File;
        }

        private async Task UploadFile()
        {
            Loading = true;

            if (SelectedFile is null)
            {
                Loading = false;
                return;
            }

            var content = new MultipartFormDataContent();
            var fileContent = new StreamContent(SelectedFile.OpenReadStream(maxAllowedSize: 1024 * 1024 * 4));

            content.Add(fileContent, "file", SelectedFile.Name);

            var response = await BlobStorageWebService.UploadImageAsync(content);

            if (response.IsSuccessStatusCode)
            {
                UploadResult = "Sucesso";
            }
            else
            {
                UploadResult = "Erro" + response.ReasonPhrase;
            }

            Loading = false;
        }
        #endregion
    }
}