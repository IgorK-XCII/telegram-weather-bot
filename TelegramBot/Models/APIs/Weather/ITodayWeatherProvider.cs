using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Models.APIs.Weather
{
    public interface ITodayWeatherProvider
    {
        Task<TodayWeather> GiveMeTodayWeather();
    }
}
