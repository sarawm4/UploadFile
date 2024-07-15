using Application.Files;
using Domain.Files;
using Endpoint.Model;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadFileApiController : ControllerBase
    {
        private readonly IUploadFileServices _csvFileServices;

        public UploadFileApiController(IUploadFileServices csvFileServices)
        {
            _csvFileServices = csvFileServices;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                await _csvFileServices.UploadFileAsync(file);
                return Ok(new ApiResponse<object>(true, "File uploaded successfully.", null));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponse<object>(false, ex.Message, data: null));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new ApiResponse<object>(false, ex.Message, null));
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _csvFileServices.FetchAllAsync();
            return Ok(new ApiResponse<IEnumerable<CsvFile>>(true, "Data fetched successfully.", data));

        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var data = await _csvFileServices.FetchbycodeAsync(code);
            if (data == null)
            {
                return NotFound(new ApiResponse<object>(false, "Data not found.", null));
            }
            return Ok(new ApiResponse<CsvFile>(true, "Data fetched successfully.", data));

        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAll()
        {
            await _csvFileServices.DeleteAllDataAsync();
            return Ok(new ApiResponse<object>(true, "All data deleted.", null));
        }
    }
}