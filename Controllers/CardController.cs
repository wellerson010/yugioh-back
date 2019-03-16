using Back.DTO.Card;
using Back.Models.Entities;
using Back.Models.Repository;
using Back.ViewModels.Card;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [Route("api/card")]
    [ApiController]
    public class CardController:Controller
    {
      /*  [HttpPost("getAll")]
        public async Task<IActionResult> GetAll([FromBody]CardGetAllParamsDTO data)
        {
            ICardRepository cardRepository = new ICardRepository();
            IList<ICard> cards = await cardRepository.GetListToTable(data.text, data.page, data.total);
            IList<CardListViewModel> cardsViewModel = cards.Select(x => new CardListViewModel(x)).ToList();

            return Ok(cardsViewModel);
        } */
    }
}
