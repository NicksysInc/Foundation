// ----------------------------------------------------------------------------
// <copyright file="ObjectMapperFactory.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

namespace Nicksys.Foundation.ObjectMapping
{
    public static class ObjectMapperFactory
    {
        public static IObjectMapper<Source, Destination> CreateObjectMapper<Source, Destination>()
            where Destination : new()
            where Source : class
        {
            IObjectMapper<Source, Destination> newObjectMapper = new ObjectMapper<Source, Destination>();

            ObjectMappingContainer.RegisterMapper<Source, Destination>(newObjectMapper);

            return newObjectMapper;
        }

        public static IObjectMapper CreateObjectMapper(Type sourceType, Type destinationType)
        {
            var newObjectMapper = new ObjectMapper(sourceType, destinationType);

            ObjectMappingContainer.RegisterMapper(newObjectMapper, sourceType, destinationType);

            return newObjectMapper;
        }
    }
}
