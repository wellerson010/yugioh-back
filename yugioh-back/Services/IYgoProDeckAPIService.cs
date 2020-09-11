using Back.DTO.API;
using Model.Enums;
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
