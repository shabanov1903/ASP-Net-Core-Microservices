using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using MetricsManager.DAL;
using MetricsManager.Dto;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Tests
{
    public class xUnit_MetricsAgent
    {
        [Fact]
        public void test_CpuMetricsController()
        {
            TimeSpan ts1 = new TimeSpan(15, 10, 0);
            TimeSpan ts2 = new TimeSpan(16, 20, 0);

            var mock1 = new Mock<ILogger<MetricsAgent.Controllers.CpuMetricsController>>();
            var mock2 = new Mock<ICpuMetricsRepository>();

            mock2.Setup(a => a.GetByTimePeriod()).Returns(new List<CpuMetrics>()).Verifiable();

            var cpuMetricsController = new MetricsAgent.Controllers.CpuMetricsController(mock1.Object, mock2.Object);
            cpuMetricsController.GetMetricsFromAgent(ts1, ts2);

            mock2.Verify(a => a.GetByTimePeriod(), Times.AtMostOnce());
        }

        [Fact]
        public void test_DotNetMetricsController()
        {
            TimeSpan ts1 = new TimeSpan(15, 10, 0);
            TimeSpan ts2 = new TimeSpan(16, 20, 0);

            var mock1 = new Mock<ILogger<MetricsAgent.Controllers.DotNetMetricsController>>();
            var mock2 = new Mock<IDotNetMetricsRepository>();

            mock2.Setup(a => a.GetByTimePeriod()).Returns(new List<DotNetMetrics>());

            var dotNetMetricsController = new MetricsAgent.Controllers.DotNetMetricsController(mock1.Object, mock2.Object);
            dotNetMetricsController.GetMetricsFromAgent(ts1, ts2);

            mock2.Verify(a => a.GetByTimePeriod(), Times.AtMostOnce());
        }

        [Fact]
        public void test_HddNetMetricsController()
        {
            TimeSpan ts1 = new TimeSpan(15, 10, 0);
            TimeSpan ts2 = new TimeSpan(16, 20, 0);

            var mock1 = new Mock<ILogger<MetricsAgent.Controllers.HddMetricsController>>();
            var mock2 = new Mock<IHddMetricsRepository>();

            mock2.Setup(a => a.GetByTimePeriod()).Returns(new List<HddMetrics>());

            var hddMetricsController = new MetricsAgent.Controllers.HddMetricsController(mock1.Object, mock2.Object);
            hddMetricsController.GetMetricsFromAgent(ts1, ts2);

            mock2.Verify(a => a.GetByTimePeriod(), Times.AtMostOnce());
        }

        [Fact]
        public void test_NetworkNetMetricsController()
        {
            TimeSpan ts1 = new TimeSpan(15, 10, 0);
            TimeSpan ts2 = new TimeSpan(16, 20, 0);

            var mock1 = new Mock<ILogger<MetricsAgent.Controllers.NetworkMetricsController>>();
            var mock2 = new Mock<INetworkMetricsRepository>();

            mock2.Setup(a => a.GetByTimePeriod()).Returns(new List<NetworkMetrics>());

            var networkMetricsController = new MetricsAgent.Controllers.NetworkMetricsController(mock1.Object, mock2.Object);
            networkMetricsController.GetMetricsFromAgent(ts1, ts2);

            mock2.Verify(a => a.GetByTimePeriod(), Times.AtMostOnce());
        }

        [Fact]
        public void test_RamNetMetricsController()
        {
            TimeSpan ts1 = new TimeSpan(15, 10, 0);
            TimeSpan ts2 = new TimeSpan(16, 20, 0);

            var mock1 = new Mock<ILogger<MetricsAgent.Controllers.RamMetricsController>>();
            var mock2 = new Mock<IRamMetricsRepository>();

            mock2.Setup(a => a.GetByTimePeriod()).Returns(new List<RamMetrics>());

            var ramMetricsController = new MetricsAgent.Controllers.RamMetricsController(mock1.Object, mock2.Object);
            ramMetricsController.GetMetricsFromAgent(ts1, ts2);

            mock2.Verify(a => a.GetByTimePeriod(), Times.AtMostOnce());
        }
    }
}