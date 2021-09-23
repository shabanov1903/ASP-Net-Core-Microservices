using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DB.Entities
{
    public class AgentInfo
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public Uri AgentAddress { get; set; }
    }
}
