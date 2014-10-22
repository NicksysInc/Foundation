// ----------------------------------------------------------------------------
// <copyright file="ActionContextFactory.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Services
{
    public class ActionContextFactory
    {
        public static IActionContext GetActionContext()
        {
            var actionContext = DependencyManager.Current.Resolver.GetService<IActionContext>() ?? new ActionContext();

            return actionContext;
        }
    }
}
