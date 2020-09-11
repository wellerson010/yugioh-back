using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Enums;
using Model.Interfaces.Models;

namespace Model.Models
{
    public class Magic : IBaseModel, ICard
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Passcode { get; set; }
        public CardType Type { get; set; }
        public string Description { get; set; }
        public bool Staple { get; set; }
        public CardRace Race { get; set; }
        public DateTime TCGDate { get; set; }
        public DateTime OCGDate { get; set; }
    }
}
