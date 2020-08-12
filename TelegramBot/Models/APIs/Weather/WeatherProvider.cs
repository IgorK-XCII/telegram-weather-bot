using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TelegramBot.Models.APIs.Weather
{
    public class WeatherProvider
    {
        public  ITodayWeatherProvider TodayWeatherProvider { get; set; }
        
        public async Task<TodayWeather> GiveMeTodayWeather() => await TodayWeatherProvider?.GiveMeTodayWeather();
    }
}