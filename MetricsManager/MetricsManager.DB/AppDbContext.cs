using System;
using Microsoft.EntityFrameworkCore;
using MetricsManager.DB.Entities;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace MetricsManager.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CpuMetricsEntity> EntityCpu { get; set; }
        public DbSet<DotNetMetricsEntity> EntityDotNet { get; set; }
        public DbSet<HddMetricsEntity> EntityHdd { get; set; }
        public DbSet<NetworkMetricsEntity> EntityNetwork { get; set; }
        public DbSet<RamMetricsEntity> EntityRam { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
            var config = builder.Build();

            optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
        }
    }
}