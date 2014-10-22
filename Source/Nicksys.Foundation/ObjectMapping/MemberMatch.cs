// ----------------------------------------------------------------------------
// <copyright file="MemberMatch.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Reflection;

namespace Nicksys.Foundation.ObjectMapping
{
    public class MemberMatch
    {
        public MemberMatch(MemberInfo source, MemberInfo destination)
        {
            SourceMember = source;
            DestinationMember = destination;
        }

        public MemberInfo SourceMember { get; set; }

        public MemberInfo DestinationMember { get; set; }
    }
}
