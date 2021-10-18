using System.Threading;
using System.Threading.Tasks;
using azuretest_2.App.CommonAppLayer.DTOs;
using azuretest_2.App.CommonAppLayer.Interfaces;
using MediatR;

namespace azuretest_2.App.CommonAppLayer.UseCases.FileStorageUseCases.UploadImages
{
   public class UploadImagesCommandHandler : IRequestHandler<UploadImagesCommand, UrlsDtos>
    {
        private readonly IFileStorageService _fileStorageService;

        public UploadImagesCommandHandler(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }

        public async Task<UrlsDtos> Handle(UploadImagesCommand request, CancellationToken cancellationToken)
        {
            var urls = await _fileStorageService.UploadAsync(request.Files);
            return urls;
        }
    }
}