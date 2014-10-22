// ----------------------------------------------------------------------------
// <copyright file="DomainObject.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

namespace Nicksys.Foundation.Domain
{
    public abstract class DomainObject : IDomainObject
    {
        protected DomainObject()
        {
            this.CreateDate = DateTime.UtcNow;
        }

        public string Id { get; set; }

        public DateTime CreateDate { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as DomainObject);
        }

        public virtual bool Equals(DomainObject other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (Equals(Id, other.Id))
            {
                var otherType = other.GetType();
                var thisType = GetType();

                return thisType.IsAssignableFrom(otherType) || otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (Equals(Id, default(string)))
            {
                return base.GetHashCode();
            }

            return Id.GetHashCode();
        }

        public static bool operator ==(DomainObject x, DomainObject y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(DomainObject x, DomainObject y)
        {
            return !(x == y);
        }
    }
}
