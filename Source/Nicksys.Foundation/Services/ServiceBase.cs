// ----------------------------------------------------------------------------
// <copyright file="ServiceBase.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using Nicksys.Foundation.Caching;
using Nicksys.Foundation.Logging;

namespace Nicksys.Foundation.Services
{
    public abstract class ServiceBase : IService
    {
        protected ServiceBase()
        {
            CacheManagerFactory = DependencyManager.Current.Resolver.GetService<ICacheManagerFactory>();

            CacheManager = CacheManagerFactory.GetCacheManager();

            ActionContext = ActionContextFactory.GetActionContext();

            Logger = LoggerFactory.GetLoggerInstance();
        }

        public ICacheManagerFactory CacheManagerFactory { get; private set; }

        public ICacheManager CacheManager { get; private set; }

        public IActionContext ActionContext { get; private set; }

        public ILogger Logger { get; private set; }
    }
}
