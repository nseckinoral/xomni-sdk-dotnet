using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Core.Providers
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            var response = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(response);
            return result;
        }

        public static Task<HttpResponseMessage> PostAsJsonAsync(this HttpClient client, string requestUri, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            return client.PostAsync(requestUri, stringContent);
        }

        public static Task<HttpResponseMessage> PutAsJsonAsync(this HttpClient client, string requestUri, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            return client.PutAsync(requestUri, stringContent);
        }
    }
}
