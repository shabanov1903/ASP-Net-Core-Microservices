using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.DB;
using MetricsAgent.Jobs;
using MetricsAgent.DB.Entities;
using AutoMapper;
using Quartz;
using Quartz.Spi;
using Quartz.Impl;
using System.Net.Http;

namespace MetricsAgent
{
    public class HttpClientManager : IStartupFilter
    {
        private IHttpClientFactory _clientfactory;
        public HttpClientManager(IHttpClientFactory clientfactory) => _clientfactory = clientfactory;

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                Task.Run(() => GetResponseEnableAgent(1));
                Task.Run(() => GetResponseEnableAgent(2));
                Task.Run(() => GetResponseEnableAgent(3));
                Task.Run(() => GetResponseEnableAgent(4));
                Task.Run(() => GetResponseEnableAgent(5));
                next(builder);
            };
        }

        public async Task GetResponseEnableAgent(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:44390/api/agents/enable/{id}");
            var client = _clientfactory.CreateClient();
            await client.SendAsync(request);
        }
    }
}