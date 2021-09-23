using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.DB;
using MetricsAgent.DB.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MetricsManager.Tests
{
    public class XUnit_MetricsAgent
    {
        [Fact]
        public void Test_CpuMetricsController()
        {
            DateTime dt1 = new();
            DateTime dt2 = new();
            var cpuTable = new DBRepository<CpuMetricsEntity>(new AppDbContext(new DbContextOptions<AppDbContext>()));

            var _logger_Mock = new Mock<ILogger<CpuMetricsController>>();
            var _dbRepository_Mock = new Mock<IDBRepository<CpuMetricsEntity>>();
            var _mapper_Mock = new Mock<IMapper>();

            _dbRepository_Mock.Setup(a => a.GetAll()).Returns(new Mock<IQueryable<CpuMetricsEntity>>().Object).Verifiable();

            var cpuMetricsController = new CpuMetricsController(_logger_Mock.Object, cpuTable, _mapper_Mock.Object);
            cpuMetricsController.GetMetricsFromAgent(dt1, dt2);

            _dbRepository_Mock.Verify(a => a.GetAll(), Times.AtMostOnce());
        }
    }
}