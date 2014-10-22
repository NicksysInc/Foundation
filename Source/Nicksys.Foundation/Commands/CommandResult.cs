// ----------------------------------------------------------------------------
// <copyright file="CommandResult.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success)
            : this(success, null)
        {
        }

        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; protected set; }

        public string Message { get; protected set; }
    }

    public class CommandResult<TResult> : ICommandResult, ICommandResult<TResult>
    {
        public CommandResult(bool success)
            : this(success, null)
        {
        }

        public CommandResult(bool success, string message)
            : this(success, message, default(TResult))
        {
        }

        public CommandResult(bool success, TResult result)
            : this(success, string.Empty, result)
        {
        }

        public CommandResult(bool success, string message, TResult result)
        {
            Success = success;
            Message = message;
            Result = result;
        }

        public bool Success { get; protected set; }

        public string Message { get; protected set; }

        public TResult Result { get; protected set; }

        public void SetResult(TResult result)
        {
            Result = result;
        }
    }
}
