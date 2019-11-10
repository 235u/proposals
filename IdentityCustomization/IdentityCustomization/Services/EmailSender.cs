using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace IdentityCustomization.Services
{
    public sealed class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<EmailSenderOptions> options)
            : this(options.Value)
        {
        }

        public EmailSender(EmailSenderOptions options)
        {
            Options = options;
        }

        public EmailSenderOptions Options { get; }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(Options.SendGridApiKey);
            SendGridMessage message = CreateMessage(email, subject, htmlMessage);
            Response response = await client.SendEmailAsync(message);
            if (response.StatusCode != HttpStatusCode.Accepted)
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        private SendGridMessage CreateMessage(string email, string subject, string htmlMessage)
        {
            var message = new SendGridMessage
            {
                From = new EmailAddress(Options.FromEmailAddress),
                Subject = subject,
                HtmlContent = htmlMessage,
            };

            message.AddTo(new EmailAddress(email));
            return message;
        }
    }
}
