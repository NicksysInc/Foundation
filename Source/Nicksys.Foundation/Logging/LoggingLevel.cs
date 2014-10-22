// ----------------------------------------------------------------------------
// <copyright file="LoggingLevel.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Logging
{
    public enum LoggingLevel
    {
        /// <summary>
        /// The DEBUG Level designates fine-grained informational events that are most useful to debug an application. 
        /// </summary>
        Debug = 1,

        /// <summary>
        /// The INFO level designates informational messages that highlight the progress of the application at coarse-grained level. 
        /// </summary>
        Info = 2,

        /// <summary>
        /// The WARN level designates potentially harmful situations. 
        /// </summary>
        Warning = 3,

        /// <summary>
        /// The ERROR level designates error events that might still allow the application to continue running.
        /// </summary>
        Error = 4,

        /// <summary>
        /// The TRACE Level designates finer-grained informational events than the DEBUG 
        /// </summary>
        Trace = 5,

        /// <summary>
        /// The FATAL level designates very severe error events that will presumably lead the application to abort. 
        /// </summary>
        Fatal = 6,

        /// <summary>
        /// The VERBOSE Level has the lowest possible rank and is intended to turn on all logging. 
        /// </summary>
        Verbose = 7, // means all

        /// <summary>
        /// The UNDEFINED Level has the highest possible rank and is intended to turn off logging.
        /// </summary>
        Undefined = 8
    }
}
