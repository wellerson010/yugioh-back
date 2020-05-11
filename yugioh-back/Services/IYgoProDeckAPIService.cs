using Back.DTO.API;
using Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Services
{
    public interface IYgoProDeckAPIService
    {
        Task<IList<YgoProDeckAPICardDTO>> GetAllCards();
    }
}
