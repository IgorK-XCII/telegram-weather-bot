using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.Models.Commands;

namespace TelegramBot.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;

        public static List<Command> Commands { get; } = CommandsRegistration.registrationList;

        public static async Task<TelegramBotClient> GetClient()
        {
            if (client != null) return client;

            client = new TelegramBotClient(AppSettings.Key);
            string hook = string.Format(AppSettings.Url, "api/message/update");
            await client.SetWebhookAsync(hook);

            return client;
        }
    }
}