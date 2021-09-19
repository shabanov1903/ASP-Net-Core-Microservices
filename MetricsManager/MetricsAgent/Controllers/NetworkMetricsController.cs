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
    [Route("api/metrics/network")]
    [ApiController]
    public class NetworkMetricsController : BaseMetricsAgentController<NetworkMetricsController, NetworkMetricsEntity, NetworkMetrics>
    {
        public NetworkMetricsController(ILogger<NetworkMetricsController> logger, IDBRepository<NetworkMetricsEntity> dbrepository, IMapper mapper) : base(logger, dbrepository, mapper)
        {
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public override IActionResult GetMetricsFromAgent(
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            return base.GetMetricsFromAgent(fromTime, toTime);
        }
    }
}
