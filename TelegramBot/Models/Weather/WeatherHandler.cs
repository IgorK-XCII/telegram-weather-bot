using System.Threading.Tasks;

namespace TelegramBot.Models.APIs.Weather
{
    public class WeatherHandler
    {
        public  IWeatherProvider WeatherProvider { get; set; }
        
        public async Task<TodayWeather> GiveMeTodayWeather() => await WeatherProvider?.GiveMeTodayWeather();
        public async Task<TodayWeather[]> GiveMeWeatherOnWeek() => await WeatherProvider?.GiveMeWeatherOnWeek();
    }
}