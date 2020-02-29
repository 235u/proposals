﻿using Microsoft.CognitiveServices.Speech;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace SpeechToText
{
    // Based on: https://github.com/Azure-Samples/cognitive-services-speech-sdk/blob/master/quickstart/csharp/dotnetcore/from-microphone
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Say something (into your microphone) within the next 15 seconds...");
            SpeechConfig config = CreateSpeechConfig();
            RecognizeSpeechAsync(config).Wait();            
        }
        
        private static async Task RecognizeSpeechAsync(SpeechConfig config)
        {            
            using (var recognizer = new SpeechRecognizer(config))
            {                
                var result = await recognizer.RecognizeOnceAsync();

                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                    Console.WriteLine($"Recognized: {result.Text}");
                }
                else if (result.Reason == ResultReason.NoMatch)
                {
                    Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                }
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(result);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                        Console.WriteLine($"CANCELED: Did you update the subscription info?");
                    }
                }
            }
        }

        private static SpeechConfig CreateSpeechConfig()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddUserSecrets(UnifiedSpeechServices.UserSecretsId)
                .Build();

            var services = UnifiedSpeechServices.FromConfiguration(configuration);
            return SpeechConfig.FromSubscription(services.FirstKey, services.Region);
        }
    }
}
