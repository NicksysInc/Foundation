// ----------------------------------------------------------------------------
// <copyright file="Logger.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

namespace Nicksys.Foundation.Logging
{
    public sealed class Logger : ILogger
    {
        public Logger(ILoggingProviderFactory loggingProviderFactory, ILoggerConfigurationFactory loggerConfigurationFactory)
        {
            LoggingProviderFactory = loggingProviderFactory;
            LoggingProvider = LoggingProviderFactory.GetLoggingProvider();

            LoggerConfigurationFactory = loggerConfigurationFactory;
            LoggerConfiguration = LoggerConfigurationFactory.GetLoggerConfiguration();

            IsLoggingEnabled = LoggerConfiguration.IsLoggingEnabled;
            IsTraceEnabled = LoggerConfiguration.IsTraceEnabled;
            IsInfoEnabled = LoggerConfiguration.IsInfoEnabled;
            IsDebugEnabled = LoggerConfiguration.IsDebugEnabled;
            IsWarningEnabled = LoggerConfiguration.IsWarningEnabled;
            IsErrorEnabled = LoggerConfiguration.IsErrorEnabled;
            IsFatalEnabled = LoggerConfiguration.IsFatalEnabled;
            UseUtcDateTime = LoggerConfiguration.UseUtcDateTime;
            DateTimeFormat = LoggerConfiguration.DateTimeFormat;
        }

        #region Properties

        public bool IsLoggingEnabled { get; private set; }

        public bool IsTraceEnabled { get; private set; }

        public bool IsInfoEnabled { get; private set; }

        public bool IsDebugEnabled { get; private set; }

        public bool IsWarningEnabled { get; private set; }

        public bool IsErrorEnabled { get; private set; }

        public bool IsFatalEnabled { get; private set; }

        public bool UseUtcDateTime { get; private set; }

        public string DateTimeFormat { get; private set; }

        public ILoggingProvider LoggingProvider { get; internal set; }

        public ILoggingProviderFactory LoggingProviderFactory { get; internal set; }

        public ILoggerConfigurationFactory LoggerConfigurationFactory { get; internal set; }

        public LoggerConfiguration LoggerConfiguration { get; internal set; }

        #endregion

        #region Trace Methods

