using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Models;
using TelegramBot.Models.Commands;

namespace TelegramBot.Controllers
{
    [Route("api/message/update")]
    public class MessageController : ApiController
    {
        [HttpPost]
        public async Task<OkResult> Update([FromBody] Update update)
        {
            if (update is null) return Ok();

            List<Command> commands = Bot.Commands;
            Message message = update.Message;
            TelegramBotClient client = await Bot.GetClient();

            foreach(Command command in commands)
            {
                if (command.Contains(message.Text))
                {
                    await command.Execute(message, client);
                    break;
                }
            }

            return Ok();
        }
    }
}
