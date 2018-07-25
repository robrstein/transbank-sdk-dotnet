﻿using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Transbank.OnePay.Net
{
    public abstract class Channel
    {
        public static async Task<string> requestAsync(string uri, HttpMethod method, string query)
        {
            return await requestAsync(uri, method, query, null);
        }
        public static async Task<string> requestAsync(string uri, HttpMethod method,
            string query, string contenType)
        {
            if (method == null)
                method = HttpMethod.Get;
            if (contenType == null)
                contenType = "application/json";

            Client = new HttpClient();
            var header = new MediaTypeWithQualityHeaderValue(contenType);
            Client.DefaultRequestHeaders.Accept.Add(header);

            HttpRequestMessage message = new HttpRequestMessage(method, new Uri(uri));
            message.Content = new StringContent(query, Encoding.UTF8,contenType);
            try
            {
                HttpResponseMessage response;
                response = await Client.SendAsync(message);
                response.EnsureSuccessStatusCode(); //Watch this, because in java we are asking for codes between 200 and 300
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return jsonResponse;
            }
            finally
            {
                Client.Dispose();
            }
        }

        internal static HttpClient Client { get; private set; }

        public static string PostString(string url, string RequestMethod, string Query )
        {
            return "";
        }
    }
}
