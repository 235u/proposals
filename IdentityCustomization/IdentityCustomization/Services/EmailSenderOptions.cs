namespace IdentityCustomization.Services
{
    public class EmailSenderOptions
    {
        public string SendGridApiKey { get; set; }

        public string FromEmailAddress { get; set; } = "no-reply@identity.azurewebsites.net";
    }
}
