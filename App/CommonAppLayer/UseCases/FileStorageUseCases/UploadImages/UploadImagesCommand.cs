using System.Collections.Generic;
using azuretest_2.App.CommonAppLayer.DTOs;
using MediatR;

namespace azuretest_2.App.CommonAppLayer.UseCases.FileStorageUseCases.UploadImages
{
   
    public class UploadImagesCommand : IRequest<UrlsDtos>
    {
        public ICollection<FileDtos> Files { get; set; } = new List<FileDtos>();
    }
}