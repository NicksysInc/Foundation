// ----------------------------------------------------------------------------
// <copyright file="ILogger.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

namespace Nicksys.Foundation.Logging
{
    public interface ILogger
    {
        // Properties
        bool IsLoggingEnabled { get; }

        bool IsTraceEnabled { get; }

        bool IsInfoEnabled { get; }

        bool IsDebugEnabled { get; }

        bool IsWarningEnabled { get; }

        bool IsErrorEnabled { get; }

        bool IsFatalEnabled { get; }

        bool UseUtcDateTime { get; }

        string DateTimeFormat { get; }

        ILoggingProvider LoggingProvider { get; }

        ILoggingProviderFactory LoggingProviderFactory { get; }

        // Methods
        void Trace(object message);
        void Trace(object message, string source);
        void Trace(object message, Exception exception);
        void Trace(object message, Exception exception, string source);
        void TraceFormat(string format, params object[] args);
        void TraceFormat(string format, string source, params object[] args);
        void TraceFormat(string format, Exception exception, params object[] args);
        void TraceFormat(string format, Exception exception, string source, params object[] args);
        void TraceFormat(IFormatProvider formatProvider, string format, params object[] args);
        void TraceFormat(IFormatProvider formatProvider, string format, string source, params object[] args);
        void TraceFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args);
        void TraceFormat(IFormatProvider formatProvider, string format, Exception exception, string source, params object[] args);

        void Info(object message);
        void Info(object message, string source);
        void Info(object message, Exception exception);
        void Info(object message, Exception exception, string source);
        void InfoFormat(string format, params object[] args);
        void InfoFormat(string format, string source, params object[] args);
        void InfoFormat(string format, Exception exception, params object[] args);
        void InfoFormat(string format, Exception exception, string source, params object[] args);
        void InfoFormat(IFormatProvider formatProvider, string format, params object[] args);
        void InfoFormat(IFormatProvider formatProvider, string format, string source, params object[] args);
        void InfoFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args);
        void InfoFormat(IFormatProvider formatProvider, string format, Exception exception, string source, params object[] args);

        void Debug(object message);
        void Debug(object message, string source);
        void Debug(object message, Exception exception);
        void Debug(object message, Exception exception, string source);
        void DebugFormat(string format, params object[] args);
        void DebugFormat(string format, string source, params object[] args);
        void DebugFormat(string format, Exception exception, params object[] args);
        void DebugFormat(string format, Exception exception, string source, params object[] args);
        void DebugFormat(IFormatProvider formatProvider, string format, params object[] args);
        void DebugFormat(IFormatProvider formatProvider, string format, string source, params object[] args);
        void DebugFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args);
        void DebugFormat(IFormatProvider formatProvider, string format, Exception exception, string source, params object[] args);

        void Warning(object message);
        void Warning(object message, string source);
        void Warning(object message, Exception exception);
        void Warning(object message, Exception exception, string source);
        void WarningFormat(string format, params object[] args);
        void WarningFormat(string format, string source, params object[] args);
        void WarningFormat(string format, Exception exception, params object[] args);
        void WarningFormat(string format, Exception exception, string source, params object[] args);
        void WarningFormat(IFormatProvider formatProvider, string format, params object[] args);
        void WarningFormat(IFormatProvider formatProvider, string format, string source, params object[] args);
        void WarningFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args);
        void WarningFormat(IFormatProvider formatProvider, string format, Exception exception, string source, params object[] args);

        void Error(object message);
        void Error(object message, string source);
        void Error(object message, Exception exception);
        void Error(object message, Exception exception, string source);
        void ErrorFormat(string format, params object[] args);
        void ErrorFormat(string format, string source, params object[] args);
        void ErrorFormat(string format, Exception exception, params object[] args);
        void ErrorFormat(string format, Exception exception, string source, params object[] args);
        void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args);
        void ErrorFormat(IFormatProvider formatProvider, string format, string source, params object[] args);
        void ErrorFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args);
        void ErrorFormat(IFormatProvider formatProvider, string format, Exception exception, string source, params object[] args);

        void Fatal(object message);
        void Fatal(object message, string source);
        void Fatal(object message, Exception exception);
        void Fatal(object message, Exception exception, string source);
        void FatalFormat(string format, params object[] args);
        void FatalFormat(string format, string source, params object[] args);
        void FatalFormat(string format, Exception exception, params object[] args);
        void FatalFormat(string format, Exception exception, string source, params object[] args);
        void FatalFormat(IFormatProvider formatProvider, string format, params object[] args);
        void FatalFormat(IFormatProvider formatProvider, string format, string source, params object[] args);
        void FatalFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args);
        void FatalFormat(IFormatProvider formatProvider, string format, Exception exception, string source, params object[] args);
    }
}
