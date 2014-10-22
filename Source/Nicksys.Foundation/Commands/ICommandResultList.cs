// ----------------------------------------------------------------------------
// <copyright file="ICommandResultList.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;

namespace Nicksys.Foundation.Commands
{
    public interface ICommandResultList
    {
        IList<ICommandResult> Results { get; }

        bool Success { get; }

        void AddResult(ICommandResult result);
    }
}
