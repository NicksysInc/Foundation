// ----------------------------------------------------------------------------
// <copyright file="CommandHandlerNotFoundException.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

namespace Nicksys.Foundation.Commands
{
    [Serializable]
    public class CommandHandlerNotFoundException : FoundationException
    {
        public CommandHandlerNotFoundException(Type type)
            : base(string.Format("Command handler not found for command type: {0}", type))
        {
        }
    }
}
