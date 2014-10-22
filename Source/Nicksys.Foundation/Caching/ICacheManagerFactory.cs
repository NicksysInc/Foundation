// ----------------------------------------------------------------------------
// <copyright file="ICacheManagerFactory.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Caching
{
    public interface ICacheManagerFactory
    {
        ICacheManager GetCacheManager();
    }
}
