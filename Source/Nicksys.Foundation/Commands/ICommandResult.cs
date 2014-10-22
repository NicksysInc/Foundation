// ----------------------------------------------------------------------------
// <copyright file="ICommandResult.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Commands
{
    public interface ICommandResult
    {
        bool Success { get; }

        string Message { get; }
    }

    public interface ICommandResult<TResult> : ICommandResult
    {
        TResult Result { get; }

        void SetResult(TResult result);
    }
}
