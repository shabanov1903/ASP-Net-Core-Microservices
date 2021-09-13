using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetByTimePeriod();
    }

    public interface ICpuMetricsRepository : IRepository<Dto.CpuMetrics> { }
    public interface IDotNetMetricsRepository : IRepository<Dto.DotNetMetrics> { }
    public interface IHddMetricsRepository : IRepository<Dto.HddMetrics> { }
    public interface INetworkMetricsRepository : IRepository<Dto.NetworkMetrics> { }
    public interface IRamMetricsRepository : IRepository<Dto.RamMetrics> { }
}
