// ----------------------------------------------------------------------------
// <copyright file="ActionContext.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Linq;
using System.Transactions;

using Nicksys.Foundation.Commands;

namespace Nicksys.Foundation.Services
{
    public sealed class ActionContext : IActionContext
    {
        public ActionContext()
        {
            Actions = new ScheduledActionList();
            ActionResults = new ActionResultList();
        }

        public bool IsInTransaction { get; private set; }

        public bool IsDirty { get; private set; }

        public ScheduledActionList Actions { get; private set; }

        public ActionResultList ActionResults { get; private set; }

        /// <summary>
        /// This is used either to execute a single command or it can be used with 
        /// this.BeginTransaction, process all actions, this.Commit
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="command"></param>
        public void ProcessCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new FoundationException("The command object cannot be null. You cannot process the command if it is null!");
            }

            var scheduledAction = new ScheduledAction<TCommand>(command);
            ManageAction<TCommand>(scheduledAction);
        }

        public void ProcessCommand<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new FoundationException("The command object cannot be null. You cannot process the command if it is null!");
            }

            var scheduledAction = new ScheduledAction<TCommand, TResult>(command);
            ManageAction<TCommand, TResult>(scheduledAction);
        }

        public void ManageAction<TCommand>(ScheduledAction<TCommand> scheduledAction) where TCommand : ICommand
        {
            if (IsInTransaction)
            {
                // Add action to the list
                Actions.AddAction<TCommand>(scheduledAction);
                IsDirty = true;
            }
            else
            {
                // Execute the single action
                scheduledAction.Execute();
                ActionResults.AddActionResult(scheduledAction.Result);
            }
        }

        public void ManageAction<TCommand, TResult>(ScheduledAction<TCommand, TResult> scheduledAction) where TCommand : ICommand
        {
            if (IsInTransaction)
            {
                // Add action to the list
                Actions.AddAction<TCommand, TResult>(scheduledAction);
                IsDirty = true;
            }
            else
            {
                // Execute the single action
                scheduledAction.Execute();
                ActionResults.AddActionResult(scheduledAction.Result);
            }
        }

        public void BeginTransaction()
        {
            if (IsInTransaction)
            {
                throw new FoundationException("A transaction is already opened");
            }
            
            IsInTransaction = true;
        }

        public void Commit(bool stopOnError = true)
        {
            if (!IsInTransaction)
            {
                throw new FoundationException("This operation requires an opened transaction");
            }
            
            using (var transaction = new TransactionScope())
            {
                if (Actions != null)
                {
                    foreach (var scheduledAction in Actions.Actions)
                    {
                        scheduledAction.Execute();
                        ActionResults.AddActionResult(scheduledAction.Result);

                        if (!scheduledAction.Result.Success)
                        {
                            break;
                        }
                    }

                    // This should be called only if all ScheduledActions have no errors;
                    if (!ActionResults.ValidationResults.Any())
                    {
                        transaction.Complete();
                    }
                }
            }
        }

        public void Rollback()
        {
            if (!IsInTransaction)
            {
                throw new FoundationException("This operation requires an opened transaction");
            }
            
            IsInTransaction = false;

            Clear();
        }

        public void Dispose()
        {
            if (IsInTransaction)
            {
                Rollback();
            }
        }

        public void Clear()
        {
            Actions.Actions.Clear();

            ActionResults.ActionResults.Clear();

            ActionResults.ValidationResults.Clear();

            IsDirty = false;
        }
    }
}
