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
    [Route("api/metrics/network")]
    [ApiController]
    public class NetworkMetricsController : BaseMetricsAgentController<NetworkMetricsController>
    {
        private INetworkMetricsRepository _networkMetricsRepository;
        public NetworkMetricsController(ILogger<NetworkMetricsController> logger, INetworkMetricsRepository networkMetricsRepository) : base(logger)
        {
            _networkMetricsRepository = networkMetricsRepository;
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public override IActionResult GetMetricsFromAgent(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            base.GetMetricsFromAgent(fromTime, toTime);
            return Ok(_networkMetricsRepository.GetByTimePeriod());
        }
    }
}
