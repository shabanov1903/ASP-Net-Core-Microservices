using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    

    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : BaseMetricsManagerController<RamMetricsController>
    {
        public RamMetricsController(ILogger<RamMetricsController> logger) : base(logger)
        {
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public override IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            base.GetMetricsFromAgent(agentId, fromTime, toTime);
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public override IActionResult GetMetricsFromAllCluster(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            base.GetMetricsFromAllCluster(fromTime, toTime);
            return Ok();
        }
    }
}
