// ----------------------------------------------------------------------------
// <copyright file="CommandValidationResult.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Commands
{
    public class CommandValidationResult : ICommandValidationResult
    {
        public CommandValidationResult()
        {
        }

        public CommandValidationResult(string errorMessage)
            : this(null, errorMessage)
        {
        }

        public CommandValidationResult(string memeberName, string errorMessage)
        {
            MemberName = memeberName;
            ErrorMessage = errorMessage;
        }

        public string MemberName { get; set; }

        public string ErrorMessage { get; set; }
    }
}
