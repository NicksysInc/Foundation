// ----------------------------------------------------------------------------
// <copyright file="LinqQueryTranslator.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Text;

namespace Nicksys.Foundation.Querying
{
    public class LinqQueryTranslator : QueryTranslator
    {
        public LinqQueryTranslator(Query query)
            : base(query)
        {
        }

        public override QueryString Translate()
        {
            var queryString = new QueryString();
            
            var queryOperator = GetQueryOperator(this.Query.Operator);
            var orderClause = new StringBuilder();
            var criteria = new StringBuilder();

            // Build the where
            var i = 0;
            foreach (var c in this.Query.Criteria)
            {
                criteria.Append(GetCriteriaOperator(c.Operator, c.PropertyName, i.ToString()));
                criteria.Append(" ");
                criteria.Append(queryOperator);
                criteria.Append(" ");
                i++;
            }

            if (criteria.ToString().TrimEnd().EndsWith(queryOperator))
            {
                queryString.Where = criteria.ToString().TrimEnd().Remove(criteria.ToString().Length - queryOperator.Length - 2);
            }

            // Build the order by
            foreach (var oc in this.Query.OrderClauses)
            {
                orderClause.Append(oc.PropertyName);
                orderClause.Append(" ");
                orderClause.Append(oc.OrderOperator.ToString().ToLower());
                orderClause.Append(", ");
            }

            if (orderClause.ToString().TrimEnd().EndsWith(","))
            {
                queryString.OrderBy = orderClause.ToString().Remove(orderClause.ToString().Length - 2);
            }

            return queryString;
        }

        public override string GetQueryOperator(QueryOperator queryOperator)
        {
            var result = string.Empty;

            switch (queryOperator)
            {
                case QueryOperator.And:
                    result = "and";
                    break;
                case QueryOperator.Or:
                    result = "or";
                    break;
            }

            return result;
        }

        public override string GetOrderOperator(OrderOperator orderOperator)
        {
            string result = null;

            switch (orderOperator)
            {
                case OrderOperator.Ascending:
                    result = "ascending";
                    break;
                case OrderOperator.Descending:
                    result = "descending";
                    break;
            }

            return result;
        }

        public override string GetCriteriaOperator(CriteriaOperator criteriaOperator, string property, string parameter)
        {
            string result = null;

            switch (criteriaOperator)
            {
                case CriteriaOperator.Equal:
                    result = property + "=" + @"@" + parameter;
                    break;
                case CriteriaOperator.GreaterThan:
                    result = property + ">" + @"@" + parameter;
                    break;
                case CriteriaOperator.GreaterThanOrEqual:
                    result = property + ">=" + @"@" + parameter;
                    break;
                case CriteriaOperator.IsNotNull:
                    result = property + "!=null";
                    break;
                case CriteriaOperator.IsNull:
                    result = property + "==null";
                    break;
                case CriteriaOperator.LesserThan:
                    result = property + "<" + @"@" + parameter;
                    break;
                case CriteriaOperator.LesserThanOrEqual:
                    result = property + "<=" + @"@" + parameter;
                    break;
                case CriteriaOperator.Like:
                    result = property + ".Contains(" + @"@" + parameter + ")";
                    break;
                case CriteriaOperator.LikeEnding:
                    result = property + ".EndsWith(" + @"@" + parameter + ")";
                    break;
                case CriteriaOperator.LikeStarting:
                    result = property + ".StartsWith(" + @"@" + parameter + ")";
                    break;
                case CriteriaOperator.NotEqual:
                    result = property + "!=" + @"@" + parameter;
                    break;
                case CriteriaOperator.NotLike:
                    result = "!" + property + ".Contains(" + @"@" + parameter + ")";
                    break;
            }

            return result;
        }
    }
}
