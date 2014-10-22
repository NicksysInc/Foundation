// ----------------------------------------------------------------------------
// <copyright file="DefaultCommandDispatcher.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;

namespace Nicksys.Foundation.Commands
{
    public class DefaultCommandDispatcher : ICommandDispatcher
    {
        public DefaultCommandDispatcher()
        {
        }

        public ICommandResult Submit<TCommand>(TCommand command) where TCommand : ICommand
        {
            ValidateResolver();

            var handler = GetCommandHandler<TCommand>();

            if (handler == null)
            {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }

            return handler.Execute(command);
        }

        public ICommandResult<TResult> Submit<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            ValidateResolver();

            var handler = GetCommandHandler<TCommand, TResult>();

            if (handler == null)
            {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }

            return handler.Execute(command);
        }

        public IList<ICommandValidationResult> Validate<TCommand>(TCommand command) where TCommand : ICommand
        {
            ValidateResolver();

            var validator = DependencyManager.Current.Resolver.GetService<ICommandValidator<TCommand>>();

            if (validator == null)
            {
                throw new ValidationHandlerNotFoundException(typeof(TCommand));
            }

            return validator.Validate(command);
        }

        public ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : ICommand
        {
            var handler = DependencyManager.Current.Resolver.GetService<ICommandHandler<TCommand>>();

            return handler;
        }

        public ICommandHandler<TCommand, TResult> GetCommandHandler<TCommand, TResult>() where TCommand : ICommand
        {
            var handler = DependencyManager.Current.Resolver.GetService<ICommandHandler<TCommand, TResult>>();

            return handler;
        }

        private void ValidateResolver()
        {
            if (DependencyManager.Current.Resolver == null)
            {
                throw new FoundationException("The DependencyManager.Current.Resolver cannot be null.");
            }
        }
    }
}
