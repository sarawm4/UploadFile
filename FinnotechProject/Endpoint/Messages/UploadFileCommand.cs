using Domain.Files;

namespace Endpoint.Messages
{
    public class UploadFileCommand
    {
        public CsvFile Item { get; set; }
        public DateTime At { get; set; }
    }
}
