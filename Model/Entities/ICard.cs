using Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public interface ICard
    {
        string Id { get; set; }

        string Name { get; set; }

        string Passcode { get; set; }

        CardType Type { get; set; }
        CardRace Race { get; set; }

        string Description { get; set; }

        bool Staple { get; set; }

        DateTime TCGDate { get; set; }

        DateTime OCGDate { get; set; }
    }
}
