// ----------------------------------------------------------------------------
// <copyright file="PropertyMatch.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Reflection;

namespace Nicksys.Foundation.ObjectMapping
{
    public class PropertyMatch
    {
        public PropertyMatch(PropertyInfo sourceProp, PropertyInfo destinationProp)
        {
            SourceProperty = sourceProp;
            DestinationProperty = destinationProp;
        }

        public PropertyInfo SourceProperty { get; private set; }

        public PropertyInfo DestinationProperty { get; private set; }
    }
}
