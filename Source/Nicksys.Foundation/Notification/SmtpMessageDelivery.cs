// ----------------------------------------------------------------------------
// <copyright file="SmtpMessageDelivery.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;
using System.Net.Mail;

namespace Nicksys.Foundation.Notification
{
    public class SmtpMessageDelivery : IMessageDelivery<SmtpNotificationMessage>
    {
        public SmtpMessageDelivery()
        {
        }

        public NotificationResult Send(SmtpNotificationMessage notificationMessage)
        {
            NotificationResult notificationResult = null;

            var mailMessage = new MailMessage(notificationMessage.Sender, notificationMessage.Recipient)
            {
                IsBodyHtml = true,
                Subject = notificationMessage.Subject,
                Body = notificationMessage.Body
            };

            var htmlAlternateView = AlternateView.CreateAlternateViewFromString(
                notificationMessage.Body, new System.Net.Mime.ContentType("text/html"));

            mailMessage.AlternateViews.Add(htmlAlternateView);

            using (var smtp = new SmtpClient())
            {
                try
                {
                    smtp.Send(mailMessage);
                    notificationResult = new NotificationResult();
                }
                catch (SmtpException ex)
                {
                    notificationResult = new NotificationResult(string.Format("SmtpException has occurred: {0}", ex.Message));
                }
                catch (Exception ex)
                {
                    notificationResult = new NotificationResult(string.Format("An error has occurred: {0}", ex.Message));
                }
            }

            return notificationResult;
        }
    }
}
