// ----------------------------------------------------------------------------
// <copyright file="DataContextBase.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;
using System.Linq;

using Nicksys.Foundation.Logging;

namespace Nicksys.Foundation.Data
{
    public abstract class DataContextBase : IDataContext
    {
        protected DataContextBase()
        {
            if (Logger == null)
            {
                Logger = LoggerFactory.GetLoggerInstance();
            }
        }

        public ILogger Logger { get; private set; }

        public FoundationException LastException { get; protected set; }

        public virtual TDataEntity Add<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity, new()
        {
            throw new NotImplementedException();
        }

        public virtual TDataEntity Update<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity, new()
        {
            throw new NotImplementedException();
        }

        public virtual TDataEntity Remove<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity, new()
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TDataEntity> GetTable<TDataEntity>() where TDataEntity : DataEntity, new()
        {
            throw new NotImplementedException();
        }

        public virtual int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
