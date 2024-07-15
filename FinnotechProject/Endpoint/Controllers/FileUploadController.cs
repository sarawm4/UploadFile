using Application.Interfaces.Context;
using CsvHelper;
using Domain.Files;
using Endpoint.Messages;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Endpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileUploadController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IDataBaseContext _context;
        public FileUploadController(IBus bus, IDataBaseContext context)
        {
            _bus = bus;
            _context = context;
        }

        [HttpPost]
        [Route("UploadQueue1")]
        public async Task<IActionResult> UploadFileQueue1(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            List<CsvFile> items;
            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                items = csv.GetRecords<CsvFile>().ToList();
                await _context.csvFiles.AddRangeAsync(items);
                await _context.SaveChangesAsync();
            }
            foreach (var item in items)
            {
                await _bus.Publish(new CreateItemCommand
                {
                    Item = item,
                    At = DateTime.Now
                });
            }

            return Ok("File uploaded and SaveDB In Queue1.");
        }
        [HttpPost]
        [Route("UploadQueue2")]
        public async Task<IActionResult> UploadFileQueue2(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            List<CsvFile> items;
            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                items = csv.GetRecords<CsvFile>().ToList();
            }

            foreach (var item in items)
            {
                await _bus.Publish(new ProcessItemCommand
                {
                    Item = item,
                    At = DateTime.Now
                });
            }

            return Ok("File uploaded and processed.");
        }
    }
}
