using System;
using FastSchool.Interface;
using Microsoft.Extensions.Caching.Memory;

namespace FastSchool.Common
{
    public class MemoryCache : ICache
    {
        public IMemoryCache Cache { get; }
        public MemoryCache(IMemoryCache memoryCache)
        {
            Cache = memoryCache;
        }

        public void Set<T>(object key, T Tvalue)
        {
            Cache.Set(key, Tvalue);
        }

        public T Get<T>(object key)
        {
            var b = Cache.TryGetValue(key, out T value);
            return b ? value : default;
        }

        public void Remove(object key)
        {
            Cache.Remove(key);
        }
    }
}
