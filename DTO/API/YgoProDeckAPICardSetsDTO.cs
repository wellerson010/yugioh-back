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

        public string tcg_date { get; set; }

        public int num_of_cards { get; set; }
    }
}