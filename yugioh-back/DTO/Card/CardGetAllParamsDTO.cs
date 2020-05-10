using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.Card
{
    public class CardGetAllParamsDTO
    {
        public string text { get; set; } = "";

        public int page { get; set; } = 1;

        public int total { get; set; } = 20;
    }
}
