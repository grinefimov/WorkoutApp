using Microsoft.EntityFrameworkCore;
using WorkoutApp.SharedKernel;

namespace WorkoutApp.Infrastructure
{
    public class GenericRepository<TEntity>(SqlLiteDbContext dbContext) : IGenericRepository<TEntity> where TEntity : EntityBase<int>
    {
        private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}