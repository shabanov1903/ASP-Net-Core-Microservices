using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.DB;
using MetricsAgent.DB.Entities;
using MetricsAgent.Services.DTO;
using AutoMapper;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : BaseMetricsAgentController<HddMetricsController, HddMetricsEntity, HddMetrics>
    {
        public HddMetricsController(ILogger<HddMetricsController> logger, IDBRepository<HddMetricsEntity> dbrepository, IMapper mapper) : base(logger, dbrepository, mapper)
        {
        }

        [HttpGet("left/from/{fromTime}/to/{toTime}")]
        public override IActionResult GetMetricsFromAgent(
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            return base.GetMetricsFromAgent(fromTime, toTime);
        }
    }
}
