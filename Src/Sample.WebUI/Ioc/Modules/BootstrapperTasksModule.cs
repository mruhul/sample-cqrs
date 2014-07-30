using Ninject.Modules;
using Sample.Core.BootstrapperTasks;
using Sample.Infrastructure.BootstrapperTasks;
using Sample.WebUI.BoostrapperTasks;

namespace Sample.WebUI.Ioc.Modules
{
    public class BootstrapperTasksModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBoostrapperTask>().To<GlobalFilterSetupTask>().InSingletonScope();
            Bind<IBoostrapperTask>().To<AutomapperBootstrapperTask>().InSingletonScope();
            Bind<IBoostrapperTask>().To<Repositories.BootstrapperTasks.AutomapperBootstrapperTask>().InSingletonScope();
        }
    }
}