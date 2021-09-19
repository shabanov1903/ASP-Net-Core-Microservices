using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.DB;
using MetricsManager.DB.Entities;
using MetricsManager.Services.DTO;
using AutoMapper;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : BaseMetricsManagerController<HddMetricsController, HddMetricsEntity, HddMetrics>
    {
        public HddMetricsController(ILogger<HddMetricsController> logger, IDBRepository<HddMetricsEntity> dbrepository, IMapper mapper) : base(logger, dbrepository, mapper)
        {
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public override IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            return base.GetMetricsFromAgent(agentId, fromTime, toTime);
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public override IActionResult GetMetricsFromAllCluster(
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            return base.GetMetricsFromAllCluster(fromTime, toTime);
        }
    }
}
