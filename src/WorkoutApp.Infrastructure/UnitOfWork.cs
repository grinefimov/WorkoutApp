using WorkoutApp.SharedKernel;

namespace WorkoutApp.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly SqlLiteDbContext _dbContext;

        public UnitOfWork(SqlLiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync(CancellationToken token = default)
        {
            await _dbContext.SaveChangesAsync(token);
        }
    }
}
