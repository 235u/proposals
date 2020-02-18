using System;
using System.Threading.Tasks;
using System.Web.Http;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.Controllers
{
    public class BotController : ApiController
    {
        public async Task<IHttpActionResult> Post(Update update)
        {
            var message = update.Message;

            Console.WriteLine("Received Message from {0}", message.Chat.Id);

            if (message.Type == MessageType.Text)
            {
                // echo each message
                await Bot.Api.SendTextMessageAsync(message.Chat.Id, message.Text);
            }
            else
            {
                await Bot.Api.SendTextMessageAsync(message.Chat.Id, "Nix wissen");
            }

            return Ok();
        }
    }
}
