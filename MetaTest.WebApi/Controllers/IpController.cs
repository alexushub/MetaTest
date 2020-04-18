using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MetaTest.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetaTest.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IpController : ControllerBase
    {
        private readonly IDataService _dataService;

        public IpController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("location")]
        public async Task<IActionResult> Location(string ip)
        {
            var s = Stopwatch.StartNew();

            var location = _dataService.GetLocationByIp(ip);

            s.Stop();

            return Ok(location);
        }
    }
}