// ----------------------------------------------------------------------------
// <copyright file="ILoggingProvider.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

namespace Nicksys.Foundation.Logging
{
    public interface ILoggingProvider
    {
        void Log(object message, LoggingLevel level, Exception exception, string source);
    }
}
