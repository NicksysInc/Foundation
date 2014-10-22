// ----------------------------------------------------------------------------
// <copyright file="ActionResult.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

using Nicksys.Foundation.Commands;

namespace Nicksys.Foundation.Services
{
    public class ActionResult<TCommand> : IActionResult<TCommand> where TCommand : ICommand
    {
        public ActionResult()
        {
        }

        public ActionResult(TCommand command, ICommandResult commandResult)
            : this(command, commandResult, null)
        {
        }

        public ActionResult(TCommand command, IList<ICommandValidationResult> validationResults)
            : this(command, null, validationResults)
        {
        }

        public ActionResult(TCommand command, ICommandResult commandResult, IList<ICommandValidationResult> validationResults)
        {
            Command = command;
            CommandResult = commandResult;
            ValidationResults = validationResults;
        }

        public TCommand Command { get; private set; }

        public ICommandResult CommandResult { get; private set; }

        public IList<ICommandValidationResult> ValidationResults { get; private set; }
        
        public bool Success
        {
            get 
            {
                return CommandResult != null && CommandResult.Success;
            }
        }

        public string ErrorMessage
        {
            get
            {
                if (ValidationResults != null && ValidationResults.Count > 0)
                {
                    return ValidationResults.FirstOrDefault().ErrorMessage;
                }

                return null;
            }
        }
    }
}
