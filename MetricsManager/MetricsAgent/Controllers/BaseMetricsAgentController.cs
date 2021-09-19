using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.DB;
using MetricsAgent.DB.Entities;
using AutoMapper;

namespace MetricsAgent.Controllers
{
    public class BaseMetricsAgentController<Tcontroller, Tentity, Tdto> : ControllerBase where Tentity : BaseEntity, new()
    {
        private readonly ILogger<Tcontroller> _logger;
        private readonly IDBRepository<Tentity> _dbrepository;
        private readonly IMapper _mapper;
        public BaseMetricsAgentController(ILogger<Tcontroller> logger, IDBRepository<Tentity> dbrepository, IMapper mapper)
        {
            _mapper = mapper;
            _dbrepository = dbrepository;
            _logger = logger;
            _logger.LogDebug(1, $"Request to Controller");
        }

        public virtual IActionResult GetMetricsFromAgent(
            DateTime fromTime,
            DateTime toTime)
        {
            _logger.LogInformation($"GET request to {HttpContext?.Request}");
            var metrics = _dbrepository.GetAll().ToList().Where(x => x.Time > fromTime && x.Time < toTime);
            var response = new List<Tdto>();
            foreach (var metric in metrics)
            {
                response.Add(_mapper.Map<Tdto>(metric));
            }
            return Ok(response);
        }
    }
}
