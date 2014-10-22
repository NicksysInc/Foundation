// ----------------------------------------------------------------------------
// <copyright file="LoggerFactory.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Logging
{
    public static class LoggerFactory
    {
        public static ILogger GetLoggerInstance()
        {
            var loggingProviderFactory = DependencyManager.Current.Resolver.GetService<ILoggingProviderFactory>();

            if (loggingProviderFactory == null)
            {
                throw new FoundationException("The ILoggingProviderFactory instance in null.");
            }

            var loggerConfigurationFactory = DependencyManager.Current.Resolver.GetService<ILoggerConfigurationFactory>() ??
                                             new LoggerConfigurationFactory();

            var logger = new Logger(loggingProviderFactory, loggerConfigurationFactory);

            return logger;
        }
    }
}
