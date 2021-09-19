using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Services.DTO;

namespace MetricsManager.Services.DAL
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetByTimePeriod();
    }
}
