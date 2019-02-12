using Back.Models.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models.Map
{
    public class MonsterMap : ClassMap<Monster>
    {
        public MonsterMap()
        {
            Schema("yugioh");
            Table("monster");

            Id(x => x.Id).GeneratedBy.HiLo("nhibernate.table_key", "next_value", "1", "type = 'yugioh'.monster");
            Map(x => x.Name);
            Map(x => x.Passcode);
            Map(x => x.Attribute);
            Map(x => x.Description);
            Map(x => x.ATK);
            Map(x => x.DEF);
            Map(x => x.Level);
            Map(x => x.MonsterType, "monster_type");
        }
    }
}
