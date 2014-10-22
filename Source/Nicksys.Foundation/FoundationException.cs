// ----------------------------------------------------------------------------
// <copyright file="FoundationException.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace Nicksys.Foundation
{
    [Serializable]
    public class FoundationException : Exception
    {
        private const string ExceptionMessage = "Nicksys Foundation Exception: {0}";

        public FoundationException()
        {
        }

        public FoundationException(string message)
            : base(string.Format(ExceptionMessage, message))
        {
        }

        public FoundationException(string message, Exception innerException)
            : base(string.Format(ExceptionMessage, message), innerException)
        {
        }

        protected FoundationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
