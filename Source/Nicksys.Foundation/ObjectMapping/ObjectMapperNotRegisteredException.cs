// ----------------------------------------------------------------------------
// <copyright file="ObjectMapperNotRegisteredException.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

namespace Nicksys.Foundation.ObjectMapping
{
    public class ObjectMapperNotRegisteredException : FoundationException
    {
        public ObjectMapperNotRegisteredException(Type source, Type destination)
            : base(string.Format("An object mapper has not been registered for source: '{0}', destination: '{1}'.", source, destination))
        {

        }
    }
}
