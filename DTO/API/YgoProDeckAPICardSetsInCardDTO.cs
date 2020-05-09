using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.API
{
    public class YgoProDeckAPICardSetsDTO
    {
        public string set_name { get; set; }
        public string set_code { get; set; }
        public string set_rarity { get; set; }
        public string set_rarity_code { get; set; }
        public string set_price { get; set; }

    }
}
