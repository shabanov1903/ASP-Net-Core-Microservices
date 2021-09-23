using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Services.DTO
{
    public class AgentInfoDTO
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public Uri AgentAddress { get; set; }
    }
}
