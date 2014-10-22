// ----------------------------------------------------------------------------
// <copyright file="INotificationManager.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;

namespace Nicksys.Foundation.Notification
{
    public interface INotificationManager
    {
        IList<IMessageDelivery<INotificationMessage>> MessageDeliveries { get; }

        void AddMessageDelivery<TMessageDelivery>(TMessageDelivery messageDelivery) 
            where TMessageDelivery : IMessageDelivery<INotificationMessage>;

        IList<NotificationResult> Submit(INotificationMessage notificationMessage);
    }
}
