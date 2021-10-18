using System.Collections.Generic;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Threading.Tasks;
using azuretest_2.App.CommonAppLayer.DTOs;
using azuretest_2.App.CommonAppLayer.Interfaces;

namespace azuretest_2.infra.ThirdPartyServices.AzureServices
{
    public class BlobStorageService : IFileStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobStorageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<UrlsDtos> UploadAsync(ICollection<FileDtos> files)
        {
            if (files == null || files.Count == 0)
            {
                return null;
            }

            var containerClient = _blobServiceClient.GetBlobContainerClient("publicuploads");


            var urls = new List<string>();


            foreach (var file in files)
            {
                var blobClient = containerClient.GetBlobClient(file.GetPathWithFileName());

                await blobClient.UploadAsync(file.Content, new BlobHttpHeaders { ContentType = file.ContentType });

                urls.Add(blobClient.Uri.ToString());
            }

            return new UrlsDtos(urls);
        }
    }
}