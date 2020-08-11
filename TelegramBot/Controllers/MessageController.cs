using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Models;
using TelegramBot.Models.Commands;

namespace TelegramBot.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/update")]
        public async Task<OkResult> Update([FromBody] Update update)
        {
            List<Command> commands = Bot.Commands;
            Message message = update.Message;
            TelegramBotClient client = await Bot.GetClient();

            foreach(Command command in commands)
            {
                if (command.Contains(message.Text)) command.Execute(message, client);
            }

            return Ok();
        }
    }
}
