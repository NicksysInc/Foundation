// ----------------------------------------------------------------------------
// <copyright file="SqlQueryTranslator.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Data;
using System.Text;

namespace Nicksys.Foundation.Querying
{
    public class SqlQueryTranslator : QueryTranslator
    {
        public SqlQueryTranslator(Query query)
            : base(query)
        {
        }

        public override QueryString Translate()
        {
            var queryString = new QueryString();

            var queryOperator = GetQueryOperator(this.Query.Operator);
            var orderClause = new StringBuilder();
            var criteria = new StringBuilder();
            var select = new StringBuilder();

            // Build the SELECT
            select.Append("SELECT");
            select.Append(" ");

            if (Query.Members != null && Query.Members.Count > 0)
            {
                foreach (var member in this.Query.Members)
                {
                    select.Append(member);
                    select.Append(",");
                }
            }
            else
            {
                select.Append("* ");
            }

            queryString.Select = select.ToString().Remove(select.ToString().Length - 1) + " FROM [" + TableName + "] ";

            // Build the WHERE
            if (Query.Criteria != null && Query.Criteria.Count > 0)
            {
                Parameters = new SqlQueryParameter[Query.Criteria.Count];

                var i = 0;
                foreach (var c in this.Query.Criteria)
                {
                    criteria.Append(GetCriteriaOperator(c.Operator, c.PropertyName, i.ToString()));
                    criteria.Append(" ");
                    criteria.Append(queryOperator);
                    criteria.Append(" ");

                    Parameters[i] = CreateParameter(c, i.ToString());

                    i++;
                }

                if (criteria.ToString().TrimEnd().EndsWith(queryOperator))
                {
                    queryString.Where = "WHERE " + criteria.ToString().TrimEnd().Remove(criteria.ToString().Length - queryOperator.Length - 2);
                }
            }

            // Build the ORDER BY
            foreach (var oc in this.Query.OrderClauses)
            {
                orderClause.Append(oc.PropertyName);
                orderClause.Append(" ");
                orderClause.Append(GetOrderOperator(oc.OrderOperator));
                orderClause.Append(", ");
            }

            if (orderClause.ToString().TrimEnd().EndsWith(","))
            {
                queryString.OrderBy = "ORDER BY " + orderClause.ToString().Remove(orderClause.ToString().Length - 2);
            }

            return queryString;
        }

        public override string GetQueryOperator(QueryOperator queryOperator)
        {
            string result = null;

            switch (queryOperator)
            {
                case QueryOperator.And:
                    result = "AND";
                    break;
                case QueryOperator.Or:
                    result = "OR";
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
                    result = "asc";
                    break;
                case OrderOperator.Descending:
                    result = "desc";
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
                    result = property + " NOT NULL";
                    break;
                case CriteriaOperator.IsNull:
                    result = property + "IS NULL";
                    break;
                case CriteriaOperator.LesserThan:
                    result = property + "<" + @"@" + parameter;
                    break;
                case CriteriaOperator.LesserThanOrEqual:
                    result = property + "<=" + @"@" + parameter;
                    break;
                case CriteriaOperator.Like:
                    result = property + " LIKE '%" + @"@" + parameter + "%'";
                    break;
                case CriteriaOperator.LikeEnding:
                    result = property + " LIKE " + @"'@" + parameter + "%'";
                    break;
                case CriteriaOperator.LikeStarting:
                    result = property + " LIKE '%" + @"@" + parameter + "'";
                    break;
                case CriteriaOperator.NotEqual:
                    result = property + "!=" + @"@" + parameter;
                    break;
                case CriteriaOperator.NotLike:
                    result = property + " NOT LIKE" + @"@" + parameter;
                    break;
            }

            return result;
        }

        public string TableName { get; set; }

        public SqlQueryParameter[] Parameters { get; set; }

        private SqlQueryParameter CreateParameter(Criterion criterion, string parameterName)
        {
            SqlQueryParameter parameter = null;
            var dbType = DbType.String;

            switch (criterion.Type.Name)
            {
                case "Int16":
                    dbType = DbType.Int16;
                    break;
                case "Int":
                    dbType = DbType.Int32;
                    break;
                case "Int32":
                    dbType = DbType.Int32;
                    break;
                case "String":
                    dbType = DbType.String;
                    break;
                case "Guid":
                    dbType = DbType.Guid;
                    break;
                case "DateTime":
                    dbType = DbType.DateTime;
                    break;
            }

            parameter = new SqlQueryParameter(parameterName, criterion.Value, dbType);

            return parameter;
        }
    }
}
