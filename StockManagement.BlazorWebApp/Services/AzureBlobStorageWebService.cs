using StockManagement.BlazorWebApp.Services.Interfaces;

namespace StockManagement.BlazorWebApp.Services
{
    public class AzureBlobStorageWebService(IHttpClientFactory clientFactory) : IBlobStorageWebService
    {
        private readonly HttpClient _client = clientFactory.CreateClient("client");

        public async Task<HttpResponseMessage> UploadImageAsync(MultipartFormDataContent content)
        {
            var result = await _client.PostAsync("api/blobstorage/upload", content);
            return result;
        }
    }
}
