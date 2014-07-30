using Lib.SimpleCqrs;

namespace Sample.Core.Events
{
    public class BookCreated : IEvent
    {
        public long Id { get; set; }
    }
}
