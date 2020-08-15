using System;
using System.Threading.Tasks;

namespace TelegramBot.Models.APIs.Weather
{
    public interface IWeatherProvider
    {
        Task<TodayWeather> GiveMeTodayWeather();
        Task<TodayWeather[]> GiveMeWeatherOnWeek();
    }
}
