using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace IdentityCustomization.Services
{
    public sealed class SmsSender
    {
        public SmsSender(IOptions<SmsSenderOptions> options)
            : this(options.Value)
        {
        }

        public SmsSender(SmsSenderOptions options)
        {
            Options = options;
        }

        public SmsSenderOptions Options { get; }

        public Task SendSmsAsync(string number, string message)
        {
            TwilioClient.Init(Options.TwilioAccountSid, Options.TwilioAuthToken);
            return MessageResource.CreateAsync(
                to: new PhoneNumber(number), from: new PhoneNumber(Options.FromPhoneNumber), body: message);
        }
    }
}
