// ----------------------------------------------------------------------------
// <copyright file="LoggingProviderFactory.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Logging
{
    public class LoggingProviderFactory : ILoggingProviderFactory
    {
        private readonly ILoggingProvider _loggingProvider;

        public LoggingProviderFactory()
        {
            _loggingProvider = DependencyManager.Current.Resolver.GetService<ILoggingProvider>();
        }

        public ILoggingProvider GetLoggingProvider()
        {
            return _loggingProvider;
        }
    }
}
