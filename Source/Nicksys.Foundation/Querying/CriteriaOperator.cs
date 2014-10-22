// ----------------------------------------------------------------------------
// <copyright file="CriteriaOperator.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Querying
{
    public enum CriteriaOperator
    {
        Equal = 0,
        NotEqual = 1,
        GreaterThan = 2,
        GreaterThanOrEqual = 3,
        LesserThan = 4,
        LesserThanOrEqual = 5,
        Like = 6,
        LikeStarting = 7,
        LikeEnding = 8,
        NotLike = 9,
        IsNull = 10,
        IsNotNull = 11
    }
}
