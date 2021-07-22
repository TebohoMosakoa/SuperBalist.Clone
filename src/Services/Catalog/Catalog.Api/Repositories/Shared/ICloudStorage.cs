using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories.Shared
{
    public interface ICloudStorage
    {
        Task<string> UploadFileAsync(IFormFile imageFile, string fileNameForStorage);
        Task DeleteFileAsync(string fileNameForStorage);
    }
}
