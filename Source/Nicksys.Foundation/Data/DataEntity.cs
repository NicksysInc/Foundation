// ----------------------------------------------------------------------------
// <copyright file="DataEntity.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

namespace Nicksys.Foundation.Data
{
    public abstract class DataEntity : IDataEntity
    {
        protected DataEntity()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.UtcNow;
        }

        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public override int GetHashCode()
        {
            if (Equals(Id, default(Guid)))
            {
                return base.GetHashCode();
            }

            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as DataEntity);
        }

        public virtual bool Equals(DataEntity other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (Equals(Id, other.Id))
            {
                var otherType = other.GetType();
                var thisType = GetType();

                return thisType.IsAssignableFrom(otherType) || otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        public static bool operator ==(DataEntity x, DataEntity y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(DataEntity x, DataEntity y)
        {
            return !(x == y);
        }
    }
}
