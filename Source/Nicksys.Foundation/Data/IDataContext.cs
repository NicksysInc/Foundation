// ----------------------------------------------------------------------------
// <copyright file="IDataContext.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Linq;

using Nicksys.Foundation.Logging;

namespace Nicksys.Foundation.Data
{
    public interface IDataContext
    {
        ILogger Logger { get; }

        FoundationException LastException { get; }

        TDataEntity Add<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity, new();

        TDataEntity Update<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity, new();

        TDataEntity Remove<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity, new();

        IQueryable<TDataEntity> GetTable<TDataEntity>() where TDataEntity : DataEntity, new();

        int SaveChanges();
    }
}
