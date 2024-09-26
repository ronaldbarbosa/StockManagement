namespace StockManagement.BlazorWebApp.Services.Interfaces
{
    public interface IBlobStorageWebService
    {
        Task<HttpResponseMessage> UploadImageAsync(MultipartFormDataContent content);
    }
}
