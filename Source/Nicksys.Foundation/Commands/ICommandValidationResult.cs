// ----------------------------------------------------------------------------
// <copyright file="ICommandValidationResult.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Commands
{
    public interface ICommandValidationResult
    {
        string MemberName { get; set; }

        string ErrorMessage { get; set; }
    }
}
