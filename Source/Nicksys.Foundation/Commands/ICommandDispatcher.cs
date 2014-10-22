// ----------------------------------------------------------------------------
// <copyright file="ICommandDispatcher.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;

namespace Nicksys.Foundation.Commands
{
    public interface ICommandDispatcher
    {
        ICommandResult Submit<TCommand>(TCommand command) where TCommand : ICommand;

        ICommandResult<TResult> Submit<TCommand, TResult>(TCommand command) where TCommand : ICommand;

        IList<ICommandValidationResult> Validate<TCommand>(TCommand command) where TCommand : ICommand;

        ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : ICommand;

        ICommandHandler<TCommand, TResult> GetCommandHandler<TCommand, TResult>() where TCommand : ICommand;
    }
}
