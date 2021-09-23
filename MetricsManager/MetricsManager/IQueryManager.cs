using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.DB;
using MetricsManager.DB.Entities;
using AutoMapper;
using System.Net.Http;

namespace MetricsManager
{
    public interface IQueryManager<T>
    {
        public List<T> QueryById(int id, DateTime dt1, DateTime dt2);
        public bool StatusQuery(int id);
    }
}