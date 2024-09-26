using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using StockManagement.Application.Interfaces.Services;

namespace StockManagement.Application.Services
{
    public class AzureBlobStorageAppService : IBlobStorageAppService
    {
        private readonly string _connectionString;
        private readonly string _containerName;

        public AzureBlobStorageAppService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureBlobStorage") ?? "";
            _containerName = configuration.GetConnectionString("ContainerName") ?? "";
        }

        public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
        {
            var blobServiceClient = new BlobServiceClient(_connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);

            await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

            var blobClient = containerClient.GetBlobClient(fileName);
            var blobHttpHeaders = new BlobHttpHeaders { ContentType = contentType };

            await blobClient.UploadAsync(fileStream, blobHttpHeaders);

            return blobClient.Uri.ToString();
        }

        public async Task<Stream> DownloadFileAsync(string fileName)
        {
            var blobServiceClient = new BlobServiceClient(_connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(fileName);

            var response = await blobClient.DownloadAsync();
            return response.Value.Content;
        }
    }
}
