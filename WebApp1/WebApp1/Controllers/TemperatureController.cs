using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : Controller
    {
        private readonly ValuesHolder _valuesHolder;

        public TemperatureController(ValuesHolder valuesHolder) => _valuesHolder = valuesHolder;

        [HttpPost]
        public IActionResult IndexPost([FromBody] Values value)
        {
            _valuesHolder.Add(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult IndexPut([FromBody] Values value)
        {
            _valuesHolder.Put(value);
            return Ok();
        }

        [HttpGet]
        public IActionResult IndexGet([FromQuery] DateTime StartTime, [FromQuery] DateTime FinishTime)
        {
            return Ok(_valuesHolder.Sort(StartTime, FinishTime));
        }

        [HttpDelete]
        public IActionResult IndexDel([FromQuery] DateTime StartTime, [FromQuery] DateTime FinishTime)
        {
            _valuesHolder.Del(StartTime, FinishTime);
            return Ok();
        }
    }
}