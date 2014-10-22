// ----------------------------------------------------------------------------
// <copyright file="IActionResult.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;

using Nicksys.Foundation.Commands;

namespace Nicksys.Foundation.Services
{
    public interface IActionResult
    {
        ICommandResult CommandResult { get; }

        IList<ICommandValidationResult> ValidationResults { get; }

        bool Success { get; }

        string ErrorMessage { get; }
    }

    public interface IActionResult<TCommand> : IActionResult where TCommand : ICommand
    {
        TCommand Command { get; }
    }
}
