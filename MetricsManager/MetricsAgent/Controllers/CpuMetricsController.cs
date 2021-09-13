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
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : BaseMetricsAgentController<CpuMetricsController>
    {
        private ICpuMetricsRepository _cpuMetricsRepository;
        public CpuMetricsController(ILogger<CpuMetricsController> logger, ICpuMetricsRepository cpuMetricsRepository) : base(logger)
        {
            _cpuMetricsRepository = cpuMetricsRepository;
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public override IActionResult GetMetricsFromAgent(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            base.GetMetricsFromAgent(fromTime, toTime);
            return Ok(_cpuMetricsRepository.GetByTimePeriod());
        }
    }
}