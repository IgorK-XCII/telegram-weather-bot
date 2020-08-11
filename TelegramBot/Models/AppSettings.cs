using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TelegramBot.Models
{
    public class AppSettings
    {
        public static string Url { get; set; } = "https://telegrambot.azurewebsites.net:443/{0}";

        public static string Name { get; set; } = "CurrentWeather_testBot_Bot";

        public static string Key { get; set; } = ConfigurationManager.AppSettings.Get("telegram-key");
    }
}