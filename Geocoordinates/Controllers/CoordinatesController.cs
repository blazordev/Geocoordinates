using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geocoordinates.Data;
using Geocoordinates.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Geocoordinates.Controllers
{
    [ApiController]
    [Route("api/coordinates")]
    public class CoordinatesController : ControllerBase
    {
        private CrawlerService _crawlerService;

        public CoordinatesController(CrawlerService crawlerService)
        {
            _crawlerService = crawlerService;
        }

        [HttpGet]
        public IActionResult GetCoordinatesForCity(string city, string country)
        {
            if(string.IsNullOrEmpty(city)|| string.IsNullOrEmpty(country))
            {
                return BadRequest();
            }
            var coordinates = _crawlerService.StartChrome(city, country);
            if (coordinates == null)
            {
                return NotFound();
            }
            return Ok(coordinates);
        }

    }
}
