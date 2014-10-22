// ----------------------------------------------------------------------------
// <copyright file="IScheduledAction.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using Nicksys.Foundation.Commands;

namespace Nicksys.Foundation.Services
{
    public interface IScheduledAction
    {
        ICommandDispatcher CommandDispatcher { get; }

        IActionResult Result { get; }

        void Execute();
    }
}
