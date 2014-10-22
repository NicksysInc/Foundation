// ----------------------------------------------------------------------------
// <copyright file="FoundationDataException.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

namespace Nicksys.Foundation.Data
{
    [Serializable]
    public class FoundationDataException<TDataEntity> : FoundationException where TDataEntity : DataEntity
    {
        public FoundationDataException(TDataEntity dataEntity) 
            : this(dataEntity, null, null)
        {
        }

        public FoundationDataException(TDataEntity dataEntity, string message) 
            : this(dataEntity, message, null)
        {
        }

        public FoundationDataException(TDataEntity dataEntity, string message, Exception innerException)
            : base(message, innerException)
        {
            this.DataEntity = dataEntity;
        }

        public TDataEntity DataEntity { get; private set; }
    }
}
