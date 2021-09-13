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
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : BaseMetricsAgentController<HddMetricsController>
    {
        private IHddMetricsRepository _hddMetricsRepository;
        public HddMetricsController(ILogger<HddMetricsController> logger, IHddMetricsRepository hddMetricsRepository) : base(logger)
        {
            _hddMetricsRepository = hddMetricsRepository;
        }

        [HttpGet("left/from/{fromTime}/to/{toTime}")]
        public override IActionResult GetMetricsFromAgent(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            base.GetMetricsFromAgent(fromTime, toTime);
            return Ok(_hddMetricsRepository.GetByTimePeriod());
        }
    }
}
