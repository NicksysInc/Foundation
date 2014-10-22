// ----------------------------------------------------------------------------
// <copyright file="ListExtensions.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;

namespace Nicksys.Foundation.Utils
{
    public static class ListExtensions
    {
        public static IList<T> AddRange<T>(this IList<T> list, IEnumerable<T> range)
        {
            foreach (var r in range)
            {
                list.Add(r);
            }

            return list;
        }
    }
}
