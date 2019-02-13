using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Models.Entities;
using Back.Models.Repository;
using Back.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back.Controllers
{
    [Route("api/monster")]
    [ApiController]
    public class MonsterController : Controller
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            MonsterRepository repository = new MonsterRepository();
            Monster monster = await repository.GetById(id);

            return Ok(new MonsterEditViewModel(monster));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody]MonsterEditViewModel data)
        {
            Monster monster = null;
            MonsterRepository repository = new MonsterRepository();

            if (data.Id == 0)
            {
                monster = new Monster();
            }
            else
            {
                monster = await repository.GetById(data.Id);
            }

            monster.Name = data.Name;
            monster.Passcode = data.Passcode;
            monster.Attribute = data.Attribute;
            monster.Description = data.Description;
            monster.ATK = data.ATK;
            monster.DEF = data.DEF;
            monster.Level = data.Level;
            monster.MonsterType = data.MonsterType;

            await repository.Save(monster);

            return Ok(monster.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            MonsterRepository repository = new MonsterRepository();
            await repository.DeleteById(id);

            return Ok(true);
        }
    }
}
