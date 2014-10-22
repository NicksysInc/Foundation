// ----------------------------------------------------------------------------
// <copyright file="FoundationDomainException.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

namespace Nicksys.Foundation.Domain
{
    [Serializable]
    public class FoundationDomainException<TDomainObject> : FoundationException where TDomainObject : DomainObject
    {
        public FoundationDomainException(TDomainObject domainObject) 
            : this(domainObject, null, null)
        {
        }

        public FoundationDomainException(TDomainObject domainObject, string message)
            : this(domainObject, message, null)
        {
        }

        public FoundationDomainException(TDomainObject domainObject, string message, Exception innerException)
            : base(message, innerException)
        {
            this.DomainObject = domainObject;
        }

        public TDomainObject DomainObject { get; private set; }
    }
}
