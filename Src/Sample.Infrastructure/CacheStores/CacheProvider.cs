using System;
using System.Threading.Tasks;

namespace Sample.Infrastructure.CacheStores
{
    public interface ICacheProvider
    {
        Task<bool> ExistsAsync(string key);
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, TimeSpan expiredIn);
        Task RemoveAsync(string key);
    }
}
