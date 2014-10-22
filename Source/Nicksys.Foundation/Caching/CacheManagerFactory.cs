// ----------------------------------------------------------------------------
// <copyright file="CacheManagerFactory.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Caching
{
    public class CacheManagerFactory : ICacheManagerFactory
    {
        private readonly ICacheManager _cacheManager;

        public CacheManagerFactory()
        {
            _cacheManager = DependencyManager.Current.Resolver.GetService<ICacheManager>() ?? new MemoryCacheManager();
        }

        public ICacheManager GetCacheManager()
        {
            return _cacheManager;
        }
    }
}
