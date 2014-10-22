// ----------------------------------------------------------------------------
// <copyright file="QueryContext.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

using Nicksys.Foundation.Data;
using Nicksys.Foundation.Domain;
using Nicksys.Foundation.ObjectMapping;

namespace Nicksys.Foundation.Querying
{
    public class QueryContext<TDomainObject, TDataEntity> : IQueryContext<TDomainObject, TDataEntity>
        where TDomainObject : DomainObject, new()
        where TDataEntity : DataEntity, new()
    {
        public QueryContext()
        {
            this.Repository = GetRepository();

            this.ObjectMapper = ObjectMapperFactory.CreateObjectMapper<TDataEntity, TDomainObject>();
        }

        public TDomainObject GetById(string id)
        {
            var domainObject = this.Repository.GetById(id);

            return domainObject;
        }

        public IEnumerable<TDomainObject> GetAll()
        {
            var list = this.Repository.Table.ToList<TDomainObject>();
            
            return list;
        }

        public IEnumerable<TDomainObject> GetAll(int pageIndex, int pageSize)
        {
            var list = this.Repository.Table.Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable<TDomainObject>();

            return list;
        }

        public IEnumerable<TDomainObject> GetByCriteria(Query query)
        {
            var list = default(IEnumerable<TDomainObject>);

            return list;
        }

        public IEnumerable<TDomainObject> GetByCriteria(Query query, int pageIndex, int pageSize)
        {
            var list = default(IEnumerable<TDomainObject>);

            return list;
        }

        public int GetCount()
        {
            return this.Repository.Table.Count();
        }

        public int GetCount(Query query)
        {
            return GetByCriteria(query).Count();
        }

        public IRepository<TDomainObject, TDataEntity> GetRepository()
        {
            return Repository = DependencyManager.Current.Resolver.GetService<IRepository<TDomainObject, TDataEntity>>();
        }

        public IRepository<TDomainObject, TDataEntity> Repository { get; private set; }

        public IObjectMapper<TDataEntity, TDomainObject> ObjectMapper { get; private set; }
    }
}
