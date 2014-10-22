// ----------------------------------------------------------------------------
// <copyright file="CommandDispatcherFactory.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Commands
{
    public class CommandDispatcherFactory
    {
        private readonly ICommandDispatcher _commandDispatcher = null;

        public CommandDispatcherFactory()
        {
            var commandDispatcher = DependencyManager.Current.Resolver.GetService<ICommandDispatcher>();

            if (commandDispatcher == null)
            {
                _commandDispatcher = new DefaultCommandDispatcher();
            }
        }

        public ICommandDispatcher GetCommandDispatcher()
        {
            return _commandDispatcher;
        }
    }
}
