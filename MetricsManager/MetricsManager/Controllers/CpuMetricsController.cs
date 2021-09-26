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
using System.Net.Http;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : BaseMetricsManagerController<CpuMetrics>
    {
        public CpuMetricsController(ILogger<CpuMetrics> logger, IQueryManager<CpuMetrics> query) : base(logger, query)
        {
        }

        /// <summary>
        /// Получает метрики Cpu на заданном диапазоне времени по ID
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET https://localhost:44390/api/metrics/cpu/agent/1/from/{DateTime}/to/{DateTime}
        /// </remarks>
        /// <param name="agentId">ID агента</param>
        /// <param name="fromTime">Начальная метка времени</param>
        /// <param name="toTime">Конечная метка времени</param>
        /// <returns>Список метрик, которые были сохранены в заданном диапазоне</returns>
        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public override IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            return base.GetMetricsFromAgent(agentId, fromTime, toTime);
        }

        /*
        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public override IActionResult GetMetricsFromAllCluster(
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            return base.GetMetricsFromAllCluster(fromTime, toTime);
        }
        */
    }
}