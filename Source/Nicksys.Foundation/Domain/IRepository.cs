// ----------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;

using Nicksys.Foundation.Data;
using Nicksys.Foundation.ObjectMapping;

namespace Nicksys.Foundation.Domain
{
    public interface IRepository<TDomainObject, TDataEntity>
        where TDomainObject : DomainObject, new()
        where TDataEntity : DataEntity, new() 
    {
        bool Create(TDomainObject domainObject);

        bool Update(TDomainObject domainObject);

        bool Delete(TDomainObject domainObject);

        bool Delete(Expression<Func<TDomainObject, bool>> where);

        TDomainObject GetById(string id);

        TDomainObject Get(Expression<Func<TDomainObject, bool>> where);

        TDomainObject ToDomainObject(TDataEntity dataEntity);

        TDataEntity ToDataEntity(TDomainObject domainObject);

        IQueryable<TDomainObject> Table { get; }

        FoundationException LastException { get; }

        IObjectMapper<TDomainObject, TDataEntity> DomainModelToDataEntityMapper { get; }

        IObjectMapper<TDataEntity, TDomainObject> DataEntityToDomainModelMapper { get; }

    }
}
