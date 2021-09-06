using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsManager.Tests
{
    public class xUnit_MetricsManager
    {
        [Fact]
        public void test_AgentsController()
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
        public void test_CpuMetricsController()
        {
            int id = 1;
            TimeSpan ts1 = new TimeSpan(15, 10, 0);
            TimeSpan ts2 = new TimeSpan(16, 20, 0);
            var cpuMetricsController = new MetricsManager.Controllers.CpuMetricsController();

            Assert.IsAssignableFrom<IActionResult>(cpuMetricsController.GetMetricsFromAgent(id, ts1, ts2));
            Assert.IsAssignableFrom<IActionResult>(cpuMetricsController.GetMetricsFromAllCluster(ts1, ts2));
        }

        [Fact]
        public void test_DotNetMetricsController()
        {
            int id = 1;
            TimeSpan ts1 = new TimeSpan(15, 10, 0);
            TimeSpan ts2 = new TimeSpan(16, 20, 0);
            var dotNetMetricsController = new MetricsManager.Controllers.DotNetMetricsController();

            Assert.IsAssignableFrom<IActionResult>(dotNetMetricsController.GetMetricsFromAgent(id, ts1, ts2));
            Assert.IsAssignableFrom<IActionResult>(dotNetMetricsController.GetMetricsFromAllCluster(ts1, ts2));
        }

        [Fact]
        public void test_HddNetMetricsController()
        {
            int id = 1;
            TimeSpan ts1 = new TimeSpan(15, 10, 0);
            TimeSpan ts2 = new TimeSpan(16, 20, 0);
            var hddMetricsController = new MetricsManager.Controllers.HddMetricsController();

            Assert.IsAssignableFrom<IActionResult>(hddMetricsController.GetMetricsFromAgent(id, ts1, ts2));
            Assert.IsAssignableFrom<IActionResult>(hddMetricsController.GetMetricsFromAllCluster(ts1, ts2));
        }

        [Fact]
        public void test_NetworkNetMetricsController()
        {
            int id = 1;
            TimeSpan ts1 = new TimeSpan(15, 10, 0);
            TimeSpan ts2 = new TimeSpan(16, 20, 0);
            var networkMetricsController = new MetricsManager.Controllers.NetworkMetricsController();

            Assert.IsAssignableFrom<IActionResult>(networkMetricsController.GetMetricsFromAgent(id, ts1, ts2));
            Assert.IsAssignableFrom<IActionResult>(networkMetricsController.GetMetricsFromAllCluster(ts1, ts2));
        }

        [Fact]
        public void test_RamNetMetricsController()
        {
            int id = 1;
            TimeSpan ts1 = new TimeSpan(15, 10, 0);
            TimeSpan ts2 = new TimeSpan(16, 20, 0);
            var ramMetricsController = new MetricsManager.Controllers.RamMetricsController();

            Assert.IsAssignableFrom<IActionResult>(ramMetricsController.GetMetricsFromAgent(id, ts1, ts2));
            Assert.IsAssignableFrom<IActionResult>(ramMetricsController.GetMetricsFromAllCluster(ts1, ts2));
        }
    }
}