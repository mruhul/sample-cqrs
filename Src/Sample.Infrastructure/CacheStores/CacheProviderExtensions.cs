using System;
using System.Threading.Tasks;

namespace Sample.Infrastructure.CacheStores
{
    public static class CacheProviderExtensions
    {
        public static async Task<TEntity> GetObjectAsync<TEntity>(this ICacheProvider source, string key, TimeSpan expiredIn,
            Func<Task<TEntity>> fetch) where TEntity : class
        {
            if (await source.ExistsAsync(key))
            {
                return await source.GetAsync<TEntity>(key);
            }

            var result = await fetch.Invoke();

            if (result != null)
            {
                await source.SetAsync(key, result, expiredIn);
            }

            return result;
        }
    }
}