// ----------------------------------------------------------------------------
// <copyright file="ScheduledAction.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using Nicksys.Foundation.Commands;

namespace Nicksys.Foundation.Services
{
    public abstract class ScheduledAction : IScheduledAction
    {
        protected ScheduledAction()
        {
            CommandDispatcher = DependencyManager.Current.Resolver.GetService<ICommandDispatcher>();
        }

        public ICommandDispatcher CommandDispatcher { get; protected set; }

        public IActionResult Result { get; protected set; }

        public abstract void Execute();
    }

    public class ScheduledAction<TCommand> : ScheduledAction where TCommand : ICommand
    {
        public ScheduledAction(TCommand command)
        {
            Command = command;
        }

        public TCommand Command { get; private set; }

        public override void Execute()
        {
            ICommandResult commandResult = null;

            var validationResults = CommandDispatcher.Validate<TCommand>(Command);

            if (validationResults == null || validationResults.Count == 0)
            {
                commandResult = CommandDispatcher.Submit<TCommand>(Command);
            }
            else
            {
                commandResult = new CommandResult(false);
            }

            Result = new ActionResult<TCommand>(Command, commandResult, validationResults);
        }
    }

    public class ScheduledAction<TCommand, TResult> : ScheduledAction where TCommand : ICommand
    {
        public ScheduledAction(TCommand command)
        {
            Command = command;
        }

        public TCommand Command { get; private set; }

        public ICommandResult<TResult> CommandResult { get; private set; }

        public override void Execute()
        {
            var validationResults = CommandDispatcher.Validate<TCommand>(Command);

            if (validationResults == null || validationResults.Count == 0)
            {
                CommandResult = CommandDispatcher.Submit<TCommand, TResult>(Command);
            }
            else
            {
                CommandResult = new CommandResult<TResult>(false);
            }

            Result = new ActionResult<TCommand>(Command, CommandResult, validationResults);
        }
    }
}
