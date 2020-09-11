using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Back.Services
{
    public class HTTPService : IHTTPService
    {
        private readonly IHttpClientFactory HTTPClientFactory;

        public HTTPService(IHttpClientFactory httpClientFactory)
        {
            HTTPClientFactory = httpClientFactory;
        }

        public async Task<T> Get<T>(string url)
        {
            HttpClient client = HTTPClientFactory.CreateClient();

            HttpResponseMessage response = await client.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            T data = JsonConvert.DeserializeObject<T>(responseBody, settings);

            return data;
        }

        public async Task<Stream> GetByteFromUrl(string url)
        {
            HttpClient httpClient = HTTPClientFactory.CreateClient();

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                Stream contentStream = await (await httpClient.SendAsync(request)).Content.ReadAsStreamAsync();

                return contentStream;
            }
        }
    }
}
