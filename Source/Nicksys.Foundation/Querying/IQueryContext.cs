// ----------------------------------------------------------------------------
// <copyright file="IQueryContext.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;

using Nicksys.Foundation.Data;
using Nicksys.Foundation.Domain;

namespace Nicksys.Foundation.Querying
{
    public interface IQueryContext<TDomainObject, TDataEntity>
        where TDomainObject : DomainObject, new()
        where TDataEntity : DataEntity, new()
    {
        TDomainObject GetById(string id);

        IEnumerable<TDomainObject> GetAll();

        IEnumerable<TDomainObject> GetAll(int pageIndex, int pageSize);

        IEnumerable<TDomainObject> GetByCriteria(Query query);

        IEnumerable<TDomainObject> GetByCriteria(Query query, int pageIndex, int pageSize);

        int GetCount();

        int GetCount(Query query);

        IRepository<TDomainObject, TDataEntity> Repository { get; }

        IRepository<TDomainObject, TDataEntity> GetRepository();

        //IObjectMapper<TDataEntity, TDomainObject> ObjectMapper { get; }

        //IObjectMapperFactory ObjectMapperFactory { get; }
    }
}
