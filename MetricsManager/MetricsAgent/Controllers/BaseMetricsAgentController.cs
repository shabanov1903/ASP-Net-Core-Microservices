using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    public class BaseMetricsAgentController<T> : ControllerBase
    {
        private readonly ILogger<T> _logger;
        public BaseMetricsAgentController(ILogger<T> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, $"Request to Controller");
        }

        public virtual IActionResult GetMetricsFromAgent(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"GET request to {HttpContext?.Request}");
            return Ok();
        }
    }
}
