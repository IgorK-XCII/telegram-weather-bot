using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelegramBot.Models.Commands
{
    public static class CommandsRegistration
    {
        public static List<Command> registrationList { get; } = new List<Command> { new TodayWeatherCommand() };
    }
}