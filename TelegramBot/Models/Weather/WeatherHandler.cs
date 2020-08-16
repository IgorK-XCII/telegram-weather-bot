using System.Threading.Tasks;

namespace TelegramBot.Models.APIs.Weather
{
    public static class WeatherHandler
    {
        public static IWeatherProvider WeatherProvider { get; set; }
        public static async Task<TodayWeather> GiveMeTodayWeather() => await WeatherProvider?.GiveMeTodayWeather();
        public static async Task<TodayWeather[]> GiveMeWeatherOnWeek() => await WeatherProvider?.GiveMeWeatherOnWeek();
    }
}