using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using ReviewsApp.Models.Settings;
using System.Threading.Tasks;

namespace ReviewsApp.Common.Logic
{
    public class FileManager
    {
        private readonly BlobServiceClient _blobServiceClient;

        public FileManager(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            var blobContainer = _blobServiceClient
                .GetBlobContainerClient(AppConfigs.AzureImagesContainer);
            var blobClient = blobContainer.GetBlobClient(file.FileName);

            await blobClient.UploadAsync(file.OpenReadStream());

            var url = blobClient.Uri.ToString();
            return url;
        }
    }
}
