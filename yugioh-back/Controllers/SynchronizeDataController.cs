﻿using Back.Services;
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

        public SynchronizeDataController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [Route("synchronizeAll")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> SynchronizeAll()
        {
            await new SynchronizeService().SynchronizeCard(Configuration, "Dark Hole");
            return new string[] { "value1", "value2" };
        }
    }
}
