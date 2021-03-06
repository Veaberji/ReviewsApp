using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using ReviewsApp.Models.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ReviewsApp.Services
{
    public class ImageStoreService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public ImageStoreService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            CheckFile(file);
            var blobContainer = _blobServiceClient
                .GetBlobContainerClient(ImageConfigs.AzureImagesContainer);
            var blobClient = blobContainer.GetBlobClient(
                GetUniqueFileName(file.FileName));

            await blobClient.UploadAsync(file.OpenReadStream());

            var url = blobClient.Uri.ToString();
            return url;
        }

        public async Task DeleteImageAsync(string url)
        {
            var blobContainer = _blobServiceClient
                .GetBlobContainerClient(ImageConfigs.AzureImagesContainer);
            var fileName = url.Replace(ImageConfigs.BaseImagesUrl, "");
            var blobClient = blobContainer.GetBlobClient(fileName);

            await blobClient.DeleteIfExistsAsync();
        }

        public async Task DeleteImagesAsync(IEnumerable<string> urls)
        {
            foreach (var url in urls)
            {
                await DeleteImageAsync(url);
            }
        }

        public async Task<List<string>> UploadImagesAsync(IEnumerable<IFormFile> files)
        {
            var urls = new List<string>();
            foreach (var file in files)
            {
                urls.Add(await UploadImageAsync(file));
            }
            return urls;
        }

        private static void CheckFile(IFormFile file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }
            if (!IsValidType(file))
            {
                throw new ArgumentException(
                    $"Invalid type: file '{file.FileName}'");
            }
            if (!IsValidSize(file))
            {
                throw new ArgumentException(
                    $"Invalid size: file '{file.FileName}'");
            }
        }

        private static bool IsValidType(IFormFile file)
        {
            return file.ContentType.Contains("image");
        }

        private static bool IsValidSize(IFormFile file)
        {
            return file.Length <= ImageConfigs.MaxImageSizeInBytes;
        }

        private string GetUniqueFileName(string fileName)
        {
            string randomName = Path.GetRandomFileName();
            string name = Path.GetFileNameWithoutExtension(fileName);
            string cutFileName = name[..Math.Min(name.Length, ImageConfigs.SizeToCutImageFileName)]
                .Replace(" ", "_");
            string extension = Path.GetExtension(fileName);

            return randomName + "_" + cutFileName + extension;
        }
    }
}
