using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetaTest.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpGet("locations")]
        public async Task<IActionResult> Locations(string city)
        {
            return Ok("cool");
        }
    }
}