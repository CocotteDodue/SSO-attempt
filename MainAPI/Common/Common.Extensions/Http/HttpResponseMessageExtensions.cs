using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Common.Extensions.Http
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T> ExtractResultAsync<T> (this HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            var result = string.IsNullOrEmpty(responseString)
                ? default(T)
                : JsonConvert.DeserializeObject<T>(responseString);

            return result;
        } 
    }
}
