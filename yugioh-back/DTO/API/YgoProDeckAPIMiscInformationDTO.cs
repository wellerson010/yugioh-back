using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.API
{
    public class YgoProDeckAPIMiscInformationDTO
    {
        public IList<string> formats { get; set; } = new List<string>();

        public string tcg_date { get; set; }

        public string ocg_date { get; set; }

        public string staple { get; set; }
    }
}

//Yes