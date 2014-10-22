// ----------------------------------------------------------------------------
// <copyright file="SingleObjectMappingContainer.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Nicksys.Foundation.ObjectMapping
{
    public static class SingleObjectMappingContainer
    {
        private static readonly object LockObject = new object();
        private static readonly IDictionary<Type, IObjectMapper> Mappers = new Dictionary<Type, IObjectMapper>();

        public static void RegisterMapper<TSource, TDestination>(IObjectMapper<TSource, TDestination> objectMapper)
            where TDestination : new()
            where TSource : class
        {
            var sourceType = typeof(TSource);

            lock (LockObject)
            {
                if (Mappers.ContainsKey(sourceType))
                {
                    throw new ObjectMapperAlreadyRegisteredException(typeof(TSource), typeof(TDestination));
                }

                Mappers.Add(typeof(TSource), objectMapper);
            }
        }

        public static IObjectMapper<TSource, TDestination> RetrieveMapper<TSource, TDestination>()
            where TDestination : new()
            where TSource : class
        {
            var searchTypeMatch = typeof(TSource);

            IObjectMapper<TSource, TDestination> existingObjectMapper;

            lock (LockObject)
            {
                if (!Mappers.ContainsKey(searchTypeMatch))
                {
                    throw new ObjectMapperNotRegisteredException(typeof(TSource), typeof(TDestination));
                }

                existingObjectMapper = Mappers[searchTypeMatch] as IObjectMapper<TSource, TDestination>;
            }

            return existingObjectMapper;
        }
    }
}
