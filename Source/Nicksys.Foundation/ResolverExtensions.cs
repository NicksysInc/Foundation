// ----------------------------------------------------------------------------
// <copyright file="ResolverExtensions.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Nicksys.Foundation
{
    internal static class ResolverExtensions
    {
        public static TService GetService<TService>(this IResolver resolver)
        {
            if (resolver == null)
            {
                throw new FoundationException("The IResolver parameter cannot be null!");
            }

            return (TService)resolver.GetService(typeof(TService));
        }

        public static IEnumerable<TService> GetServices<TService>(this IResolver resolver)
        {
            if (resolver == null)
            {
                throw new FoundationException("The IResolver parameter cannot be null!");
            }

            return resolver.GetServices(typeof(TService)).Cast<TService>();
        }
    }
}
