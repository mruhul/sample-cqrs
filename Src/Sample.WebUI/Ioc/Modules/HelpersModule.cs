using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AsyncPoco;
using Ninject.Modules;
using Sample.Core.Logger;
using Sample.Infrastructure.Logger;
using Sample.Infrastructure.Mappers;

namespace Sample.WebUI.Ioc.Modules
{
    public class HelpersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().ToMethod(x => new NLogLogger(x.Request.Target == null ? typeof(NLogLogger).FullName :  x.Request.Target.Type.FullName));
            Bind<Core.Mappers.IMapper>().To<AutoMappedMapper>().InSingletonScope();
        }
    }
}