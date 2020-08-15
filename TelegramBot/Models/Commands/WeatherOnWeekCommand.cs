using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Models.APIs.Weather;

namespace TelegramBot.Models.Commands
{
    public class WeatherOnWeekCommand : Command
    {
        public override string CommandName => "week";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            long chatId = message.Chat.Id;

            int messageId = message.MessageId;

            WeatherHandler weatherHandler = new WeatherHandler { WeatherProvider = new YandexWeather() };
            TodayWeather[] weatherOnWeek = await weatherHandler.GiveMeWeatherOnWeek();

            StringBuilder botReply = new StringBuilder();
            if (weatherOnWeek != null)
            {
                foreach(TodayWeather todayWeather in weatherOnWeek)
                {
                    botReply.AppendLine($"Moscow.{todayWeather.Date}");
                    botReply.AppendLine($"Night - temperature: {todayWeather.NightTemp}, condition: {todayWeather.NightCondition}");
                    botReply.AppendLine($"Morning - temperature: {todayWeather.MorningTemp}, condition: {todayWeather.MorningCondition}");
                    botReply.AppendLine($"Day - temperature: {todayWeather.DayTemp}, condition: {todayWeather.DayCondition}");
                    botReply.AppendLine($"Evening - temperature: {todayWeather.EveningTemp}, condition: {todayWeather.EveningCondition}");
                    botReply.AppendLine(" ");
                }
            }
            else
            {
                botReply.AppendLine("Servise is unavaliable");
            }


            await client.SendTextMessageAsync(chatId, botReply.ToString(), replyToMessageId: messageId);
        }
    }
}