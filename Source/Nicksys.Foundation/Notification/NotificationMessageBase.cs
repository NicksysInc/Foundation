// ----------------------------------------------------------------------------
// <copyright file="NotificationMessageBase.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Notification
{
    public class NotificationMessageBase<TSender, TRecipient> : INotificationMessage<TSender, TRecipient>
    {
        public NotificationMessageBase()
        {
        }

        public NotificationMessageBase(TSender sender, TRecipient recipient, string subject, string body)
        {
            Sender = sender;
            Recipient = recipient;
            Subject = subject;
            Body = body;
        }

        public TSender Sender { get; set; }

        public TRecipient Recipient { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
