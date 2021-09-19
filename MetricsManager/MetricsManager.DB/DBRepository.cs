using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsManager.DB.Entities;

namespace MetricsManager.DB
{
    public class DBRepository<T> : IDBRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public DBRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}