﻿using Back.Models.Enumns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models.Entities
{
    public class Monster : BaseModel, Card
    {
        public virtual string Name { get; set; }
        public virtual string Passcode { get; set; }
        public virtual CardType Type { get; set; }
        public virtual CardAttribute Attribute { get; set; }
        public virtual string Description { get; set; }
    }
}
