// ----------------------------------------------------------------------------
// <copyright file="ICommandValidator.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;

namespace Nicksys.Foundation.Commands
{
    public interface ICommandValidator<in TCommand> where TCommand : ICommand
    {
        IList<ICommandValidationResult> Validate(TCommand command);
    }
}
