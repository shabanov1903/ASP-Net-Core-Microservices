using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient.DataObjects
{
    public class Metric
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public DateTime Time { get; set; }
    }
}