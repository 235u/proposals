using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace IdentityCustomization.Services.Tests
{
    [TestClass]
    public class EmailSenderTests
    {
        [TestMethod]
        public async Task SendEmailAsync()
        {
            // Arrange
            var options = new EmailSenderOptions
            {
                SendGridApiKey = "<key>"
            };

            var sender = new EmailSender(options);

            // Act
            await sender.SendEmailAsync(
                email: "<to>",
                subject: nameof(EmailSenderTests),
                htmlMessage: "Hello, Identity Customization!");
        }
    }
}
