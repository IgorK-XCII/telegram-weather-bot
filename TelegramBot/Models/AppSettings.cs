using System.Configuration;

namespace TelegramBot.Models
{
    public class AppSettings
    {
        public static string Url { get; set; } = "https://telegrambotweatherscanner.azurewebsites.net:443/{0}";

        public static string Name { get; set; } = "WeatherScanner_bot";

        public static string Key { get; set; } = ConfigurationManager.AppSettings.Get("telegram-key");
    }
}