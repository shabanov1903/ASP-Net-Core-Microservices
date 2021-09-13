using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    public class BaseMetricsManagerController<T> : ControllerBase
    {
        private readonly ILogger<T> _logger;
        public BaseMetricsManagerController(ILogger<T> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, $"Request to Controller");
        }

        public virtual IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"GET request to {HttpContext?.Request}");
            return Ok();
        }

        public virtual IActionResult GetMetricsFromAllCluster(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"GET request to {HttpContext?.Request}");
            return Ok();
        }
    }
}
