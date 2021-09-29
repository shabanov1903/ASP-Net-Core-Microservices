using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using WpfClient.DataObjects;
using System.Text.RegularExpressions;

namespace WpfClient.DataServices
{
    public class DataServiseHdd : DataService
    {
        protected override string MetricsUri { get; }
        public DataServiseHdd()
        {
            MetricsUri = @"https://localhost:5001/api/metrics/hdd/agent/{0}/from/{1}/to/{2}";
        }
    }
}