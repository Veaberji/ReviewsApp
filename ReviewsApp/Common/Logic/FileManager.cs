using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using ReviewsApp.Models.Settings;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<string> UploadImage(IFormFile file)
        {
            CheckFile(file);
            var blobContainer = _blobServiceClient
                .GetBlobContainerClient(AppConfigs.AzureImagesContainer);
            var blobClient = blobContainer.GetBlobClient(
                GetUniqueFileName(file.FileName));

            await blobClient.UploadAsync(file.OpenReadStream());

            var url = blobClient.Uri.ToString();
            return url;
        }

        //public async Task<string> DeleteImage(string url)
        //{
        //    var blobContainer = _blobServiceClient
        //        .GetBlobContainerClient(AppConfigs.AzureImagesContainer);
        //    var blobClient = blobContainer.GetBlobClient(
        //        GetUniqueFileName(file.FileName));

        //    await blobClient.UploadAsync(file.OpenReadStream());

        //    return url;
        //}

        public async Task<List<string>> UploadImages(IEnumerable<IFormFile> files)
        {
            var urls = new List<string>();
            foreach (var file in files)
            {
                urls.Add(await UploadImage(file));
            }
            return urls;
        }

        private void CheckFile(IFormFile file)
        {
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
            return file.Length <= AppConfigs.MaxImageSizeInBytes;
        }

        public string GetUniqueFileName(string fileName)
        {
            string randomName = Path.GetRandomFileName();
            var name = Path.GetFileNameWithoutExtension(fileName);
            var cutFileName = name[..Math.Min(name.Length, AppConfigs.SizeToCutImageFileName)];
            string extension = Path.GetExtension(fileName);

            return randomName + "_" + cutFileName + extension;
        }
    }
}
