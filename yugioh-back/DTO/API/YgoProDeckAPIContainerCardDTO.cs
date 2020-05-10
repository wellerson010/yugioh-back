using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.DTO.API
{
    public class YgoProDeckAPIContainerCardDTO
    {
        public IList<YgoProDeckAPICardDTO> data { get; set; } = new List<YgoProDeckAPICardDTO>();
    }
}
