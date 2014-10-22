// ----------------------------------------------------------------------------
// <copyright file="ObjectMapper.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Nicksys.Foundation.ObjectMapping
{
    public class ObjectMapper : IObjectMapper
    {
        protected ObjectMapper()
        {
        }

        public ObjectMapper(Type sourceType, Type destinationType)
        {
            this.SourceType = sourceType;
            this.DestinationType = destinationType;

            BuildPropertyMatchList(sourceType, destinationType);
        }

        public Type SourceType { get; private set; }

        public Type DestinationType { get; private set; }


        public object Map(object sourceObject)
        {
            var destinationObject = Map(sourceObject, null);

            return destinationObject;
        }

        public object Map(object sourceObject, object destinationObject)
        {
            if (sourceObject == null)
            {
                throw new FoundationException("source object cannot be null.");
            }

            if (destinationObject == null)
            {
                destinationObject = Activator.CreateInstance(DestinationType);
            }

            foreach (var propertyMatch in PropertyMatchList)
            {
                var sourceVal = propertyMatch.SourceProperty.GetValue(sourceObject);
                propertyMatch.DestinationProperty.SetValue(destinationObject, sourceVal);
            }

            return destinationObject;
        }

        protected IList<PropertyMatch> PropertyMatchList { get; set; }

        protected void BuildPropertyMatchList(Type sourceType, Type destinationType)
        {
            PropertyMatchList = new List<PropertyMatch>();

            var sourceProps = sourceType.GetProperties();

            var destinationProps = destinationType.GetProperties();

            foreach (var sourceProp in sourceProps)
            {
                foreach (var destinationProp in destinationProps)
                {
                    if (sourceProp.Name.Equals(destinationProp.Name, StringComparison.InvariantCultureIgnoreCase) &&
                        sourceProp.PropertyType.Equals(destinationProp.PropertyType))
                    {
                        var propertyMatch = new PropertyMatch(sourceProp, destinationProp);

                        PropertyMatchList.Add(propertyMatch);
                    }
                }
            }
        }
    }

    public class ObjectMapper<TSource, TDestination> : ObjectMapper, IObjectMapper, IObjectMapper<TSource, TDestination>
        where TSource : class 
        where TDestination : new()
    {
        public ObjectMapper()
        {
            BuildPropertyMatchList(typeof(TSource), typeof(TDestination));
            ExplicitActions = new List<Action<TSource, TDestination>>();
        }

        protected IList<Action<TSource, TDestination>> ExplicitActions { get; set; }

        public TDestination Map(TSource source)
        {
            var destination = Map(source, default(TDestination));

            return destination;
        }

        public TDestination Map(TSource source, TDestination destination)
        {
            if (source == null)
            {
                throw new FoundationException("source object cannot be null.");
            }

            if (destination == null)
            {
                destination = new TDestination();
            }

            foreach (var propertyMatch in PropertyMatchList)
            {
                var sourceVal = propertyMatch.SourceProperty.GetValue(source);
                propertyMatch.DestinationProperty.SetValue(destination, sourceVal);
            }

            foreach (var explicitAction in ExplicitActions)
            {
                explicitAction(source, destination);
            }

            return destination;
        }

        public IEnumerable<TDestination> Map(IEnumerable<TSource> sources)
        {
            var destinations = new List<TDestination>();

            if (sources == null)
            {
                throw new FoundationException("sources cannot be null.");
            }

            foreach(var source in sources)
            {
                var destination = Map(source);

                if(destination != null)
                {
                    destinations.Add(destination);
                }
            }

            return destinations;
        }

        public virtual IObjectMapper<TSource, TDestination> Explicit(Action<TSource, TDestination> explicitAction)
        {
            ExplicitActions.Add(explicitAction);
            return this;
        }
    }
}
