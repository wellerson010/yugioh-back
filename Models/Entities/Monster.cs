using Back.Models.Enumns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models.Entities
{
    public class Monster : ICard
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Passcode { get; set; }
        public virtual CardType Type { get; set; }
        public virtual CardAttribute Attribute { get; set; }
        public virtual string Description { get; set; }
        public virtual string ATK { get; set; }
        public virtual string DEF { get; set; }
        public virtual int Level { get; set; }
        public virtual MonsterType MonsterType { get; set; }
    }
}
