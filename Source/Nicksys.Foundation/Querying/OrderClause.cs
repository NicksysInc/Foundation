// ----------------------------------------------------------------------------
// <copyright file="OrderClause.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Querying
{
    public class OrderClause
    {
        public OrderClause()
        {
        }

        public OrderClause(string propertyName, OrderOperator orderOperator)
        {
            PropertyName = propertyName;
            OrderOperator = orderOperator;
        }

        public string PropertyName { get; set; }
        
        public OrderOperator OrderOperator { get; set; }
    }
}
