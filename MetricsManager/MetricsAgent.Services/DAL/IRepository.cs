using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Services.DTO;

namespace MetricsAgent.Services.DAL
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetByTimePeriod();
    }
}
