using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Back.Services
{
    public class HTTPService
    {
        public async Task<T> Get<T>(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            T data = JsonConvert.DeserializeObject<T>(responseBody);

            return data;
        }
    }
}
