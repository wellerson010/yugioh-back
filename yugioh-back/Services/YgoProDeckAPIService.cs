using Back.DTO.API;
using Model.Entities;
using Model.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Back.Services
{
    public class YgoProDeckAPIService: IYgoProDeckAPIService 
    {
        private readonly IHTTPService HTTPService;

        public YgoProDeckAPIService(IHTTPService httpService)
        {
            HTTPService = httpService;
        }

        private async Task<IList<YgoProDeckAPICardDTO>> BuildRequestGetCards(string name = "", string id = "")
        {
            string url = "https://db.ygoprodeck.com/api/v7/cardinfo.php?misc=Yes";

            if (!String.IsNullOrEmpty(id))
            {
                url += $"&id={id}";
            }
            else if (!String.IsNullOrEmpty(name))
            {
                url += $"&name={name}";
            }

            YgoProDeckAPIContainerCardDTO response = await HTTPService.Get<YgoProDeckAPIContainerCardDTO>(url);

            IList<YgoProDeckAPICardDTO> data = response.data;

            return data;
        }

        public Task<IList<YgoProDeckAPICardDTO>> GetAllCards()
        {
            return BuildRequestGetCards();
        }

        public Task<IList<YgoProDeckAPICardDTO>> GetCardByName(string name)
        {
            return BuildRequestGetCards(name: name);
        }

        public async Task<IList<YgoProDeckAPIArchetypeDTO>> GetAllArchetypes()
        {
            string url = "https://db.ygoprodeck.com/api/v7/archetypes.php";

            IList<YgoProDeckAPIArchetypeDTO> archetypes = await HTTPService.Get<IList<YgoProDeckAPIArchetypeDTO>>(url);

            return archetypes;
        }
    }
}

