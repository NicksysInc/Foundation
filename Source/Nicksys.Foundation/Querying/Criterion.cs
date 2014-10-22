// ----------------------------------------------------------------------------
// <copyright file="Criterion.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

namespace Nicksys.Foundation.Querying
{
    public class Criterion
    {
        public Criterion()
        {
        }

        public Criterion(string propertyName, CriteriaOperator criteriaOperator, object value, Type type)
            : this()
        {
            PropertyName = propertyName;
            Value = value;
            Operator = criteriaOperator;
            Type = type;
        }

        public string PropertyName { get; set; }

        public object Value { get; set; }
        
        public CriteriaOperator Operator { get; set; }

        public Type Type { get; set; }
    }
}
