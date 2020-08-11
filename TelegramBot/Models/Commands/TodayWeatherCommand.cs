using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Models.APIs.Weather;

namespace TelegramBot.Models.Commands
{
    public class TodayWeatherCommand : Command
    {
        public override string CommandName => "today's weather";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            long chatId = message.Chat.Id;

            int messageId = message.MessageId;

            WeatherProvider weatherProvider = new WeatherProvider { TodayWeatherProvider = new YandexWeather() };
            TodayWeather todayWeather = await weatherProvider.GiveMeTodayWeather();

            string botReply = $"Weather in Moscow. Current temperature: {todayWeather.FactTemp}, condition: {todayWeather.FactCondition}. Nights temperature: {todayWeather.EveningTemp}," +
                $"condition: {todayWeather.EveningCondition}";

            await client.SendTextMessageAsync(chatId, botReply, replyToMessageId: messageId);
        }
    }
}