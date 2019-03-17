using Back.Models.Entities;
using Back.Models.Enumns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.ViewModels.Monsters
{
    public class MonsterEditViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Passcode { get; set; }
        public CardAttribute Attribute { get; set; }
        public string Description { get; set; }
        public string ATK { get; set; }
        public string DEF { get; set; }
        public int Level { get; set; }
        public MonsterType MonsterType { get; set; }

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
