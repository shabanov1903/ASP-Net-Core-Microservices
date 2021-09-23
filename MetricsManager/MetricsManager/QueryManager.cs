using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using MetricsManager.DB;
using MetricsManager.Services.DTO;
using MetricsManager.DB.Entities;
using MetricsManager.Controllers;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace MetricsManager
{
    public class QueryManager<T> : IQueryManager<T> where T : BaseDTO
    {
        private readonly IDBRepository<AgentInfo> _dbrepository;
        private readonly ILogger<T> _logger;
        private IHttpClientFactory _clientfactory;
        public QueryManager(IDBRepository<AgentInfo> dbrepository, ILogger<T> logger, IHttpClientFactory clientfactory)
        {
            _dbrepository = dbrepository;
            _logger = logger;
            _clientfactory = clientfactory;
        }

        public List<T> QueryById(int id, DateTime dt1, DateTime dt2)
        {
            var entity = _dbrepository.GetElementById(id);

            var client = _clientfactory.CreateClient();
            HttpResponseMessage result = null;
            try
            {
                result = client.GetAsync(String.Format(entity.AgentAddress.ToString(),
                                         JsonSerializer.Serialize(dt1).ToString().Replace("\"", ""),
                                         JsonSerializer.Serialize(dt2).ToString().Replace("\"", ""))).Result;
            }
            catch
            {
                _logger.LogError("Bad Request");
            }

            if (result is null ? false : result.IsSuccessStatusCode)
            {
                using var responseStream = result.Content.ReadAsStreamAsync().Result;
                var metricResponse = JsonSerializer.DeserializeAsync<List<T>>(responseStream, new JsonSerializerOptions(JsonSerializerDefaults.Web));
                return metricResponse.Result;
            }
            else
            {
                _logger.LogError("Status Code of Request: " + result?.StatusCode.ToString());
                return new List<T>();
            }
        }

        public bool StatusQuery(int id)
        {
            var entity = _dbrepository.GetElementById(id);

            var client = _clientfactory.CreateClient();
            HttpResponseMessage result;
            try
            {
                result = client.GetAsync(String.Format(entity.AgentAddress.ToString(),
                                         JsonSerializer.Serialize(DateTime.Now).ToString().Replace("\"", ""),
                                         JsonSerializer.Serialize(DateTime.Now).ToString().Replace("\"", ""))).Result;
            }
            catch
            {
                return false;
            }

            if (result is null ? false : result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                _logger.LogError("Status Code of Request: " + result?.StatusCode.ToString());
                return false;
            }
        }
    }
}