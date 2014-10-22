// ----------------------------------------------------------------------------
// <copyright file="INotificationMessage.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

namespace Nicksys.Foundation.Notification
{
    public interface INotificationMessage
    {
        string Subject { get; set; }

        string Body { get; set; }
    }

    public interface INotificationMessage<TSender, TRecipient> : INotificationMessage
    {
        TSender Sender { get; set; }

        TRecipient Recipient { get; set; }
    }
}
