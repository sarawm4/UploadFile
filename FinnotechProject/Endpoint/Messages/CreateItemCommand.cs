using Domain.Files;

namespace Endpoint.Messages;

public class CreateItemCommand
{
    public CsvFile Item { get; set; }
    public DateTime At { get; set; }
}