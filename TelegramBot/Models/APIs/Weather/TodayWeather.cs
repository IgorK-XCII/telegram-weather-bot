using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelegramBot.Models.APIs.Weather
{
    public class TodayWeather
    {
        public int FactTemp { get; }
        public int EveningTemp { get; }
        public string FactCondition { get; }
        public string EveningCondition { get; }
        public TodayWeather(int factTemp, int evnTemp, string factCond, string evnCond)
        {
            FactTemp = factTemp;
            FactCondition = factCond;
            EveningTemp = evnTemp;
            EveningCondition = evnCond;
        }
    }
}