using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Models.Entities;
using Back.Models.Repository;
using Back.ViewModels.Monster;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    [Route("api/monster")]
    public class MonsterController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] MonsterEditViewModel data)
        {
            Monster monster = new Monster();
            monster.Name = data.Name;
            monster.ATK = data.ATK;

            await new MonsterRepository().Save(monster);

            return Ok(true);
        }
    }
}
