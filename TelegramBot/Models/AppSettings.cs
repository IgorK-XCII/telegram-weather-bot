using System.Configuration;

namespace TelegramBot.Models
{
    public class AppSettings
    {
        public static string Url { get; set; } = "https://telegrambot20200815160345.azurewebsites.net:443/{0}";

        public static string Name { get; set; } = "CurrentWeather_testBot_Bot";

        public static string Key { get; set; } = ConfigurationManager.AppSettings.Get("telegram-key");
    }
}