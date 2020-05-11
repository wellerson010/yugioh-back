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
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int Level { get; set; }
        public bool Staple { get; set; }
        public CardRace Race { get; set; }
        public int LinkValue { get; set; }

        public int PendulumScale { get; set; }
        public DateTime TCGDate { get; set; }
        public DateTime OCGDate { get; set; }

    }
}
