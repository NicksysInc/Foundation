// ----------------------------------------------------------------------------
// <copyright file="MemoryCacheManager.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;
using System.Linq;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace Nicksys.Foundation.Caching
{
    public class MemoryCacheManager : ICacheManager
    {
        public MemoryCacheManager()
        {
        }

        protected ObjectCache Cache
        {
            get { return MemoryCache.Default; }
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public void Set<T>(string key, T data, int cacheTime)
        {
            Set(key, data, cacheTime);
        }

        public void Set(string key, object data, int cacheTime)
        {
            if (data == null)
            {
                return;
            }

            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime) };
            Cache.Add(new CacheItem(key, data), policy);
        }

        public bool IsSet(string key)
        {
            return (Cache.Contains(key));
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            
            var keysToRemove = (from item in Cache where regex.IsMatch(item.Key) select item.Key).ToList();

            foreach (var key in keysToRemove)
            {
                Remove(key);
            }
        }

        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }
    }
}
