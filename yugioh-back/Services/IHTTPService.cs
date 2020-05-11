using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Services
{
    public interface IHTTPService
    {
        Task<T> Get<T>(string url);

        Task<Stream> GetByteFromUrl(string url);
    }
}
