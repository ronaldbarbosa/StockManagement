namespace StockManagement.Application.Interfaces.Services
{
    public interface IBlobStorageAppService
    {
        Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType);
        Task<Stream> DownloadFileAsync(string fileName);
    }
}
