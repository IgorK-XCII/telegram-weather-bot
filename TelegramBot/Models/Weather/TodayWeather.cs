namespace TelegramBot.Models.APIs.Weather
{
    public class TodayWeather
    {
        public string Date { get; }
        public int FactTemp { get; set; }
        public string FactCondition { get; set; }
        public int NightTemp { get; }
        public string NightCondition { get; }
        public int MorningTemp { get; }
        public string MorningCondition { get; }
        public int DayTemp { get; }
        public string DayCondition { get; }
        public int EveningTemp { get; }
        public string EveningCondition { get; }
        public TodayWeather(string date,
                            int nightTemp, 
                            string nightCondition, 
                            int morningTemp, 
                            string morningCondition,
                            int dayTemp,
                            string dayCondition,
                            int eveningTemp,
                            string eveningCondition)
        {
            Date = date;
            NightTemp = nightTemp;
            NightCondition = nightCondition;
            MorningTemp = morningTemp;
            MorningCondition = morningCondition;
            DayTemp = dayTemp;
            DayCondition = dayCondition;
            EveningTemp = eveningTemp;
            EveningCondition = eveningCondition;
        }
    }
}