// ----------------------------------------------------------------------------
// <copyright file="IActionContext.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

using Nicksys.Foundation.Commands;

namespace Nicksys.Foundation.Services
{
    public interface IActionContext : IDisposable
    {
        bool IsInTransaction { get; }

        bool IsDirty { get; }

        ScheduledActionList Actions { get; }

        ActionResultList ActionResults { get; }

        void ProcessCommand<TCommand>(TCommand command) where TCommand : ICommand;

        void ProcessCommand<TCommand,TResult>(TCommand command) where TCommand : ICommand;

        void ManageAction<TCommand>(ScheduledAction<TCommand> scheduledAction) where TCommand : ICommand;

        void ManageAction<TCommand, TResult>(ScheduledAction<TCommand, TResult> scheduledAction) where TCommand : ICommand;

        void BeginTransaction();

        void Commit(bool stopOnError = true);

        void Rollback();

        void Clear();
    }
}
