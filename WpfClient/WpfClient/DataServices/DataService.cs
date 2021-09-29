using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using WpfClient.DataObjects;

namespace WpfClient.DataServices
{
    public abstract class DataService
    {
        protected abstract string MetricsUri { get; }
        public async Task<List<Metric>> GetMetrics(int id, string time1, string time2)
        {
            List<Metric> metricList = new();
            HttpClient client = new();
            try
            {
                HttpResponseMessage response = await client.GetAsync(String.Format(MetricsUri, id, time1.Replace(" ", "T"), time2.Replace(" ", "T")));
                response.EnsureSuccessStatusCode();
                var responseBody = response.Content.ReadAsStreamAsync().Result;
                var metricResponse = await JsonSerializer.DeserializeAsync<List<Metric>>(responseBody, new JsonSerializerOptions(JsonSerializerDefaults.Web));
                foreach (Metric value in metricResponse)
                {
                    metricList.Add(value);
                }
            }
            catch
            {
                return new List<Metric>();
            }
            return metricList;
        }
    }
}
