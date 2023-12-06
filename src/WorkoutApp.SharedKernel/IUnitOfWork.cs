namespace WorkoutApp.SharedKernel
{
    public interface IUnitOfWork
    {
        Task SaveAsync(CancellationToken token = default);
    }
}
