using Back.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration Configuration;

        private readonly ISynchronizeService SynchronizeService;

        public SynchronizeDataController(IConfiguration configuration, ISynchronizeService synchronizeService)
        {
            Configuration = configuration;
            SynchronizeService = synchronizeService;
        }

        [Route("synchronizeAll")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> SynchronizeAll()
        {
            try { 
            await SynchronizeService.SynchronizeAllCards();
            }
            catch (Exception e)
            {

            }
            return new string[] { "value1", "value2" };
        }
    }
}
