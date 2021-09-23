using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Services.DTO;
using MetricsManager.DB.Entities;


namespace MetricsManager
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AgentInfo, AgentInfoDTO>();
            CreateMap<AgentInfoDTO, AgentInfo>();
        }        
    }
}
