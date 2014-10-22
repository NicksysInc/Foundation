// ----------------------------------------------------------------------------
// <copyright file="QueryParameter.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Querying
{
    public class QueryParameter
    {
        public QueryParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }

        public object Value { get; set; }
    }
}
