using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Models.Entities;
using Back.Models.Repository;
using Back.ViewModels;
using Back.ViewModels.Monsters;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    [Route("api/monster")]
    public class MonsterController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] MonsterEditViewModel data)
        {
            MonsterRepository monsterRepository = new MonsterRepository();
            Monster monster;

            if (String.IsNullOrEmpty(data.Id))
            {
                monster = new Monster();
            }
            else
            {
                monster = await monsterRepository.GetById(data.Id);
            }

            monster.Name = data.Name;
            monster.ATK = data.ATK;
            monster.DEF = data.DEF;
            monster.Level = data.Level;
            monster.Description = data.Description;
            monster.Passcode = data.Passcode;
            monster.Attribute = data.Attribute;

            await new MonsterRepository().Save(monster);

            return Ok(new ResponseViewModel(new
            {
                monster.Id
            }));
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(string id)
        {
            Monster monster = await new MonsterRepository().GetById(id);
            MonsterEditViewModel viewModel = new MonsterEditViewModel(monster);

            return Ok(new ResponseViewModel(viewModel));
        }
    }
}
