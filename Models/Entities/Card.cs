using Back.Models.Enumns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models.Entities
{
    public interface Card
    {
        string Name { get; set; }

        string Passcode { get; set; }

        CardType Type { get; set; }

        CardAttribute Attribute { get; set; }

        string Description { get; set; }
    }
}
