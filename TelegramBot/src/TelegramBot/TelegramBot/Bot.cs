using Telegram.Bot;

namespace TelegramBot
{
    public static class Bot
    {
        private const string AccessToken = "973215089:AAEeRjQyitO34BqCfAccdS2PiAswddMxwUc";

        public static readonly TelegramBotClient Api = new TelegramBotClient(AccessToken);
    }
}
