using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsManager.DB;
using MetricsManager.DB.Entities;
using MetricsManager.Services.DTO;
using Microsoft.Extensions.DependencyInjection;

namespace MetricsManager.Jobs
{
    public class Job : IJob
    {
        private IQueryManager<CpuMetrics> _query;
        private readonly IDBRepository<AgentInfo> _dbrepository;
        public Job(IQueryManager<CpuMetrics> query, IDBRepository<AgentInfo> dbrepository)
        {
            _query = query;
            _dbrepository = dbrepository;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() => UpdateFunction(1));
            await Task.Run(() => UpdateFunction(2));
            await Task.Run(() => UpdateFunction(3));
            await Task.Run(() => UpdateFunction(4));
            await Task.Run(() => UpdateFunction(5));
        }

        private async Task UpdateFunction(int id)
        {
            var entity = _dbrepository.GetElementById(id);
            entity.Enabled = _query.StatusQuery(id);
            await _dbrepository.UpdateAsync(entity);
        }
    }
}