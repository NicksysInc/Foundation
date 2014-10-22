// ----------------------------------------------------------------------------
// <copyright file="ICacheManager.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        void Set<T>(string key, T data, int cacheTime);

        bool IsSet(string key);

        void Remove(string key);

        void RemoveByPattern(string pattern);

        void Clear();
    }
}
