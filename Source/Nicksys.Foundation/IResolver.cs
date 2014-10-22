// ----------------------------------------------------------------------------
// <copyright file="IResolver.cs" company="Nicksys Inc.">
// Copyright (c) 2014 All Rights Reserved.
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Nicksys.Foundation
{
    public interface IResolver
    {
        object GetService(Type serviceType);

        IEnumerable<object> GetServices(Type serviceType);
    }
}
