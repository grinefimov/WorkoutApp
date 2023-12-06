using Microsoft.EntityFrameworkCore;
using WorkoutApp.SharedKernel;

namespace WorkoutApp.Infrastructure
{
    internal class GenericRepository<TEntity>(DbContext dbContext) : IGenericRepository<TEntity> where TEntity : EntityBase<int>
    {
        private DbSet<TEntity> _dbSet { get; set; } = dbContext.Set<TEntity>();

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task DeleteAsync(TEntity entity)
        {
             _dbSet.Remove(entity);
             return Task.CompletedTask;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }
    }
}