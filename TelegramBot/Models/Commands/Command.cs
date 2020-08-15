using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Models.Commands
{
    public abstract class Command
    {
        public abstract string CommandName { get; }

        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Contains(string command) => command.Contains(CommandName) && command.Contains(AppSettings.Name);
    }
}