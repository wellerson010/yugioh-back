using Back.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SynchronizeDataController:ControllerBase
    {
        [Route("synchronizeAll")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> SynchronizeAll()
        {
            await new APIService().GetAllCards();
            return new string[] { "value1", "value2" };
        }
    }
}
