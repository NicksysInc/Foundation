// ----------------------------------------------------------------------------
// <copyright file="RepositoryBase.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;

using Nicksys.Foundation.Data;
using Nicksys.Foundation.Logging;
using Nicksys.Foundation.ObjectMapping;
using Nicksys.Foundation.Utils;

namespace Nicksys.Foundation.Domain
{
    public abstract class RepositoryBase<TDomainObject, TDataEntity> : IRepository<TDomainObject, TDataEntity>
        where TDomainObject : DomainObject, new()
        where TDataEntity : DataEntity, new() 
    {
        private readonly IDataContext _dataContext;

        private readonly ILogger _looger;

        protected RepositoryBase()
        {
            _dataContext = DependencyManager.Current.Resolver.GetService<IDataContext>();

            _looger = LoggerFactory.GetLoggerInstance();

            DomainModelToDataEntityMapper = new ObjectMapper<TDomainObject, TDataEntity>();
            DataEntityToDomainModelMapper = new ObjectMapper<TDataEntity, TDomainObject>();
        }

        public bool Create(TDomainObject domainObject)
        {
            var result = false;

            if (domainObject == null)
            {
                throw new DomainObjectIsNullException<TDomainObject>();
            }

            var dataEntity = ToDataEntity(domainObject);

            if (_dataContext.Add(dataEntity) != null)
            {
                result = true;
            }

            LastException = _dataContext.LastException;

            return result;
        }

        public bool Update(TDomainObject domainObject)
        {
            var result = false;

            if (domainObject == null)
            {
                throw new DomainObjectIsNullException<TDomainObject>();
            }

            var dataEntity = ToDataEntity(domainObject);

            if (_dataContext.Update(dataEntity) != null)
            {
                result = true;
            }

            LastException = _dataContext.LastException;

            return result;
        }

        public bool Delete(TDomainObject domainObject)
        {
            var result = false;

            if (domainObject == null)
            {
                throw new DomainObjectIsNullException<TDomainObject>();
            }

            var dataEntity = ToDataEntity(domainObject);
            
            _dataContext.Remove(dataEntity);

            result = (_dataContext.SaveChanges() > 0);

            LastException = _dataContext.LastException;

            return result;
        }

        public bool Delete(Expression<Func<TDomainObject, bool>> where)
        {
            var result = false;

            var objects = Table.Where<TDomainObject>(where).AsEnumerable();

            foreach (var domainObject in objects)
            {
                var dataEntity = ToDataEntity(domainObject);
                _dataContext.Remove(dataEntity);
            }

            result = (_dataContext.SaveChanges() > 0);

            LastException = _dataContext.LastException;

            return result;
        }

        public TDomainObject GetById(string id)
        {
            return Table.FirstOrDefault(x => x.Id == id);
        }

        public TDomainObject Get(Expression<Func<TDomainObject, bool>> where)
        {
            return Table.Where(where).FirstOrDefault<TDomainObject>();
        }

        public virtual TDomainObject ToDomainObject(TDataEntity dataEntity)
        {
            return DataEntityToDomainModelMapper.Explicit((entity, domain) => domain.Id = entity.Id.ToString()).Map(dataEntity);
        }

        public virtual TDataEntity ToDataEntity(TDomainObject domainObject)
        {
            return DomainModelToDataEntityMapper.Explicit((domain, entity) => entity.Id = domain.Id.ToGuid()).Map(domainObject);
        }

        public IQueryable<TDomainObject> Table
        {
            get
            {
                if (_dataContext != null)
                {
                    return _dataContext.GetTable<TDataEntity>().ToList().Select(x => ToDomainObject(x)).AsQueryable();
                }

                return null;
            }
        }

        public FoundationException LastException { get; private set; }


        public IObjectMapper<TDomainObject, TDataEntity> DomainModelToDataEntityMapper { get; private set; }

        public IObjectMapper<TDataEntity, TDomainObject> DataEntityToDomainModelMapper { get; private set; }
    }
}
