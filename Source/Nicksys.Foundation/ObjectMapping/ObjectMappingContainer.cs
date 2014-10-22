// ----------------------------------------------------------------------------
// <copyright file="ObjectMappingContainer.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Nicksys.Foundation.ObjectMapping
{
    public static class ObjectMappingContainer
    {
        private static readonly object lockObject = new object();
        private static IDictionary<TypeMatch, IObjectMapper> mappers = new Dictionary<TypeMatch, IObjectMapper>();

        public static void RegisterMapper(IObjectMapper objectMapper, Type sourceType, Type destinationType)
        {
            var typeMatch = new TypeMatch(sourceType, destinationType);

            lock (lockObject)
            {
                if (!mappers.ContainsKey(typeMatch))
                {
                    mappers.Add(typeMatch, objectMapper);
                }
            }
        }

        public static IObjectMapper RetrieveMapper(Type sourceType, Type destinationType)
        {
            var searchTypeMatch = new TypeMatch(sourceType, destinationType);

            IObjectMapper existingObjectMapper = null;

            lock (lockObject)
            {
                if (!mappers.ContainsKey(searchTypeMatch))
                {
                    throw new ObjectMapperNotRegisteredException(sourceType, destinationType);
                }

                existingObjectMapper = mappers[searchTypeMatch] as IObjectMapper;
            }

            return existingObjectMapper;
        }

        public static void RegisterMapper<Source, Destination>(IObjectMapper<Source, Destination> objectMapper)
            where Destination : new()
            where Source : class
        {
            var typeMatch = new TypeMatch(typeof(Source), typeof(Destination));

            lock (lockObject)
            {
                if (!mappers.ContainsKey(typeMatch))
                {
                    //throw new ObjectMapperAlreadyRegisteredException(typeof(Source), typeof(Destination));
                    mappers.Add(new TypeMatch(typeof(Source), typeof(Destination)), objectMapper);
                }
            }
        }

        public static IObjectMapper<Source, Destination> RetrieveMapper<Source, Destination>()
            where Destination : new()
            where Source : class
        {
            var searchTypeMatch = new TypeMatch(typeof(Source), typeof(Destination));

            IObjectMapper<Source, Destination> existingObjectMapper = null;

            lock (lockObject)
            {
                if (!mappers.ContainsKey(searchTypeMatch))
                {
                    throw new ObjectMapperNotRegisteredException(typeof(Source), typeof(Destination));
                }

                existingObjectMapper = mappers[searchTypeMatch] as IObjectMapper<Source, Destination>;
            }

            return existingObjectMapper;
        }

        public static void ClearMappers()
        {
            lock (lockObject)
            {
                mappers.Clear();
            }
        }
    }
}
