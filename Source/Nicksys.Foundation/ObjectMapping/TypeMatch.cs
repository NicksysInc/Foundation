// ----------------------------------------------------------------------------
// <copyright file="TypeMatch.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

namespace Nicksys.Foundation.ObjectMapping
{
    public class TypeMatch
    {
        public Type Source;
        public Type Destination;

        public TypeMatch(Type source, Type destination)
        {
            Source = source;
            Destination = destination;
        }

        public override bool Equals(object obj)
        {
            if ((object)obj == null)
            {
                return false;
            }

            if (!obj.GetType().Equals(this.GetType()))
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            var converted = obj as TypeMatch;

            if ((converted.Source.Equals(this.Source)) && (converted.Destination.Equals(this.Destination)))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Source.GetHashCode() ^ Destination.GetHashCode();
        }
    }
}
