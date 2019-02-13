using Back.Models.Entities;
using Back.Models.Enumns;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models.Map
{
    public class MonsterMap : SubclassMap<Monster>
    {
        public MonsterMap()
        {
            Schema("yugioh");
            Table("monster");

            Map(x => x.ATK);
            Map(x => x.DEF);
            Map(x => x.Level);
            Map(x => x.MonsterType, "monster_type").CustomType<MonsterType>(); ;
        }
    }
}
