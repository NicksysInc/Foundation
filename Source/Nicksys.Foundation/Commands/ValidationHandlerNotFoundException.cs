// ----------------------------------------------------------------------------
// <copyright file="ValidationHandlerNotFoundException.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

namespace Nicksys.Foundation.Commands
{
    [Serializable]
    public class ValidationHandlerNotFoundException : FoundationException
    {
        public ValidationHandlerNotFoundException(Type type)
            : base(string.Format("Validation handler not found for command type: {0}", type))
        {
        }
    }
}
