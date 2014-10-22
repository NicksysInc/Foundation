// ----------------------------------------------------------------------------
// <copyright file="ILoggingProviderFactory.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Logging
{
    public interface ILoggingProviderFactory
    {
        ILoggingProvider GetLoggingProvider();
    }
}
