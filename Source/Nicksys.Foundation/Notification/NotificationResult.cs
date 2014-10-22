// ----------------------------------------------------------------------------
// <copyright file="NotificationResult.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Notification
{
    public class NotificationResult
    {
        public NotificationResult()
        {
        }

        public NotificationResult(string error)
        {
            Error = error;
        }

        public string Error { get; private set; }

        public bool Success 
        {
            get { return string.IsNullOrEmpty(Error); } 
        }
    }
}
