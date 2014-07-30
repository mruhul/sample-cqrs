using Lib.SimpleCqrs;
using Sample.Core.Events;
using Sample.Core.Logger;

namespace Sample.Infrastructure.EventHandlers
{
    public class SendEmailOnBookCreatedHandler : IEventHandler<BookCreated>
    {
        private readonly ILogger _logger;

        public SendEmailOnBookCreatedHandler(ILogger logger)
        {
            _logger = logger;
        }

        public void Handle(BookCreated input)
        {
            _logger.Debug("Sending email to members who want to be notified on new book available {0}", input.Id);
        }
    }
}
