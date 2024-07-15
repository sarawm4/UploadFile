using Application.Interfaces.Context;
using Domain.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Files
{
    public class UploadFileServices : IUploadFileServices
    {
        private readonly IDataBaseContext _context;

        public UploadFileServices(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task DeleteAllDataAsync()
        {
            _context.csvFiles.RemoveRange(_context.csvFiles);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CsvFile>> FetchAllAsync()
        {
            var data = await _context.csvFiles.ToListAsync();
            return data;
        }

        public async Task<CsvFile> FetchbycodeAsync(string code)
        {
            var data = await _context.csvFiles.FirstOrDefaultAsync(d => d.Code == code);
            if (data == null)
            {
                throw new ArgumentException("file not found ");
            }
            else
            {
                return data;
            }
        }

        public async Task UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file uploaded.");
            }

            using (var stream = new StreamReader(file.OpenReadStream()))
            {
                var headers = await stream.ReadLineAsync();
                var csvData = new List<CsvFile>();
                while (!stream.EndOfStream)
                {
                    var line = (await stream.ReadLineAsync())?.Split(',');
                    if (line != null)
                    {
                        var code = line[0];
                        if (await _context.csvFiles.AnyAsync(d => d.Code == code))
                        {
                            throw new InvalidOperationException($"Duplicate code found: {code}");
                        }

                        csvData.Add(new CsvFile
                        {
                            Code = code,
                            Name = line[1],
                            Value = line[2]
                        });
                    }
                }
                await _context.csvFiles.AddRangeAsync(csvData);
                await _context.SaveChangesAsync();

            }
        }
    }
}