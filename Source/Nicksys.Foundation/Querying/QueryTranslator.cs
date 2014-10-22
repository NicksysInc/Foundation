// ----------------------------------------------------------------------------
// <copyright file="QueryTranslator.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;

namespace Nicksys.Foundation.Querying
{
    public abstract class QueryTranslator
    {
        protected QueryTranslator(Query query)
        {
            Query = query;
            Values = new List<string>();

            foreach (var criterion in Query.Criteria)
            {
                Values.Add(criterion.Value.ToString());
            }
        }

        public Query Query { get; private set; }

        public IList<string> Values { get; protected set; }

        public abstract QueryString Translate();

        public abstract string GetQueryOperator(QueryOperator queryOperator);

        public abstract string GetOrderOperator(OrderOperator orderOperator);

        public abstract string GetCriteriaOperator(CriteriaOperator criteriaOperator, string property, string parameter);
    }
}
