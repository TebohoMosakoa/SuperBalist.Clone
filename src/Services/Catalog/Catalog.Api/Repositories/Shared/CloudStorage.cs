using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories.Shared
{
    public class CloudStorage : ICloudStorage
    {
        private readonly GoogleCredential googleCredential;
        private readonly StorageClient storageClient;
        private readonly string bucketName;

        public CloudStorage(GoogleCredential googleCredential, StorageClient storageClient, string bucketName)
        {
            this.googleCredential = googleCredential;
            this.storageClient = storageClient;
            this.bucketName = bucketName;
        }

        public async Task<string> UploadFileAsync(IFormFile imageFile, string fileNameForStorage)
        {
            using var memoryStream = new MemoryStream();
            await imageFile.CopyToAsync(memoryStream);
            var dataObject = await storageClient.UploadObjectAsync(bucketName, fileNameForStorage, null, memoryStream);
            return dataObject.MediaLink;
        }

        public async Task DeleteFileAsync(string fileNameForStorage)
        {
            await storageClient.DeleteObjectAsync(bucketName, fileNameForStorage);
        }
    }
}
