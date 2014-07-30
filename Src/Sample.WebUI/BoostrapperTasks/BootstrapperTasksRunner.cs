using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Sample.Core.BootstrapperTasks;
using Sample.Core.Extensions;

namespace Sample.WebUI.BoostrapperTasks
{
    public static class BootstrapperTasksRunner
    {
        public static void Run()
        {
            var tasks = GlobalConfiguration.Configuration.DependencyResolver.GetServices(typeof (IBoostrapperTask));
            
            tasks.NullSafe().ForEach(x =>
                {
                    try
                    {
                        ((IBoostrapperTask)x).Run();
                    }
                    catch(Exception e)
                    {
                        // log here
                    }
                });
        }
    }
}