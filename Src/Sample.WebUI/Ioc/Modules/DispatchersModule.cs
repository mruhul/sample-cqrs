using Lib.SimpleCqrs;
using Lib.SimpleCqrs.Extended.Impl;
using Ninject.Modules;

namespace Sample.WebUI.Ioc.Modules
{
    public class DispatchersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<Lib.SimpleCqrs.Extended.IDependencyResolver>().ToMethod(x => new DependencyResolver(x.Kernel)).InSingletonScope();

            Bind<ICommandDispatcher>().To<CommandDispatcher>().InSingletonScope();
            Bind<IQueryDispatcher>().To<QueryDispatcher>().InSingletonScope();
            Bind<IEventDispatcher>().To<EventDispatcher>().InSingletonScope();
        }
    }
}