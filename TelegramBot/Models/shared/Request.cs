using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using TelegramBot.Models.shared;

namespace TelegramBot.Models
{
    public static class Request
    {
        public static async Task<T> Fetch<T>(string uri, RequestOption options = null)
        {
            using (HttpClient client = new HttpClient())
            {
                if (options != null) client.DefaultRequestHeaders.Add(options.ApiName, options.ApiKey);
                using (HttpResponseMessage response = await client.GetAsync(uri))
                {
                    using (HttpContent content = response.Content)
                    {
                        return JsonConvert.DeserializeObject<T>(await content.ReadAsStringAsync());
                    }
                }
            }
         }
    }
}
