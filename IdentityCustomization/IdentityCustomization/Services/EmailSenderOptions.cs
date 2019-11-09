namespace IdentityCustomization.Services
{
    public sealed class EmailSenderOptions
    {
        public string SendGridApiKey { get; set; }

        public string FromEmailAddress { get; set; } = "no-reply@identity.azurewebsites.net";
    }
}
