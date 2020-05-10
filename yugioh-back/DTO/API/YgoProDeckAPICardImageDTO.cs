using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.API
{
    public class YgoProDeckAPICardImageDTO
    {
        public int id { get; set; }

        public string image_url { get; set; }

        public string image_url_small { get; set; }
    }
}
