namespace TelegramBot.Models.shared
{
    public class RequestOption
    {
        public string ApiName { get; }
        public string ApiKey { get; }
        public RequestOption(string apiName, string apiKey)
        {
            ApiName = apiName;
            ApiKey = apiKey;
        }
    }
}