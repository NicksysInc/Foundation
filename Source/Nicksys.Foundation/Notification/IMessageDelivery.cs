// ----------------------------------------------------------------------------
// <copyright file="IMessageDelivery.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Notification
{
    public interface IMessageDelivery<in TNotificationMessage> where TNotificationMessage : INotificationMessage
    {
        NotificationResult Send(TNotificationMessage notificationMessage);
    }
}
