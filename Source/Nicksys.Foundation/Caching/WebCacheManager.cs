// ----------------------------------------------------------------------------
// <copyright file="WebCacheManager.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;

namespace Nicksys.Foundation.Caching
{
    public class WebCacheManager : ICacheManager
    {
        private const int DefaultSlidingExpirationInDays = 30;

        private readonly HttpContextBase _httpContext;
        private readonly int _slidingExpirationInDays = 0;

        public WebCacheManager(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
            _slidingExpirationInDays = DefaultSlidingExpirationInDays;
        }

        public WebCacheManager(HttpContextBase httpContext, int slidingExpirationInDays)
        {
            _httpContext = httpContext;
            _slidingExpirationInDays = slidingExpirationInDays;
        }

        protected Cache Cache
        {
            get { return HttpRuntime.Cache; }
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public void Set<T>(string key, T data, int cacheTime)
        {
            Cache.Insert(key, data, null, Cache.NoAbsoluteExpiration, TimeSpan.FromDays(_slidingExpirationInDays));
        }

        public bool IsSet(string key)
        {
            return (Cache.Get(key) != null);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();

            var cacheEnum = Cache.GetEnumerator();

            while (cacheEnum.MoveNext())
            {
                if (regex.IsMatch(cacheEnum.Key.ToString()))
                {
                    keysToRemove.Add(cacheEnum.Key.ToString());
                }
            }

            foreach (var key in keysToRemove)
            {
                Remove(key);
            }
        }

        public void Clear()
        {
            var keys = new List<string>();

            var enumerator = Cache.GetEnumerator();

            while (enumerator.MoveNext())
            {
                keys.Add(enumerator.Key.ToString());
            }

            foreach (string key in keys)
            {
                Cache.Remove(key);
            }
        }
    }
}
