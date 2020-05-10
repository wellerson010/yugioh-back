using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Back.Services
{
    public class HTTPService
    {
        public async Task<T> Get<T>(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string responseBody = await response.Content.ReadAsStringAsync();
                T data = JsonConvert.DeserializeObject<T>(responseBody);

                return data;
            }
        }

        public async Task<Stream> GetByteFromUrl(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    Stream contentStream = await (await httpClient.SendAsync(request)).Content.ReadAsStreamAsync();
                    //   Stream stream = new FileStream("MyImage", FileMode.Create, FileAccess.Write, FileShare.None);
                //    Stream stream = new MemoryStream(contentStream.Rea)
                //   await contentStream.CopyToAsync(stream);

                //    contentStream.Dispose();

                    return contentStream;

                }
            }
        }
    }
}
