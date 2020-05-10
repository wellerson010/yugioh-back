using Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Monster : ICard
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Passcode { get; set; }
        public CardType Type { get; set; }
        public CardAttribute Attribute { get; set; }
        public string Description { get; set; }
        public string ATK { get; set; }
        public string DEF { get; set; }
        public int Level { get; set; }
        public bool Staple { get; set; }
    }
}
