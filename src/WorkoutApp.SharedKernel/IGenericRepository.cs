namespace WorkoutApp.SharedKernel
{
    public interface IGenericRepository<TEntity> where TEntity : EntityBase<int>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
