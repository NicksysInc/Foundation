// ----------------------------------------------------------------------------
// <copyright file="SmtpNotificationMessage.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System.Net.Mail;

namespace Nicksys.Foundation.Notification
{
    public class SmtpNotificationMessage : NotificationMessageBase<MailAddress, MailAddress>
    {
        public SmtpNotificationMessage(MailAddress sender, MailAddress recipient, string subject, string body)
            : base(sender, recipient, subject, body)
        {
        }
    }
}
