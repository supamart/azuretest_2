using System.Collections.Generic;
using System.Linq;
using azuretest_2.App.CommonAppLayer.DTOs;
using FluentValidation;

namespace azuretest_2.App.CommonAppLayer.UseCases.FileStorageUseCases.UploadImages
{
   public class UploadImagesCommandValidator : AbstractValidator<UploadImagesCommand>
    {
        public UploadImagesCommandValidator()
        {
            RuleFor(v => v.Files)
                .Must(FilesNotEmpty)
                .WithMessage("File cannot be empty");

            RuleFor(v => v.Files)
                .Must(IsValidContentType)
                .WithMessage("Invalid file type. Only '.jpg' and '.png' files are allowed");
        }

        private bool FilesNotEmpty(ICollection<FileDtos> files)
        {
            if (files == null || files.Count == 0)
            {
                return false;
            }

            foreach (var file in files)
            {
                if (file.Content.Length == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsValidContentType(ICollection<FileDtos> files)
        {
            var validContentTypes = new string[] { "image/jpeg", "image/png" };

            foreach (var file in files)
            {
                if (!validContentTypes.Contains(file.ContentType))
                {
                    return false;
                }
            }

            return true;
        }
    }
}