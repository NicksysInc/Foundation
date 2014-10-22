// ----------------------------------------------------------------------------
// <copyright file="DataEntityIsNullException.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Data
{
    public class DataEntityIsNullException<TDataEntity> : FoundationDataException<TDataEntity> where TDataEntity : DataEntity
    {
        public DataEntityIsNullException()
            : base(null, string.Format("The data entity of type [{0}] is null!", typeof(TDataEntity).Name))
        {
        }
    }
}
