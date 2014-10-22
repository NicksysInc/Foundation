// ----------------------------------------------------------------------------
// <copyright file="ILoggerConfigurationFactory.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Logging
{
    public interface ILoggerConfigurationFactory
    {
        LoggerConfiguration GetLoggerConfiguration();
    }
}
