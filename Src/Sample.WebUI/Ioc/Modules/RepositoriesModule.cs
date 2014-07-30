using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using AsyncPoco;
using Ninject.Modules;
using Sample.Repositories;
using Sample.Repositories.SqlClient;

namespace Sample.WebUI.Ioc.Modules
{
    public class RepositoriesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<AsyncPoco.Database>().ToMethod(x => new Database("SampleDb"));
            Bind<IBooksRepository>().To<BooksRepository>();
        }
    }
}