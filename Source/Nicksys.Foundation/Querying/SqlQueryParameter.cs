// ----------------------------------------------------------------------------
// <copyright file="SqlQueryParameter.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Data;

namespace Nicksys.Foundation.Querying
{
    public class SqlQueryParameter : QueryParameter
    {
        public SqlQueryParameter(string name, object value, DbType dbType)
            : base(name, value)
        {
            DbType = dbType;
        }

        public DbType DbType { get; set; }
    }
}
