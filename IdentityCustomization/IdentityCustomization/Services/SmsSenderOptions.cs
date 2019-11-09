namespace IdentityCustomization.Services
{
    public class SmsSenderOptions
    {        
        public string TwilioAccountSid { get; set; }

        public string TwilioAuthToken { get; set; }

        public string FromPhoneNumber { get; set; }
    }
}
