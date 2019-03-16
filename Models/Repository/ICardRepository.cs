using Back.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models.Repository
{
    public class ICardRepository:Repository<ICard>
    {
        public async Task<IList<ICard>> GetListToTable(string text, int page, int total)
        {
            var query = Session()
                .QueryOver<ICard>();

            if (!String.IsNullOrEmpty(text))
            {
                query = query.WhereRestrictionOn(x => x.Name)
                .IsInsensitiveLike(text);
            }

            return await query.Skip(page * total)
                .Take(total)
                .ListAsync<ICard>();
        }
    }
}
