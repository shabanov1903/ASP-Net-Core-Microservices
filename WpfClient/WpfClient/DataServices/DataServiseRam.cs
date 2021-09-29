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
    public class DataServiseRam : DataService
    {
        protected override string MetricsUri { get; }
        public DataServiseRam()
        {
            MetricsUri = @"https://localhost:5001/api/metrics/ram/agent/{0}/from/{1}/to/{2}";
        }
    }
}