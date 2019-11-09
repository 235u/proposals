using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace IdentityCustomization.Services.Tests
{
    [TestClass]
    public class SmsSenderTests
    {
        [TestMethod]
        public async Task SendSmsAsync()
        {
            // Arrange
            var options = new SmsSenderOptions
            {
                TwilioAccountSid = "<sid>",
                TwilioAuthToken = "<token>",
                FromPhoneNumber = "<from>"
            };

            var sender = new SmsSender(options);

            // Act
            await sender.SendSmsAsync(number: "<to>", message: "Hello, Identity Customization!");
        }
    }
}
