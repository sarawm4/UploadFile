using Domain.Files;
using Microsoft.AspNetCore.Http;

namespace Application.Files
{
    public interface IUploadFileServices
    {
        Task UploadFileAsync(IFormFile file);
        Task<List<CsvFile>> FetchAllAsync();
        Task<CsvFile> FetchbycodeAsync(string code);
        Task DeleteAllDataAsync();
    }
}
