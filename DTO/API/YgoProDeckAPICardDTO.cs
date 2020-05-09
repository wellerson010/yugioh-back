using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.API
{
    public class YgoProDeckAPICardDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int level { get; set; }
        public string race { get; set; }
        public string attribute { get; set; }

        public string archetype { get; set; }

        public int scale { get; set; }

        public int linkval { get; set; }

        public IList<string> linkmarkers { get; set; } = new List<string>();

        public IList<YgoProDeckAPICardSetsDTO> card_sets { get; set; } = new List<YgoProDeckAPICardSetsDTO>();

        public IList<YgoProDeckAPICardImageDTO> card_images { get; set; } = new List<YgoProDeckAPICardImageDTO>();

        public YgoProDeckAPIMiscInformationDTO misc_info { get; set; }
    }
}



//MISC TRUE