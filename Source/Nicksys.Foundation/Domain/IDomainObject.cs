// ----------------------------------------------------------------------------
// <copyright file="IDomainObject.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

namespace Nicksys.Foundation.Domain
{
    public interface IDomainObject
    {
        string Id { get; set; }

        DateTime CreateDate { get; set; }
    }
}
