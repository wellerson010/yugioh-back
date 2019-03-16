using Back.Models.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models.Map
{
    public class ICardMap:ClassMap<ICard>
    {
        public ICardMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("nhibernate.table_key", "next_value", "1", "type = 'card'");
            Map(x => x.Name);
            Map(x => x.Passcode);
            
            Map(x => x.Attribute);
            Map(x => x.Description);

            Schema("yugioh");

            UseUnionSubclassForInheritanceMapping();
        }
    }
}