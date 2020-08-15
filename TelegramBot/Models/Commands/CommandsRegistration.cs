using System.Collections.Generic;

namespace TelegramBot.Models.Commands
{
    public static class CommandsRegistration
    {
        public static List<Command> registrationList { get; } = new List<Command> { new TodayWeatherCommand() };
    }
}