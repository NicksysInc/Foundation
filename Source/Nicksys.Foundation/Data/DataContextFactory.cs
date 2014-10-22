// ----------------------------------------------------------------------------
// <copyright file="DataContextFactory.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Data
{
    public class DataContextFactory
    {
        public static IDataContext GetDataContextInstance(string nameOrConnectionString)
        {
            var dataContext = DependencyManager.Current.Resolver.GetService<IDataContext>();

            return dataContext;
        }
    }
}
