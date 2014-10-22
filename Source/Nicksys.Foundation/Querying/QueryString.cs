// ----------------------------------------------------------------------------
// <copyright file="QueryString.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Text;

namespace Nicksys.Foundation.Querying
{
    public class QueryString
    {
        public QueryString()
        {
        }

        public QueryString(string where, string orderBy, string select)
        {
            Where = where;
            OrderBy = orderBy;
            Select = select;
        }

        public string Where { get; set; }

        public string OrderBy { get; set; }

        public string Select { get; set; }
        
        public override string ToString()
        {
            var fullQuery = new StringBuilder();

            if (!string.IsNullOrEmpty(Select))
            {
                fullQuery.Append(Select);

                if (!string.IsNullOrEmpty(Where))
                {
                    fullQuery.Append(Where);
                }

                if (!string.IsNullOrEmpty(OrderBy))
                {
                    fullQuery.Append(OrderBy);
                }
            }

            return fullQuery.ToString();
        }
    }
}
