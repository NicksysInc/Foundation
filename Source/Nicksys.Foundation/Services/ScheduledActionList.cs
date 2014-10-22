// ----------------------------------------------------------------------------
// <copyright file="ScheduledActionList.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;

using Nicksys.Foundation.Commands;

namespace Nicksys.Foundation.Services
{
    public class ScheduledActionList
    {
        public ScheduledActionList()
        {
            Actions = new List<IScheduledAction>();
        }

        public void AddAction<TCommand>(ScheduledAction<TCommand> action) where TCommand : ICommand
        {
            Actions.Add(action);
        }

        public void AddAction<TCommand, TResult>(ScheduledAction<TCommand, TResult> action) where TCommand : ICommand
        {
            Actions.Add(action);
        }

        public IList<IScheduledAction> Actions { get; private set; }
    }
}
