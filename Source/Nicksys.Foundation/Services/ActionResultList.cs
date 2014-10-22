// ----------------------------------------------------------------------------
// <copyright file="ActionResultList.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

using Nicksys.Foundation.Commands;
using Nicksys.Foundation.Utils;

namespace Nicksys.Foundation.Services
{
    public class ActionResultList
    {
        public ActionResultList()
        {
            ActionResults = new List<IActionResult>();
            ValidationResults = new List<ICommandValidationResult>();
            CommandResults = new List<ICommandResult>();
        }

        public void AddActionResult(IActionResult actionResult)
        {
            ActionResults.Add(actionResult);
            ValidationResults.AddRange(actionResult.ValidationResults);
            CommandResults.Add(actionResult.CommandResult);
        }

        public bool Success { get { return !ValidationResults.Any(); } }

        public IList<IActionResult> ActionResults { get; private set; }

        public IList<ICommandValidationResult> ValidationResults { get; private set; }

        public IList<ICommandResult> CommandResults { get; private set; }

        public IActionResult<TCommand> GetActionResult<TCommand>(TCommand command) where TCommand : ICommand
        {
            IActionResult<TCommand> actionResult = null;

            foreach (var result in ActionResults)
            {
                var resultType = result.GetType();
                
                if (resultType.IsGenericType)
                {
                    var typeArguments = resultType.GetGenericArguments();

                    if (typeof (TCommand) == typeArguments[0])
                    {
                        actionResult = result as IActionResult<TCommand>;
                    }
                }
            }

            return actionResult;
        }

        public ICommandResult<TResult> GetCommandResult<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            ICommandResult<TResult> commandResult = null;

            var actionResult = GetActionResult(command);
            
            if (actionResult != null)
            {
                commandResult = actionResult.CommandResult as ICommandResult<TResult>;
            }

            return commandResult;
        }

        public ICommandResult GetCommandResult<TCommand>(TCommand command) where TCommand : ICommand
        {
            ICommandResult commandResult = null;

            var actionResult = GetActionResult(command);

            if (actionResult != null)
            {
                commandResult = actionResult.CommandResult;
            }

            return commandResult;
        }
    }
}
