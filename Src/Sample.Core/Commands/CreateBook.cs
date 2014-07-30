using Lib.SimpleCqrs;

namespace Sample.Core.Commands
{
    public class CreateBook : ICommand
    {
        public string Title { get; set; }
    }
}