        public void Trace(object message)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Trace, null, null);
            }
        }

        public void Trace(object message, string source)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Trace, null, source);
            }
        }

        public void Trace(object message, Exception exception)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Trace, exception, null);
            }
        }

        public void Trace(object message, Exception exception, string source)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Trace, exception, source);
            }
        }

        public void TraceFormat(string format, params object[] args)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Trace, null, null);
            }
        }

        public void TraceFormat(string format, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Trace, null, source);
            }
        }

        public void TraceFormat(string format, Exception exception, params object[] args)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Trace, exception, null);
            }
        }

        public void TraceFormat(string format, Exception exception, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Trace, exception, source);
            }
        }

        public void TraceFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Trace, null, null);
            }
        }

        public void TraceFormat(IFormatProvider formatProvider, string format, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Trace, null, source);
            }
        }

        public void TraceFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Trace, exception,
                    null);
            }
        }

        public void TraceFormat(IFormatProvider formatProvider, string format, Exception exception, string source,
            params object[] args)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Trace, exception,
                    source);
            }
        }

        #endregion

        #region Info Methods

        public void Info(object message)
        {
            if (IsLoggingEnabled && IsInfoEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Info, null, null);
            }
        }

        public void Info(object message, string source)
        {
            if (IsLoggingEnabled && IsInfoEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Info, null, source);
            }
        }

        public void Info(object message, Exception exception)
        {
            if (IsLoggingEnabled && IsInfoEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Info, exception, null);
            }
        }

        public void Info(object message, Exception exception, string source)
        {
            if (IsLoggingEnabled && IsInfoEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Info, exception, source);
            }
        }

        public void InfoFormat(string format, params object[] args)
        {
            if (IsLoggingEnabled && IsInfoEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Info, null, null);
            }
        }

        public void InfoFormat(string format, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsInfoEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Info, null, source);
            }
        }

        public void InfoFormat(string format, Exception exception, params object[] args)
        {
            if (IsLoggingEnabled && IsInfoEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Info, exception, null);
            }
        }

        public void InfoFormat(string format, Exception exception, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsInfoEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Info, exception, source);
            }
        }

        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsLoggingEnabled && IsInfoEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Info, null, null);
            }
        }

        public void InfoFormat(IFormatProvider formatProvider, string format, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsInfoEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Info, null, source);
            }
        }

        public void InfoFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            if (IsLoggingEnabled && IsInfoEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Info, exception,
                    null);
            }
        }

        public void InfoFormat(IFormatProvider formatProvider, string format, Exception exception, string source,
            params object[] args)
        {
            if (IsLoggingEnabled && IsInfoEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Info, exception,
                    source);
            }
        }

        #endregion

        #region Debug Methods

        public void Debug(object message)
        {
            if (IsLoggingEnabled && IsDebugEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Debug, null, null);
            }
        }

        public void Debug(object message, string source)
        {
            if (IsLoggingEnabled && IsDebugEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Debug, null, source);
            }
        }

        public void Debug(object message, Exception exception)
        {
            if (IsLoggingEnabled && IsDebugEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Debug, exception, null);
            }
        }

        public void Debug(object message, Exception exception, string source)
        {
            if (IsLoggingEnabled && IsDebugEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Debug, exception, source);
            }
        }

        public void DebugFormat(string format, params object[] args)
        {
            if (IsLoggingEnabled && IsDebugEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Debug, null, null);
            }
        }

        public void DebugFormat(string format, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsDebugEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Debug, null, source);
            }
        }

        public void DebugFormat(string format, Exception exception, params object[] args)
        {
            if (IsLoggingEnabled && IsDebugEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Debug, exception, null);
            }
        }

        public void DebugFormat(string format, Exception exception, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsDebugEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Debug, exception, source);
            }
        }

        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsLoggingEnabled && IsDebugEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Debug, null, null);
            }
        }

        public void DebugFormat(IFormatProvider formatProvider, string format, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsDebugEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Debug, null, source);
            }
        }

        public void DebugFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            if (IsLoggingEnabled && IsDebugEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Debug, exception,
                    null);
            }
        }

        public void DebugFormat(IFormatProvider formatProvider, string format, Exception exception, string source,
            params object[] args)
        {
            if (IsLoggingEnabled && IsDebugEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Debug, exception,
                    source);
            }
        }

        #endregion

        #region Warning Methods

        public void Warning(object message)
        {
            if (IsLoggingEnabled && IsWarningEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Warning, null, null);
            }
        }

        public void Warning(object message, string source)
        {
            if (IsLoggingEnabled && IsWarningEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Warning, null, source);
            }
        }

        public void Warning(object message, Exception exception)
        {
            if (IsLoggingEnabled && IsWarningEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Warning, exception, null);
            }
        }

        public void Warning(object message, Exception exception, string source)
        {
            if (IsLoggingEnabled && IsWarningEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Warning, exception, source);
            }
        }

        public void WarningFormat(string format, params object[] args)
        {
            if (IsLoggingEnabled && IsWarningEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Warning, null, null);
            }
        }

        public void WarningFormat(string format, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsWarningEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Warning, null, source);
            }
        }

        public void WarningFormat(string format, Exception exception, params object[] args)
        {
            if (IsLoggingEnabled && IsWarningEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Warning, exception, null);
            }
        }

        public void WarningFormat(string format, Exception exception, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsWarningEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Warning, exception, source);
            }
        }

        public void WarningFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsLoggingEnabled && IsWarningEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Warning, null, null);
            }
        }

        public void WarningFormat(IFormatProvider formatProvider, string format, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsWarningEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Warning, null,
                    source);
            }
        }

        public void WarningFormat(IFormatProvider formatProvider, string format, Exception exception,
            params object[] args)
        {
            if (IsLoggingEnabled && IsWarningEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Warning, exception,
                    null);
            }
        }

        public void WarningFormat(IFormatProvider formatProvider, string format, Exception exception, string source,
            params object[] args)
        {
            if (IsLoggingEnabled && IsWarningEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Warning, exception,
                    source);
            }
        }

        #endregion

        #region Error Methods

        public void Error(object message)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Error, null, null);
            }
        }

        public void Error(object message, string source)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Error, null, source);
            }
        }

        public void Error(object message, Exception exception)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Error, exception, null);
            }
        }

        public void Error(object message, Exception exception, string source)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Error, exception, source);
            }
        }

        public void ErrorFormat(string format, params object[] args)
        {
            if (IsLoggingEnabled && IsErrorEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Error, null, null);
            }
        }

        public void ErrorFormat(string format, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsErrorEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Error, null, source);
            }
        }

        public void ErrorFormat(string format, Exception exception, params object[] args)
        {
            if (IsLoggingEnabled && IsErrorEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Error, exception, null);
            }
        }

        public void ErrorFormat(string format, Exception exception, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsErrorEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Error, exception, source);
            }
        }

        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsLoggingEnabled && IsErrorEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Error, null, null);
            }
        }

        public void ErrorFormat(IFormatProvider formatProvider, string format, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsErrorEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Error, null, source);
            }
        }

        public void ErrorFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            if (IsLoggingEnabled && IsErrorEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Error, exception,
                    null);
            }
        }

        public void ErrorFormat(IFormatProvider formatProvider, string format, Exception exception, string source,
            params object[] args)
        {
            if (IsLoggingEnabled && IsTraceEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Error, exception,
                    source);
            }
        }

        #endregion

        #region Fatal Methods

        public void Fatal(object message)
        {
            if (IsLoggingEnabled && IsFatalEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Fatal, null, null);
            }
        }

        public void Fatal(object message, string source)
        {
            if (IsLoggingEnabled && IsFatalEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Fatal, null, source);
            }
        }

        public void Fatal(object message, Exception exception)
        {
            if (IsLoggingEnabled && IsFatalEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Fatal, exception, null);
            }
        }

        public void Fatal(object message, Exception exception, string source)
        {
            if (IsLoggingEnabled && IsFatalEnabled)
            {
                LoggingProvider.Log(message, LoggingLevel.Fatal, exception, source);
            }
        }

        public void FatalFormat(string format, params object[] args)
        {
            if (IsLoggingEnabled && IsFatalEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Fatal, null, null);
            }
        }

        public void FatalFormat(string format, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsFatalEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Fatal, null, source);
            }
        }

        public void FatalFormat(string format, Exception exception, params object[] args)
        {
            if (IsLoggingEnabled && IsFatalEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Fatal, exception, null);
            }
        }

        public void FatalFormat(string format, Exception exception, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsFatalEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(null, format, args), LoggingLevel.Fatal, exception, source);
            }
        }

        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsLoggingEnabled && IsFatalEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Fatal, null, null);
            }
        }

        public void FatalFormat(IFormatProvider formatProvider, string format, string source, params object[] args)
        {
            if (IsLoggingEnabled && IsFatalEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Fatal, null, source);
            }
        }

        public void FatalFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            if (IsLoggingEnabled && IsFatalEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Fatal, exception,
                    null);
            }
        }

        public void FatalFormat(IFormatProvider formatProvider, string format, Exception exception, string source,
            params object[] args)
        {
            if (IsLoggingEnabled && IsFatalEnabled)
            {
                LoggingProvider.Log(new MessageFormatter(formatProvider, format, args), LoggingLevel.Fatal, exception,
                    source);
            }
        }

        #endregion
    }
}
