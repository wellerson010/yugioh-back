using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Models.Entities;
using Back.Models.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back.Controllers
{
    [Route("api/monster")]
    [ApiController]
    public class MonsterController : Controller
    {
        [HttpGet("{id}")]
        public string Get(long id)
        {
            MonsterRepository repository = new MonsterRepository();
            Monster monster = repository.GetById(id);

            return monster.Description;
        }
    }
}
