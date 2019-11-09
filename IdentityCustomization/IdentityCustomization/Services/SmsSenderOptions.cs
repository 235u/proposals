namespace IdentityCustomization.Services
{
    public sealed class SmsSenderOptions
    {        
        public string TwilioAccountSid { get; set; }

        public string TwilioAuthToken { get; set; }

        public string FromPhoneNumber { get; set; }
    }
}
