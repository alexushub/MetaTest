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
    public class IpController : ControllerBase
    {
        [HttpGet("location")]
        public async Task<IActionResult> Location(string ip)
        {
            return Ok(ip);
        }
    }
}