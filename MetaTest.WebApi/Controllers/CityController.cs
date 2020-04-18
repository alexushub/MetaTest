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
    public class CityController : ControllerBase
    {
        private readonly IDataService _dataService;

        public CityController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("locations")]
        public async Task<IActionResult> Locations(string city)
        {
            var s = Stopwatch.StartNew();

            var locations = _dataService.GetLocationsByCity(city);

            s.Stop();

            return Ok(locations);
        }
    }
}