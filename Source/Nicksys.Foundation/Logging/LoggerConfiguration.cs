// ----------------------------------------------------------------------------
// <copyright file="LoggerConfiguration.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Logging
{
    public class LoggerConfiguration
    {
        public LoggerConfiguration()
        {
        }

        public bool IsLoggingEnabled { get; set; }

        public bool IsDebugEnabled { get; set; }

        public bool IsInfoEnabled { get; set; }

        public bool IsWarningEnabled { get; set; }

        public bool IsErrorEnabled { get; set; }

        public bool IsFatalEnabled { get; set; }

        public bool IsTraceEnabled { get; set; }

        public bool UseUtcDateTime { get; set; }

        public string DateTimeFormat { get; set; }
    }
}
