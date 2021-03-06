﻿using Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Interfaces.Models
{
    public interface ICard
    {
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
