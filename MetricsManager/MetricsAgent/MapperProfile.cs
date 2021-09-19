using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Services.DTO;
using MetricsAgent.DB.Entities;


namespace MetricsAgent
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetrics, CpuMetricsEntity>();
            CreateMap<CpuMetricsEntity, CpuMetrics>();

            CreateMap<DotNetMetrics, DotNetMetricsEntity>();
            CreateMap<DotNetMetricsEntity, DotNetMetrics>();

            CreateMap<HddMetrics, HddMetricsEntity>();
            CreateMap<HddMetricsEntity, HddMetrics>();

            CreateMap<NetworkMetrics, NetworkMetricsEntity>();
            CreateMap<NetworkMetricsEntity, NetworkMetrics>();

            CreateMap<RamMetrics, RamMetricsEntity>();
            CreateMap<RamMetricsEntity, RamMetrics>();
        }        
    }
}
