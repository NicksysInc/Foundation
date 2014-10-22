// ----------------------------------------------------------------------------
// <copyright file="IService.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using Nicksys.Foundation.Caching;
using Nicksys.Foundation.Logging;

namespace Nicksys.Foundation.Services
{
    public interface IService
    {
        ICacheManagerFactory CacheManagerFactory { get; }

        ICacheManager CacheManager { get; }

        IActionContext ActionContext { get; }

        ILogger Logger { get; }
    }
}
