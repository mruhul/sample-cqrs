using Lib.SimpleCqrs;
using Lib.SimpleCqrs.Extended;
using Lib.SimpleCqrs.Extended.Factories;
using Lib.Validation;
using Ninject.Modules;
using Sample.Core.Commands;
using Sample.Core.Events;
using Sample.Infrastructure.CommandHandlers;
using Sample.Infrastructure.EventHandlers;
using Sample.Infrastructure.Validators;

namespace Sample.WebUI.Ioc.Modules
{
    public class CommandsModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IAsyncCommandHandlerFactory<,>)).To(typeof(AsyncCommandHandlerFactory<,>));

            Bind<IAsyncCommandHandler<CreateBook, CommandReply<long>>>().To<CreateBookHandler>();
            Bind<IAsyncValidator<CreateBook>>().To<CreateBookInputValidator>().InSingletonScope();
            Bind<IAsyncValidator<CreateBook>>().To<CreateBookUniqueValidator>();
            Bind<IEventHandler<BookCreated>>().To<SendEmailOnBookCreatedHandler>();
        }
    }
}