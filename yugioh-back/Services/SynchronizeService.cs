using Back.DTO.API;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Services
{
    public class SynchronizeService
    {
        public async Task SynchronizeCard(IConfiguration configuration, string name)
        {
            YgoProDeckAPICardDTO response = (await new YgoProDeckAPIService().GetCardByName("Dark Hole")).FirstOrDefault();

            Stream stream = await new HTTPService().GetByteFromUrl(response.card_images[0].image_url);

            
            await new CloudinaryAPIService(configuration["Cloudinary:CloudName"], configuration["Cloudinary:ApiKey"], configuration["Cloudinary:ApiSecret"]).UploadPicture("AAAA", stream);
        }
    }
}
