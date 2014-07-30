using System;
using System.Threading.Tasks;
using Lib.SimpleCqrs.Extended.Cache;
using Sample.Core.Dtos;
using Sample.Core.Extensions;
using Sample.Core.Queries;

namespace Sample.Infrastructure.CacheStores
{
    public class GetBooksCacheStore : IAsyncCacheStore<GetBooks,PagedResponse<BookListItem>>
    {
        private const string Key = "Books:GetBooks:{0}:{1}";
        private readonly ICacheProvider _cacheProvider;

        public GetBooksCacheStore(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }

        public async Task<PagedResponse<BookListItem>> GetAsync(GetBooks query, Func<Task<PagedResponse<BookListItem>>> fetch)
        {
            if (query.PageIndex == 1)
            {
                var key = Key.FormatWith(Key, query.PageIndex, query.PageSize);

                return await _cacheProvider.GetObjectAsync(key, TimeSpan.FromMinutes(5), fetch);
            }

            return await fetch.Invoke();
        }
    }
}
