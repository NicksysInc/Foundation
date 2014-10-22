// ----------------------------------------------------------------------------
// <copyright file="NotificationManager.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Collections.Generic;

namespace Nicksys.Foundation.Notification
{
    public class NotificationManager : INotificationManager
    {
        public NotificationManager()
        {
            MessageDeliveries = new List<IMessageDelivery<INotificationMessage>>();
        }

        public IList<IMessageDelivery<INotificationMessage>> MessageDeliveries { get; private set; }

        public void AddMessageDelivery<TMessageDelivery>(TMessageDelivery messageDelivery) 
            where TMessageDelivery : IMessageDelivery<INotificationMessage>
        {
            MessageDeliveries.Add(messageDelivery);
        }

        public IList<NotificationResult> Submit(INotificationMessage notificationMessage)
        {
            IList<NotificationResult> notificationResults = new List<NotificationResult>();
            
            if(MessageDeliveries == null)
            {
                return null;
            }

            foreach(var messageDelivery in MessageDeliveries)
            {
                NotificationResult notificationResult = messageDelivery.Send(notificationMessage);
                notificationResults.Add(notificationResult);
            }

            return notificationResults;
        }
    }
}
