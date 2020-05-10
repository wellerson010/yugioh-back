using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.ViewModels;
using Back.ViewModels.Monsters;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Model.Repository;

namespace Back.Controllers
{
    [Route("api/monster")]
    public class MonsterController : Controller
    {
        [HttpGet("get")]
        public async Task<IActionResult> Get(string id)
        {
            Monster monster = await new MonsterRepository().GetById(id);
            MonsterEditViewModel viewModel = new MonsterEditViewModel(monster);

            return Ok(new ResponseViewModel(viewModel));
        }
    }
}
