using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsManager.DB.Entities;

namespace MetricsManager.DB
{
    public interface IDBRepository<T>
    {
        IQueryable<T> GetAll();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        T GetElementById(int id);
    }
}