// ----------------------------------------------------------------------------
// <copyright file="DomainObjectIsNullException.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Domain
{
    public class DomainObjectIsNullException<TDomainObject> : FoundationDomainException<TDomainObject> where TDomainObject : DomainObject
    {
        public DomainObjectIsNullException()
            : base(null, string.Format("The domain object of type [{0}] is null!", typeof(TDomainObject).Name))
        {
        }
    }
}
