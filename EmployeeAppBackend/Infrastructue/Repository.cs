using EmployeeAppBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAppBackend.Infrastructue
{
    /// <summary>
    ///  Generic repository for CRUD operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository <T> : IRepository<T> where T : class
    {
        private readonly EmployeeAppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(EmployeeAppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<T> GetByStringIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
