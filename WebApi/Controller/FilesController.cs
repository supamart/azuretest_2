using System.Collections.Generic;
using System.Threading.Tasks;
using azuretest_2.App.CommonAppLayer.DTOs;
using azuretest_2.App.CommonAppLayer.UseCases.FileStorageUseCases.UploadImages;
using azuretest_2.WebApi.Controller.seed;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace azuretest_2.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : SharedController
    {
        [HttpPost("Images")]
        public async Task<IActionResult> UploadImages(IList<IFormFile> formFiles)
        {
            var uploadImagesCommand = new UploadImagesCommand();

            foreach (var formFile in formFiles)
            {
                var file = new FileDtos
                {
                    Content = formFile.OpenReadStream(),
                    Name = formFile.FileName,
                    ContentType = formFile.ContentType,
                };
                uploadImagesCommand.Files.Add(file);
            }

            var response = await Mediator.Send(uploadImagesCommand);

            return Ok(response);
        }
    }
}