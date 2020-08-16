using System;
using System.Configuration;
using System.Threading.Tasks;
using TelegramBot.Models.shared;
using TelegramBot.Models.Weather.YandexWeather.Models;

namespace TelegramBot.Models.APIs.Weather
{
    public class YandexWeather : IWeatherProvider
    {
        private string apiName = "X-Yandex-API-Key";
        private string apiKey = ConfigurationManager.AppSettings.Get("yandex-weather-api-key");
        private string uri = "https://api.weather.yandex.ru/v2/forecast?lat=55.75396&lon=37.620393&limit=7&hours=false";

        public async Task<TodayWeather> GiveMeTodayWeather()
        {
            try
            {
                RootWeather weather = await Request.Fetch<RootWeather>(uri, new RequestOption(apiName, apiKey));
                Fact fact = weather.fact;
                Parts fullDay = weather.forecasts[0].parts;

                return new TodayWeather(weather.forecasts[0].date,
                                        fullDay.night.temp_avg,
                                        fullDay.night.condition,
                                        fullDay.morning.temp_avg,
                                        fullDay.morning.condition,
                                        fullDay.day.temp_avg,
                                        fullDay.day.condition,
                                        fullDay.evening.temp_avg,
                                        fullDay.evening.condition)
                                        { FactTemp = fact.temp, FactCondition = fact.condition };
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<TodayWeather[]> GiveMeWeatherOnWeek()
        {
            try
            {
                RootWeather weather = await Request.Fetch<RootWeather>(uri, new RequestOption(apiName, apiKey));
                TodayWeather[] weatherOnWeek = new TodayWeather[7];
                for(int i = 0; i < weatherOnWeek.Length; i++)
                {
                    Parts fullDay = weather.forecasts[i].parts;
                    weatherOnWeek[i] = new TodayWeather(weather.forecasts[i].date,
                                                        fullDay.night.temp_avg,
                                                        fullDay.night.condition,
                                                        fullDay.morning.temp_avg,
                                                        fullDay.morning.condition,
                                                        fullDay.day.temp_avg,
                                                        fullDay.day.condition,
                                                        fullDay.evening.temp_avg,
                                                        fullDay.evening.condition);
                }
                return weatherOnWeek;
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}