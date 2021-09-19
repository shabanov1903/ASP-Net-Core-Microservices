using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManager.Services.DTO
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public DateTime Time { get; set; }
    }
}
