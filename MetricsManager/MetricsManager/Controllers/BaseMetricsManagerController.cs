using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Services.DTO;
using MetricsManager.DB.Entities;
using AutoMapper;
using System.Net.Http;

namespace MetricsManager.Controllers
{
    public class BaseMetricsManagerController<T> : ControllerBase
    {
        private readonly ILogger<T> _logger;
        private IQueryManager<T> _query;
        public BaseMetricsManagerController(ILogger<T> logger, IQueryManager<T> query)
        {
            _logger = logger;
            _query = query;
            _logger.LogDebug(1, $"Request to Controller");
        }

        public virtual IActionResult GetMetricsFromAgent(
            int agentId,
            DateTime fromTime,
            DateTime toTime)
        {
            _logger.LogInformation($"GET request to {HttpContext?.Request}");
            var results = _query.QueryById(agentId, fromTime, toTime);
            return Ok(results);
        }

        /*
        public virtual IActionResult GetMetricsFromAllCluster(
            DateTime fromTime,
            DateTime toTime)
        {
            _logger.LogInformation($"GET request to {HttpContext?.Request}");
            var response = new List<T>();
            return Ok();
        }
        */
    }
}