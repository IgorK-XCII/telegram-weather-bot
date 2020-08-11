using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace TelegramBot.Models.APIs.Weather
{
    public class YandexWeather : ITodayWeatherProvider
    {
        private string apiName = "X-Yandex-API-Key";
        private string apiKey = ConfigurationManager.AppSettings.Get("yandex-weather-api-key");
        private string uri = "https://api.weather.yandex.ru/v2/forecast?lat=55.75396&lon=37.620393&limit=2&hours=false";

        public async Task<TodayWeather> GiveMeTodayWeather()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add(apiName, apiKey);
                    using (HttpResponseMessage response = await client.GetAsync(uri))
                    {
                        using (HttpContent content = response.Content)
                        {
                            Root data = JsonConvert.DeserializeObject<Root>(await content.ReadAsStringAsync());
                            Fact fact = data.fact;
                            Evening evening = data.forecasts[0].parts.evening;
                            return new TodayWeather(fact.temp, evening.temp_avg, fact.condition, evening.condition);
                        }
                    }
                }
            } catch(Exception e)
            {
                return new TodayWeather(0, 0, "null", e.Message);
            }
            
        }

        public class Fact
        {
            public int temp { get; set; }
            public string condition { get; set; }
        }
        public class Evening
        {
            public int temp_avg { get; set; }
            public string condition { get; set; }
        }
        public class Parts
        {
            public Evening evening { get; set; }
        }

        public class Forecast
        {
            public Parts parts { get; set; }
        }

        public class Root
        {
            public Fact fact { get; set; }
            public Evening evening { get; set; }
            public List<Forecast> forecasts { get; set; }
        }
    }
}