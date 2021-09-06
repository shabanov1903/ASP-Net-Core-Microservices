using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsManager.Tests
{
    public class xUnit_MetricsAgent
    {
        [Fact]
        public void test_CpuMetricsController()
        {
            int id = 1;
            TimeSpan ts1 = new TimeSpan(15, 10, 0);
            TimeSpan ts2 = new TimeSpan(16, 20, 0);
            var cpuMetricsController = new MetricsAgent.Controllers.CpuMetricsController();

            Assert.IsAssignableFrom<IActionResult>(cpuMetricsController.GetMetricsFromAgent(id, ts1, ts2));
        }

        [Fact]
        public void test_DotNetMetricsController()
        {
            int id = 1;
            TimeSpan ts1 = new TimeSpan(15, 10, 0);
            TimeSpan ts2 = new TimeSpan(16, 20, 0);
            var dotNetMetricsController = new MetricsAgent.Controllers.DotNetMetricsController();

            Assert.IsAssignableFrom<IActionResult>(dotNetMetricsController.GetMetricsFromAgent(id, ts1, ts2));
        }

        [Fact]
        public void test_HddNetMetricsController()
        {
            int id = 1;
            TimeSpan ts1 = new TimeSpan(15, 10, 0);
            TimeSpan ts2 = new TimeSpan(16, 20, 0);
            var hddMetricsController = new MetricsAgent.Controllers.HddMetricsController();

            Assert.IsAssignableFrom<IActionResult>(hddMetricsController.GetMetricsFromAgent(id, ts1, ts2));
        }

        [Fact]
        public void test_NetworkNetMetricsController()
        {
            int id = 1;
            TimeSpan ts1 = new TimeSpan(15, 10, 0);
            TimeSpan ts2 = new TimeSpan(16, 20, 0);
            var networkMetricsController = new MetricsAgent.Controllers.NetworkMetricsController();

            Assert.IsAssignableFrom<IActionResult>(networkMetricsController.GetMetricsFromAgent(id, ts1, ts2));
        }

        [Fact]
        public void test_RamNetMetricsController()
        {
            int id = 1;
            TimeSpan ts1 = new TimeSpan(15, 10, 0);
            TimeSpan ts2 = new TimeSpan(16, 20, 0);
            var ramMetricsController = new MetricsAgent.Controllers.RamMetricsController();

            Assert.IsAssignableFrom<IActionResult>(ramMetricsController.GetMetricsFromAgent(id, ts1, ts2));
        }
    }
}