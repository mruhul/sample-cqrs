using Lib.SimpleCqrs;
using Lib.SimpleCqrs.Extended.Cache;
using Lib.SimpleCqrs.Extended.Factories;
using Ninject.Modules;
using Sample.Core;
using Sample.Core.Dtos;
using Sample.Core.Queries;
using Sample.Infrastructure.CacheStores;
using Sample.Infrastructure.QueryHandlers;
using Sample.Infrastructure.QueryResultFilters;

namespace Sample.WebUI.Ioc.Modules
{
    public class QueriesModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IAsyncQueryHandlerFactory<,>)).To(typeof (AsyncQueryHandlerFactory<,>));
            Bind<ICacheProvider>().To<DefaultCacheProvider>().InSingletonScope();

            Bind<IAsyncQueryHandler<GetBooks, PagedResponse<BookListItem>>>().To<GetBooksHandler>();
            Bind<IAsyncCacheStore<GetBooks, PagedResponse<BookListItem>>>().To<GetBooksCacheStore>();
            Bind<IAsyncQueryResultFilter<GetBooks, PagedResponse<BookListItem>>>().To<BooksQueryResultFilter>();
        }
    }
}