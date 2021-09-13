using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Services;
using MetricsManager.DAL;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : BaseMetricsAgentController<DotNetMetricsController>
    {
        private IDotNetMetricsRepository _dotnetMetricsRepository;
        public DotNetMetricsController(ILogger<DotNetMetricsController> logger, IDotNetMetricsRepository dotnetMetricsRepository) : base(logger)
        {
            _dotnetMetricsRepository = dotnetMetricsRepository;
        }

        [HttpGet("errors-count/from/{fromTime}/to/{toTime}")]
        public override IActionResult GetMetricsFromAgent(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            base.GetMetricsFromAgent(fromTime, toTime);
            return Ok(_dotnetMetricsRepository.GetByTimePeriod());
        }
    }
}