using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Back.Services
{
    public class CloudinaryAPIService
    {
        private Cloudinary Cloudinary { get; set; }

        public CloudinaryAPIService(string cloudName, string apiKey, string apiSecret)
        {
            Account account = new Account(cloudName, apiKey, apiSecret);

            Cloudinary = new Cloudinary(account);
        }

        public async Task<string> UploadPicture(string fileName, Stream stream /*, byte[] bytes*/)
        {
//            Stream stream = new MemoryStream(bytes);

            ImageUploadParams uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, stream)
            };

            ImageUploadResult uploadResult = await Cloudinary.UploadAsync(uploadParams);

            stream.Dispose();
            return uploadResult.SecureUri.AbsoluteUri;
        }
    }
}
