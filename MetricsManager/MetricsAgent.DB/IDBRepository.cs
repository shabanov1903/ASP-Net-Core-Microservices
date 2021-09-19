using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsAgent.DB.Entities;

namespace MetricsAgent.DB
{
    public interface IDBRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task AddAsync(T entity);
        
        /*
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        */
    }
}