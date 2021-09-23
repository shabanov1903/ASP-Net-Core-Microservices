using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.DB;
using MetricsManager.Services.DTO;
using MetricsManager.DB.Entities;
using AutoMapper;
using System.Net.Http;
using System.Text.Json;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly IDBRepository<AgentInfo> _dbrepository;
        private readonly IMapper _mapper;

        public AgentsController(IDBRepository<AgentInfo> dbrepository, IMapper mapper)
        {
            _dbrepository = dbrepository;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            await _dbrepository.AddAsync(agentInfo);
            return Ok();
        }

        [HttpPut("enable/{agentId}")]
        public async Task<IActionResult> EnableAgentById([FromRoute] int agentId)
        {
            var entity = _dbrepository.GetElementById(agentId);
            try
            {
                entity.Enabled = true;
                await _dbrepository.UpdateAsync(entity);
            }
            catch { }
            
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public async Task<IActionResult> DisableAgentById([FromRoute] int agentId)
        {
            var entity = _dbrepository.GetElementById(agentId);
            try
            {
                entity.Enabled = false;
                await _dbrepository.UpdateAsync(entity);
            }
            catch { }

            return Ok();
        }

        [HttpGet("services")]
        public IActionResult GetRegisterServices()
        {
            var agents = _dbrepository.GetAll();
            var response = new List<AgentInfoDTO>();
            foreach (var agent in agents)
            {
                response.Add(_mapper.Map<AgentInfoDTO>(agent));
            }
            return Ok(response);
        }
    }
}