// ----------------------------------------------------------------------------
// <copyright file="LoggerConfigurationFactory.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Logging
{
    public class LoggerConfigurationFactory : ILoggerConfigurationFactory
    {
        private readonly LoggerConfiguration _loggerConfiguration;

        public LoggerConfigurationFactory()
        {
            _loggerConfiguration = new LoggerConfiguration()
            {
                DateTimeFormat = "yyyy-MMM-dd HH:mm:ss fff",
                IsDebugEnabled = false,
                IsErrorEnabled = true,
                IsFatalEnabled = true,
                IsInfoEnabled = false,
                IsLoggingEnabled = true,
                IsTraceEnabled = false,
                IsWarningEnabled = false,
                UseUtcDateTime = false
            };
        }
        public LoggerConfiguration GetLoggerConfiguration()
        {
            return _loggerConfiguration;
        }
    }
}
