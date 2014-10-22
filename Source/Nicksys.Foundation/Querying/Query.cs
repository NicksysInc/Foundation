// ----------------------------------------------------------------------------
// <copyright file="Query.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;

namespace Nicksys.Foundation.Querying
{
    public class Query
    {
        public Query()
        {
            Criteria = new List<Criterion>();
            OrderClauses = new List<OrderClause>();
            Members = new List<string>();
        }

        public IList<Criterion> Criteria { get; private set; }
        
        public QueryOperator Operator { get; set; }

        public IList<OrderClause> OrderClauses { get; private set; }

        public IList<string> Members { get; private set; }
    }
}
