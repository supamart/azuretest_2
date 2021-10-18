using System.Collections.Generic;
using System.Threading.Tasks;
using azuretest_2.App.CommonAppLayer.DTOs;

namespace azuretest_2.App.CommonAppLayer.Interfaces
{
    public interface IFileStorageService
    {
         Task<UrlsDtos> UploadAsync(ICollection<FileDtos> files);
    }
}