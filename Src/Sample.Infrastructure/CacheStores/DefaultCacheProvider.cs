using System;
using System.Threading.Tasks;

namespace Sample.Infrastructure.CacheStores
{
    public class DefaultCacheProvider : ICacheProvider
    {
        public async Task<bool> ExistsAsync(string key)
        {
            return await Task.FromResult(System.Runtime.Caching.MemoryCache.Default.Contains(key));
        }

        public async Task<T> GetAsync<T>(string key)
        {
            return await Task.FromResult((T)System.Runtime.Caching.MemoryCache.Default.Get(key));
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiredIn)
        {
            await Task.Run(() => System.Runtime.Caching.MemoryCache.Default.Set(key, value, DateTimeOffset.UtcNow.Add(expiredIn)));
        }

        public async Task RemoveAsync(string key)
        {
            await Task.Run(() => System.Runtime.Caching.MemoryCache.Default.Remove(key));
        }
    }
}