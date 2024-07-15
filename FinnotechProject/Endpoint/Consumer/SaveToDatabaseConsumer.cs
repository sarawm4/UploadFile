using Application.Interfaces.Context;
using Endpoint.Messages;
using MassTransit;

namespace Endpoint.Consumer
{
    public class SaveToDatabaseConsumer : IConsumer<CreateItemCommand>
    {
        private readonly IDataBaseContext _context;
        private bool _isSaved;

        public SaveToDatabaseConsumer(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<CreateItemCommand> context)
        {
            _context.csvFiles.Add(context.Message.Item);
            _isSaved = await _context.SaveChangesAsync() > 0;

            // Send a success event to the next consumer
            await context.Publish(new ItemSavedEvent
            {
                IsSaved = _isSaved,
                Message = $"Item {context.Message.Item.Name} with {context.Message.Item.Code} saved " + _isSaved,
                Item = context.Message.Item,
                At = DateTime.Now
            });
        }

    }
}