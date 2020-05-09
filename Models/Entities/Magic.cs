using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Models.Enumns;

namespace Back.Models.Entities
{
    public class Magic : ICard
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Passcode { get; set; }
        public CardType Type { get; set; }
        public string Description { get; set; }

        public bool Staple { get; set; }
    }
}
