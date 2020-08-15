using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Models.APIs.Weather;

namespace TelegramBot.Models.Commands
{
    public class TodayWeatherCommand : Command
    {
        public override string CommandName => "today";

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            long chatId = message.Chat.Id;

            int messageId = message.MessageId;

            WeatherHandler weatherHandler = new WeatherHandler { WeatherProvider = new YandexWeather() };
            TodayWeather todayWeather = await weatherHandler.GiveMeTodayWeather();

            StringBuilder botReply = new StringBuilder();
            if(todayWeather != null)
            {
                botReply.AppendLine($"Moscow.{todayWeather.Date}");
                botReply.AppendLine($"Night - temperature: {todayWeather.NightTemp}, condition: {todayWeather.NightCondition}");
                botReply.AppendLine($"Morning - temperature: {todayWeather.MorningTemp}, condition: {todayWeather.MorningCondition}");
                botReply.AppendLine($"Day - temperature: {todayWeather.DayTemp}, condition: {todayWeather.DayCondition}");
                botReply.AppendLine($"Evening - temperature: {todayWeather.EveningTemp}, condition: {todayWeather.EveningCondition}");
                botReply.AppendLine($"Now - temperature: {todayWeather.FactTemp}, condition: {todayWeather.FactCondition}");
            }
            else
            {
                botReply.AppendLine("Servise is unavaliable");
            }
            

            await client.SendTextMessageAsync(chatId, botReply.ToString(), replyToMessageId: messageId);
        }
    }
}