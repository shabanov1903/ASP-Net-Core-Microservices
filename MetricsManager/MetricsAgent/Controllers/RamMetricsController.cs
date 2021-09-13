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
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : BaseMetricsAgentController<RamMetricsController>
    {
        private IRamMetricsRepository _ramMetricsRepository;
        public RamMetricsController(ILogger<RamMetricsController> logger, IRamMetricsRepository ramMetricsRepository) : base(logger)
        {
            _ramMetricsRepository = ramMetricsRepository;
        }

        [HttpGet("available/from/{fromTime}/to/{toTime}")]
        public override IActionResult GetMetricsFromAgent(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            base.GetMetricsFromAgent(fromTime, toTime);
            return Ok(_ramMetricsRepository.GetByTimePeriod());
        }
    }
}