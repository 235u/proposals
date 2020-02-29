using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeechToText
{
    // See: https://docs.microsoft.com/en-us/azure/cognitive-services/speech-service/get-started#no-card
    public class UnifiedSpeechServices
    {
        public static readonly string UserSecretsId = "8db5ff65-0e5a-483b-bd76-8b63b9c71f34";

        public string Endpoint { get; set; } = "https://westus.api.cognitive.microsoft.com/sts/v1.0";

        public string Region => new Uri(Endpoint).Host.Split('.').First();

        public string FirstKey { get; set; } = string.Empty;

        public string SecondKey { get; set; } = string.Empty;

        public static UnifiedSpeechServices FromConfiguration(IConfiguration configuration)
        {
            return configuration.GetSection(nameof(UnifiedSpeechServices))
                .Get<UnifiedSpeechServices>();
        }
    }
}
