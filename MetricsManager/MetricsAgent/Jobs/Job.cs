using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsAgent.DB;
using MetricsAgent.DB.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace MetricsAgent.Jobs
{
    public class Job : IJob
    {
        private IServiceProvider _scopeFactory;
        public Job(IServiceProvider scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                #pragma warning disable CA1416 // Проверка совместимости платформы
                var _counterCpu = new PerformanceCounter("Процессор", "Скорость DPC", "_Total");
                var _counterDot = new PerformanceCounter("Память CLR .NET", "% времени в GC", "_Global_");
                var _counterHdd = new PerformanceCounter("Физический диск", "% активности диска", "_Total");
                var _counterNet = new PerformanceCounter("Сетевой интерфейс", "Текущая пропускная способность", "Intel[R] Wi-Fi 6 AX201 160MHz");
                var _counterRam = new PerformanceCounter("Логический диск", "% свободного места", "_Total");
 
                await SetMetric<CpuMetricsEntity>(_counterCpu.NextValue(), scope);
                await SetMetric<DotNetMetricsEntity>(_counterDot.NextValue(), scope);
                await SetMetric<HddMetricsEntity>(_counterHdd.NextValue(), scope);
                await SetMetric<NetworkMetricsEntity>(_counterNet.NextValue(), scope);
                await SetMetric<RamMetricsEntity>(_counterRam.NextValue(), scope);
                #pragma warning restore CA1416 // Проверка совместимости платформы
            }
        }

        private async Task SetMetric<Tentity>(float value, IServiceScope scope) where Tentity : BaseEntity, new()
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await db.Set<Tentity>().AddAsync(new Tentity { Value = value, Time = DateTime.Now });
            await db.SaveChangesAsync();
        }
    }
}