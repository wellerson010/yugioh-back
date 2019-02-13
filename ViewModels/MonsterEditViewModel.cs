using Back.Models.Entities;
using Back.Models.Enumns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.ViewModels
{
    public class MonsterEditViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Passcode { get; set; }
        public virtual CardAttribute Attribute { get; set; }
        public virtual string Description { get; set; }
        public virtual string ATK { get; set; }
        public virtual string DEF { get; set; }
        public virtual int Level { get; set; }
        public virtual MonsterType MonsterType { get; set; }

        public MonsterEditViewModel()
        {

        }

        public MonsterEditViewModel(Monster monster)
        {
            Id = monster.Id;
            Name = monster.Name;
            Passcode = monster.Passcode;
            Attribute = monster.Attribute;
            Description = monster.Description;
            ATK = monster.ATK;
            DEF = monster.DEF;
            Level = monster.Level;
            MonsterType = monster.MonsterType;
        }
    }
}
