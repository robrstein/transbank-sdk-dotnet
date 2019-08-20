using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Transbank.Common;
using Transbank.Exceptions;

namespace Transbank.Patpass.Common
{
    public class RequestService
    {
        private static readonly string CONTENT_TYPE = "application/json";

        private static void AddRequiredHeaders(HttpClient client, string commerceCode, string apiKey)
        {
            var header = new MediaTypeWithQualityHeaderValue(CONTENT_TYPE);
            client.DefaultRequestHeaders.Accept.Add(header);
            client.DefaultRequestHeaders.Add("commercecode", commerceCode);
            client.DefaultRequestHeaders.Add("Authorization", apiKey);
        }

        public static string Perform<T>(BaseRequest request, Options options) where T : TransbankException
        {
            var message = new HttpRequestMessage(request.Method, new Uri(options.IntegrationType.ApiBase + request.Endpoint));
            if (request.Method != HttpMethod.Get)
                message.Content = new StringContent(JsonConvert.SerializeObject(request),
                    Encoding.UTF8, CONTENT_TYPE);

            using (var client = new HttpClient())
            {
                AddRequiredHeaders(client, options.CommerceCode, options.ApiKey);
                var response = client.SendAsync(message).ConfigureAwait(false)
                    .GetAwaiter().GetResult();
                var jsonResponse = response.Content.ReadAsStringAsync()
                    .ConfigureAwait(false).GetAwaiter().GetResult();
                if (!response.IsSuccessStatusCode)
                {
                    var jsonObject = (JObject)JsonConvert.DeserializeObject(jsonResponse);
                    throw (T)Activator.CreateInstance(typeof(T), new object[] {
                        (int)response.StatusCode, $"Error message: {jsonObject.Value<string>("error_message")}"
                    });
                }
                return jsonResponse;
            }
        }
    }
}
