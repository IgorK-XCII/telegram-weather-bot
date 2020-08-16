using System.Collections.Generic;

namespace TelegramBot.Models.Weather.YandexWeather.Models
{
    public class RootWeather
    {
        public Fact fact { get; set; }
        public List<Forecast> forecasts { get; set; }
    }
}