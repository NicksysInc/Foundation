// ----------------------------------------------------------------------------
// <copyright file="IDataEntity.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

namespace Nicksys.Foundation.Data
{
    public interface IDataEntity
    {
        Guid Id { get; set; }

        DateTime CreateDate { get; set; }
    }
}
