using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using AutoMapper;
using MetricsManager.Controllers;
using MetricsManager.DB;
using MetricsManager.DB.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MetricsManager.Tests
{
    public class XUnit_MetricsManager
    {
        
        [Fact]
        public void Test_AgentsController()
        {
            int id = 1;
            var agentInfo = new MetricsManager.AgentInfo() { AgentId = 1, AgentAddress = new Uri ("https://localhost:44390/") };
            var agentController = new MetricsManager.Controllers.AgentsController();

            Assert.IsAssignableFrom<IActionResult>(agentController.RegisterAgent(agentInfo));
            Assert.IsAssignableFrom<IActionResult>(agentController.EnableAgentById(id));
            Assert.IsAssignableFrom<IActionResult>(agentController.DisableAgentById(id));
            Assert.IsAssignableFrom<IActionResult>(agentController.GetRegisterServices());
        }

        [Fact]
        public void Test_CpuMetricsController()
        {
            int id = 1;
            DateTime dt1 = new();
            DateTime dt2 = new();
            var cpuTable = new DBRepository<CpuMetricsEntity>(new AppDbContext(new DbContextOptions<AppDbContext>()));

            var _logger_Mock = new Mock<ILogger<CpuMetricsController>>();
            var _dbRepository_Mock = new Mock<IDBRepository<CpuMetricsEntity>>();
            var _mapper_Mock = new Mock<IMapper>();

            _dbRepository_Mock.Setup(a => a.GetAll()).Returns(new Mock<IQueryable<CpuMetricsEntity>>().Object).Verifiable();

            // var cpuMetricsController = new MetricsAgent.Controllers.CpuMetricsController(_logger_Mock.Object, _dbRepository_Mock.Object, _mapper_Mock.Object);
            var cpuMetricsController = new CpuMetricsController(_logger_Mock.Object, cpuTable, _mapper_Mock.Object);
            cpuMetricsController.GetMetricsFromAgent(id, dt1, dt2);

            _dbRepository_Mock.Verify(a => a.GetAll(), Times.AtMostOnce());
        }
    }
}