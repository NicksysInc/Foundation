// ----------------------------------------------------------------------------
// <copyright file="IServiceResult.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;

using Nicksys.Foundation.Commands;

namespace Nicksys.Foundation.Services
{
    public interface IServiceResult<TReturnResult>
    {
        IEnumerable<ICommandValidationResult> ValidationResults { get; }

        IEnumerable<ICommandResult> CommandResults { get; }

        TReturnResult ReturnResult { get; }

        string ReturnMessage { get; }

        ActionResultList ActionResults { get; }

        bool Success { get; }

        void SetReturnResult(TReturnResult returnResult);

        void SetReturnMessage(string returnMessage);

        void AddValidationResult(ICommandValidationResult validationResult);

        void AddValidationResults(IEnumerable<ICommandValidationResult> validationResults);

        void AddCommandResult(ICommandResult commandResult);

        void AddCommandResults(IEnumerable<ICommandResult> commandResults);

        IEnumerable<string> GetErrorMessages();

        string GetFirstErrorMessage();
    }
}
