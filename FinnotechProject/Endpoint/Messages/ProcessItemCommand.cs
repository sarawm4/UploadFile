using Domain.Files;

namespace Endpoint.Messages;

public class ProcessItemCommand
{
    public CsvFile Item { get; set; }
    public DateTime At { get; set; }
}