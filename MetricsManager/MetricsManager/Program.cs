using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog.Web;
using MetricsManager.DB;
using MetricsManager.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MetricsManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            var cpuTable = new DBRepository<CpuMetricsEntity>(new AppDbContext(new DbContextOptions<AppDbContext>()));
            var dotnetTable = new DBRepository<DotNetMetricsEntity>(new AppDbContext(new DbContextOptions<AppDbContext>()));
            var hddTable = new DBRepository<HddMetricsEntity>(new AppDbContext(new DbContextOptions<AppDbContext>()));
            var networkTable = new DBRepository<NetworkMetricsEntity>(new AppDbContext(new DbContextOptions<AppDbContext>()));
            var ramTable = new DBRepository<RamMetricsEntity>(new AppDbContext(new DbContextOptions<AppDbContext>()));

            Task.Run( async () =>
            {
                while (true)
                {
                    await cpuTable.AddAsync(new CpuMetricsEntity { Value = (float)new Random().NextDouble() * 100, Time = DateTime.Now });
                    await dotnetTable.AddAsync(new DotNetMetricsEntity { Value = (float)new Random().NextDouble() * 100, Time = DateTime.Now });
                    await hddTable.AddAsync(new HddMetricsEntity { Value = (float)new Random().NextDouble() * 100, Time = DateTime.Now });
                    await networkTable.AddAsync(new NetworkMetricsEntity { Value = (float)new Random().NextDouble() * 100, Time = DateTime.Now });
                    await ramTable.AddAsync(new RamMetricsEntity { Value = (float)new Random().NextDouble() * 100, Time = DateTime.Now });
                    await Task.Delay(2000);
                }                
            });

            try
            {
                logger.Debug("init main");
                CreateHostBuilder(args).Build().Run();
            }
            // Отлов всех исключений в рамках работы приложения
            catch (Exception exception)
            {
                // NLog: устанавливаем отлов исключений
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Остановка логера
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                }).UseNLog();
    }
}